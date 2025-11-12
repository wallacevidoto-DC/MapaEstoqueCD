using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;
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
                    produtoId = sprod.Estoque.ElementAt(i).Produto.ProdutoId,
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

        internal List<EstoqueWsDto> GetAllEstoque()
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
                   dataF = DataFormatter.FormatarData(e.DataF),
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
               }).OrderByDescending(e => e.createAt)
               .ToList();
        }

        internal bool SetEntrada(EntradaDto entradaDto)
        {
            using var transaction = CacheMP.Instance.Db.Database.BeginTransaction();

            try
            {
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
                    endereco.GerarEnderecoId();
                    CacheMP.Instance.Db.Enderecos.Add(endereco);
                    CacheMP.Instance.Db.SaveChanges();
                }

                foreach (var p in entradaDto.produtos)
                {
                    if (!p.IsValid(out string msg))
                        throw new Exception($"Produto inválido: {p.codigo} — {msg}");
                    var novoEstoque = new Estoque
                    {
                        ProdutoId = p.produtoId,
                        EnderecoId = endereco.EnderecoId,
                        Quantidade = p.quantidade,
                        Lote = p.lote,
                        DataF = p.dataf,
                        SemF = p.semf,
                        CreateAt = DateTime.Now,
                        DataL = entradaDto.dataEntrada,
                        Obs = entradaDto.observacao
                    };
                    CacheMP.Instance.Db.Estoque.Add(novoEstoque);
                    CacheMP.Instance.Db.SaveChanges();

                    var movimentacao = new Movimentacao
                    {
                        EstoqueId = novoEstoque.EstoqueId,
                        ProdutoId = p.produtoId,
                        Tipo = entradaDto.tipo,
                        Quantidade = p.quantidade,
                        Obs = entradaDto.observacao,
                        UserId = entradaDto.userId,
                        DataF = p.dataf,
                        SemF = p.semf,
                        Lote = p.lote,
                        Endereco = endereco.EnderecoId,
                        DataL = entradaDto.dataEntrada


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

        public bool SetSaida(SaidaDto saidaDto)
        {
            try
            {
                var estoque = CacheMP.Instance.Db.Estoque.FirstOrDefault(e => e.EstoqueId == saidaDto.estoqueId);

                if (estoque == null || estoque.Quantidade == null)
                {
                    return false;
                }
                int qtdOld = estoque.Quantidade ?? 0;
                int qtdNew = qtdOld - saidaDto.qtdRetirada;

                estoque.Quantidade = qtdNew < 0 ? 0 : qtdNew;

                CacheMP.Instance.Db.SaveChanges();

                try
                {


                    string Obs = saidaDto?.observacao ?? "";
                    Obs += $" {(string.IsNullOrEmpty(saidaDto.observacao) ? "" : " | ")}Saída: R-{saidaDto.qtdRetirada} de E-{qtdOld}";

                    if (estoque.Quantidade == 0)
                    {
                        Obs += " | Produto Zerado no Estoque";
                    }

                    var movimentacao = new Movimentacao
                    {
                        EstoqueId = estoque.EstoqueId,
                        ProdutoId = estoque.Produto.ProdutoId,
                        Tipo = saidaDto.tipo,
                        Quantidade = qtdNew,
                        Obs = Obs,
                        UserId = saidaDto.userId,
                        DataF = estoque.DataF,
                        SemF = estoque.SemF ?? 0,
                        Lote = estoque.Lote,
                        Endereco = estoque.Endereco.EnderecoId,
                        DataL = estoque.DataL ?? DateTime.Now


                    };
                    CacheMP.Instance.Db.Movimentacoes.Add(movimentacao);
                    CacheMP.Instance.Db.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public bool SetCorrecaoProduto(CorrecaoDto correcaoDto)
        {
            using var transaction = CacheMP.Instance.Db.Database.BeginTransaction();

            try
            {
                var estoqueExistente = CacheMP.Instance.Db.Estoque.FirstOrDefault(e => e.EstoqueId == correcaoDto.enderecoId);

                if (estoqueExistente == null)
                    throw new Exception($"Estoque não encontrado.");

                string Obs = correcaoDto.observacao ?? "";
                Obs += $" {(string.IsNullOrEmpty(correcaoDto.observacao) ? "" : " | ")}Correção: (Q:{estoqueExistente.Quantidade} - DF:{DataFormatter.FormatarData(estoqueExistente.DataF)} - SF:{estoqueExistente.SemF} - LT:{estoqueExistente.Lote} )";

                estoqueExistente.Quantidade = correcaoDto.produto.quantidade;
                estoqueExistente.Lote = correcaoDto.produto.lote;
                estoqueExistente.DataF = correcaoDto.produto.dataf;
                estoqueExistente.SemF = correcaoDto.produto.semf;
                estoqueExistente.Obs = correcaoDto.observacao;

                CacheMP.Instance.Db.Estoque.Update(estoqueExistente);
                CacheMP.Instance.Db.SaveChanges();


                var movimentacao = new Movimentacao
                {
                    EstoqueId = estoqueExistente.EstoqueId,
                    ProdutoId = correcaoDto.produto.produtoId,
                    Tipo = correcaoDto.tipo,
                    Quantidade = correcaoDto.produto.quantidade,
                    Obs = Obs,
                    UserId = correcaoDto.userId,
                    DataF = correcaoDto.produto.dataf,
                    SemF = correcaoDto.produto.semf,
                    Lote = correcaoDto.produto.lote,
                    Endereco = estoqueExistente.EnderecoId,
                    DataL = estoqueExistente.DataL ?? DateTime.Now


                };
                CacheMP.Instance.Db.Movimentacoes.Update(movimentacao);
                CacheMP.Instance.Db.SaveChanges();

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

        internal bool SetTransferencia(TranferenciaDto transferenciaDto)
        {
            using var transaction = CacheMP.Instance.Db.Database.BeginTransaction();

            try
            {
                var endereco = CacheMP.Instance.Db.Enderecos
                    .FirstOrDefault(e =>
                        e.Rua == transferenciaDto.rua &&
                        e.Coluna == transferenciaDto.bloco &&
                        e.Palete == transferenciaDto.apt);

                if (endereco == null)
                {
                    endereco = new Endereco
                    {
                        Rua = transferenciaDto.rua,
                        Coluna = transferenciaDto.bloco,
                        Palete = transferenciaDto.apt
                    };
                    endereco.GerarEnderecoId();
                    CacheMP.Instance.Db.Enderecos.Add(endereco);
                    CacheMP.Instance.Db.SaveChanges();
                }

                if (!transferenciaDto.produto.IsValid(out string msg))
                    throw new Exception($"Produto inválido: {transferenciaDto.produto.codigo} — {msg}");
                var estoqueExistente = CacheMP.Instance.Db.Estoque.FirstOrDefault(e => e.EstoqueId == transferenciaDto.estoqueID);

                if (estoqueExistente != null)
                {
                    estoqueExistente.EnderecoId = endereco.EnderecoId;
                    CacheMP.Instance.Db.SaveChanges();
                }
                else
                {
                    var novoEstoque = new Estoque
                    {
                        ProdutoId = transferenciaDto.produto.produtoId,
                        EnderecoId = endereco.EnderecoId,
                        Quantidade = transferenciaDto.produto.quantidade,
                        Lote = transferenciaDto.produto.lote,
                        DataF = transferenciaDto.produto.dataf,
                        SemF = transferenciaDto.produto.semf,
                        DataL = transferenciaDto.dataEntrada,
                        Obs = transferenciaDto.observacao
                    };
                    CacheMP.Instance.Db.Estoque.Add(novoEstoque);
                    CacheMP.Instance.Db.SaveChanges();
                    estoqueExistente = novoEstoque; 
                }

                var movimentacao = new Movimentacao
                {
                    EstoqueId = estoqueExistente.EstoqueId,
                    ProdutoId = transferenciaDto.produto.produtoId,
                    Tipo = transferenciaDto.tipo,
                    Quantidade = transferenciaDto.produto.quantidade,
                    Obs = transferenciaDto.observacao + $" | S: {transferenciaDto.endOld} -> P: {endereco.EnderecoId} ",
                    UserId = transferenciaDto.userId,
                    DataF = transferenciaDto.produto.dataf,
                    SemF = transferenciaDto.produto.semf,
                    Lote = transferenciaDto.produto.lote,
                    Endereco = endereco.EnderecoId,
                    DataL = transferenciaDto.dataEntrada


                };
                CacheMP.Instance.Db.Movimentacoes.Add(movimentacao);
                CacheMP.Instance.Db.SaveChanges();


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
