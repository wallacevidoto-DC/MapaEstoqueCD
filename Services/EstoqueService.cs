using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace MapaEstoqueCD.Services
{
    public class EstoqueService
    {
        public EstoqueService()
        {

        }
        public List<Estoque> GetAll()
        {
            return CacheMP.Instance.Db.Estoque.ToList();
        }


        public List<EstoqueWsDto> GetAllProd()
        {
            return CacheMP.Instance.Db.Estoque
                .Include(e => e.Produto)
                .Include(e => e.Endereco)
                .Where(e => e.EnderecoId != null)
                .AsEnumerable()
                .Select(e => new EstoqueWsDto
                {
                    estoqueId = e.EstoqueId,
                    enderecoId = e.EnderecoId ?? $"{e.Endereco?.Rua}{e.Endereco?.Coluna}{e.Endereco?.Palete}",
                    produtoId = e.ProdutoId ?? 0,
                    semF = e.SemF ?? 0,
                    quantidade = e.Quantidade ?? 0,
                    dataF = e.DataF,
                    dataL = (e.DataL ?? DateTime.MinValue).Date,
                    lote = e.Lote,
                    obs = e.Obs,
                    createAt = e.CreateAt ?? DateTime.MinValue,
                    updateAt = e.UpdateAt ?? DateTime.MinValue,
                    produto = e.Produto == null ? null : new ProdutoWsDto
                    {
                        codigo = e.Produto.Codigo,
                        descricao = e.Produto.Descricao
                    }
                }).OrderBy(e => e.dataL)
                .ToList();
        }

        public List<ProdutoSpDto> GetEnderecoByDetails(string rua, string bloco, string apt)
        {
            Endereco sprod = CacheMP.Instance.Db.Enderecos.FirstOrDefault(e => e.Rua == rua && e.Coluna == bloco && e.Palete == apt);

            if (sprod == null)
            {
                return null;
            }

            List<ProdutoSpDto> produtos = new List<ProdutoSpDto>();

            for (int i = 0; i < sprod.Estoque.Count; i++)
            {
                produtos.Add(new ProdutoSpDto
                {
                    id = sprod.Estoque.ElementAt(i).Produto.ProdutoId,
                    codigo = sprod.Estoque.ElementAt(i).Produto?.Codigo,
                    descricao = sprod.Estoque.ElementAt(i).Produto?.Descricao,
                    quantidade = sprod.Estoque.ElementAt(i).Quantidade ?? 0,
                    dataf = sprod.Estoque.ElementAt(i).DataF ?? "",
                    semf = sprod.Estoque.ElementAt(i).SemF ?? 0,
                    lote = sprod.Estoque.ElementAt(i).Lote ?? "",
                    propsPST = new()
                    {
                        origem = Origem.IN,
                        isModified = false
                    }
                });
            }
            return produtos;



        }

        internal bool SetEntrada(EntradaDto entradaDto)
        {
            using var transaction = CacheMP.Instance.Db.Database.BeginTransaction();

            try
            {
                //string enderecoId = $"{entradaDto.rua}{entradaDto.bloco}{entradaDto.apt}";
                //var endereco = CacheMP.Instance.Db.Enderecos.FirstOrDefault(e => e.EnderecoId == enderecoId);

                //if (endereco == null)
                //{
                //    endereco = new Endereco
                //    {
                //        Rua = entradaDto.rua,
                //        Coluna = entradaDto.bloco,
                //        Palete = entradaDto.apt
                //    };

                //    CacheMP.Instance.Db.Enderecos.Add(endereco);
                //    CacheMP.Instance.Db.SaveChanges();
                //}
                var endereco = CacheMP.Instance.Db.Enderecos
    .FirstOrDefault(e =>
        e.Rua == entradaDto.rua &&
        e.Coluna == entradaDto.bloco &&
        e.Palete == entradaDto.apt);

                if (endereco == null)
                {
                    endereco = new Endereco
                    {
                        Rua = entradaDto.rua,
                        Coluna = entradaDto.bloco,
                        Palete = entradaDto.apt
                    };
                    CacheMP.Instance.Db.Enderecos.Add(endereco);
                    CacheMP.Instance.Db.SaveChanges();
                }

                foreach (var p in entradaDto.produtos)
                {
                    if (!p.IsValid(out string msg))
                        throw new Exception($"Produto inválido: {p.codigo} — {msg}");

                    //var produto = CacheMP.Instance.Db.Produtos.FirstOrDefault(x => x.Codigo == p.codigo);

                    //if (produto == null)
                    //{
                    //    produto = new Produtos
                    //    {
                    //        Codigo = p.codigo,
                    //        Descricao = p.descricao
                    //    };
                    //    CacheMP.Instance.Db.Produtos.Add(produto);
                    //    CacheMP.Instance.Db.SaveChanges();
                    //}
                    var novoEstoque = new Estoque
                    {
                        ProdutoId = p.id,
                        EnderecoId = endereco.EnderecoId,
                        Quantidade = p.quantidade,
                        Lote = p.lote,
                        DataF = p.dataf,
                        SemF = p.semf,
                        CreateAt = DateTime.Now,
                        DataL = entradaDto.dataEntrada
                    };
                    CacheMP.Instance.Db.Estoque.Add(novoEstoque);
                    CacheMP.Instance.Db.SaveChanges();

                    var movimentacao = new Movimentacao
                    {
                        EstoqueId = novoEstoque.EstoqueId,
                        ProdutoId = p.id,
                        Tipo = entradaDto.tipo,
                        Quantidade = p.quantidade,
                        Obs = entradaDto.observacao,
                        CreateAt = entradaDto.dataEntrada,
                        UserId = entradaDto.userId,
                        DataF = p.dataf,
                        SemF = p.semf,
                        Lote = p.lote

                    };
                    CacheMP.Instance.Db.Movimentacoes.Add(movimentacao);
                    CacheMP.Instance.Db.SaveChanges();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("❌ Erro ao registrar entrada: " + ex.Message);
                return false;
            }
        }
    }
}
