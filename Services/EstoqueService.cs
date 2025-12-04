using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Common;
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
        private readonly EntradasService entradasService = new();
        public EstoqueService()
        {

        }
        public List<Estoque> GetAll()
        {
            using var db = ContextFactory.CreateDb();
            return db.Estoque.ToList();
        }


        public List<EstoqueWsDto> GetAllProd()
        {
            using var db = ContextFactory.CreateDb();

            return db.Estoque
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
                    produto = e.Produto == null ? null : new ProdutoSgDto
                    {
                        codigo = e.Produto.Codigo,
                        descricao = e.Produto.Descricao
                    }
                }).OrderBy(e => e.dataL)
                .ToList();
        }

        public List<ProdutoSpDto> GetEnderecoByDetails(string rua, string bloco, string apt)
        {
            using var db = ContextFactory.CreateDb();
            Endereco sprod =db.Enderecos.Include(x => x.Estoque).ThenInclude(x => x.Produto).FirstOrDefault(e => e.Rua == rua && e.Coluna == bloco && e.Palete == apt);

            if (sprod == null)
            {
                return null;
            }

            List<ProdutoSpDto> produtos = sprod.Estoque.Select(est => new ProdutoSpDto
            {
                produtoId = est.Produto.ProdutoId,
                codigo = est.Produto.Codigo,
                descricao = est.Produto.Descricao,
                quantidade = est.Quantidade ?? 0,
                dataf = est.DataF ?? "",
                semf = est.SemF ?? 0,
                lote = est.Lote ?? "",
                propsPST = new()
                {
                    origem = Origem.IN,
                    isModified = false
                }
            }).ToList();
            return produtos;



        }

        internal List<EstoqueWsDto> GetAllEstoque()
        {
            using var db = ContextFactory.CreateDb();
            return db.Estoque
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
                   produto = e.Produto == null ? null : new ProdutoSgDto
                   {
                       codigo = e.Produto.Codigo,
                       descricao = e.Produto.Descricao
                   }
               }).OrderByDescending(e => e.createAt)
               .ToList();
        }

        internal bool SetEntradaOld(EntradaDto entradaDto)
        {
            if (DtoValidator.Validate(entradaDto, out var erros).Any())
            {
                throw new Exception(string.Join("\n", erros.Select(x => "\n" + x.ErrorMessage)));
            }
            using var db = ContextFactory.CreateDb();
            using var transaction =db.Database.BeginTransaction();

            try
            {
                var endereco =db.Enderecos.Local
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
                   db.Enderecos.Add(endereco);
                   db.SaveChanges();
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
                        DataF = p.dataf.Replace(" ", ""),
                        SemF = p.semf,
                        DataL = entradaDto.dataEntrada,
                        Obs = entradaDto.observacao
                    };

                   db.Estoque.Add(novoEstoque);
                   db.SaveChanges();

                    var movimentacao = new Movimentacao
                    {
                        //EstoqueId = novoEstoque.EstoqueId,
                        Estoque = novoEstoque,
                        ProdutoId = p.produtoId,
                        Tipo = entradaDto.tipo,
                        Quantidade = p.quantidade,
                        Obs = entradaDto.observacao,
                        UserId = entradaDto.userId,
                        DataF = p.dataf.Replace(" ", ""),
                        SemF = p.semf,
                        Lote = p.lote,
                        Endereco = endereco.EnderecoId,
                        DataL = entradaDto.dataEntrada


                    };
                   db.Movimentacoes.Add(movimentacao);
               db.SaveChanges();
                }

                transaction.Commit();


                if (entradaDto.entradaId is not null)
                {
                    var entrada =db.Entradas.FirstOrDefault(x => x.EntradaId == entradaDto.entradaId);


                    if (entrada.EntradaId == null && entradaDto.produtos.Count == 1)
                    {
                        throw new Exception("Id do picking não foi passado, ou a quantidade de itens é maios que 1.");
                    }

                    if (!entradasService.SetEntradaLivreConferida(entrada.EntradaId, entradaDto.produtos.FirstOrDefault().quantidade))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ex.GetErro(entradaDto);
                return false;
            }
        }
        public bool SetEntrada(EntradaDto entradaDto)
        {
            if (DtoValidator.Validate(entradaDto, out var erros).Any())
            {
                throw new Exception(string.Join("\n", erros.Select(x => "\n" + x.ErrorMessage)));
            }
            using var db = ContextFactory.CreateDb();
            using var transaction =db.Database.BeginTransaction();

            try
            {
                // CORREÇÃO 1: Busca o endereço diretamente no banco de dados (remover .Local)
                var endereco =db.Enderecos
                    .FirstOrDefault(e =>
                        e.Rua == entradaDto.rua &&
                        e.Coluna == entradaDto.bloco &&
                        e.Palete == entradaDto.apt);

                bool novoEnderecoAdicionado = false;

                if (endereco == null)
                {
                    endereco = new Endereco
                    {
                        Rua = entradaDto.rua,
                        Coluna = entradaDto.bloco,
                        Palete = entradaDto.apt
                    };
                    endereco.GerarEnderecoId();
                   db.Enderecos.Add(endereco);
                    novoEnderecoAdicionado = true;
                }

                // Salva o novo endereço para que ele tenha o ID gerado antes de ser usado no Estoque
                // O SaveChanges aqui só é necessário se um novo Endereco foi adicionado.
                if (novoEnderecoAdicionado)
                {
                   db.SaveChanges();
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
                        DataF = p.dataf.Replace(" ", ""),
                        SemF = p.semf,
                        //CreateAt = DateTime.Now,
                        DataL = entradaDto.dataEntrada,
                        Obs = entradaDto.observacao
                    };

                    //novoEstoque.Endereco = null;
                    //novoEstoque.Produto = null;
                    //novoEstoque.Movimentacoes = null;

                   db.Estoque.Add(novoEstoque);
                    // CORREÇÃO 2: REMOVENDO SaveChanges() DENTRO DO LOOP
                    //db.SaveChanges(); 

                    var movimentacao = new Movimentacao
                    {
                        //EstoqueId = novoEstoque.EstoqueId,
                        Estoque = novoEstoque,
                        ProdutoId = p.produtoId,
                        Tipo = entradaDto.tipo,
                        Quantidade = p.quantidade,
                        Obs = entradaDto.observacao,
                        UserId = entradaDto.userId,
                        DataF = p.dataf.Replace(" ", ""),
                        SemF = p.semf,
                        Lote = p.lote,
                        Endereco = endereco.EnderecoId,
                        DataL = entradaDto.dataEntrada


                    };
                   db.Movimentacoes.Add(movimentacao);
                    // CORREÇÃO 2: REMOVENDO SaveChanges() DENTRO DO LOOP
                    //db.SaveChanges(); 
                }

                // CORREÇÃO 2: CONSOLIDANDO SAVECHANGES após o loop, antes do commit
               db.SaveChanges();

                transaction.Commit();


                if (entradaDto.entradaId is not null)
                {
                    var entrada =db.Entradas.FirstOrDefault(x => x.EntradaId == entradaDto.entradaId);


                    if (entrada == null || entradaDto.produtos.Count != 1) // Alteração da condição para ser mais robusta
                    {
                        throw new Exception("Id do picking não foi passado, ou a quantidade de itens é maior que 1.");
                    }

                    if (!entradasService.SetEntradaLivreConferida(entrada.EntradaId, entradaDto.produtos.FirstOrDefault().quantidade))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ex.GetErro(entradaDto);
                return false;
            }
        }
        public bool SetSaida(SaidaDto saidaDto)
        {
            try
            {

                if (DtoValidator.Validate(saidaDto, out var erros).Any())
                {
                    throw new Exception(string.Join("\n", erros.Select(x => "\n" + x.ErrorMessage)));
                }

                using var db = ContextFactory.CreateDb();
                var estoque =db.Estoque.Include(e => e.Endereco).FirstOrDefault(e => e.EstoqueId == saidaDto.estoqueId);

                if (estoque == null || estoque.Quantidade == null)
                {
                    return false;
                }
                int qtdOld = estoque.Quantidade ?? 0;
                int qtdNew = qtdOld - saidaDto.qtdRetirada;

                estoque.Quantidade = qtdNew < 0 ? 0 : qtdNew;

               db.SaveChanges();

                try
                {


                    string Obs = saidaDto?.observacao ?? "";
                    Obs += $" {(string.IsNullOrEmpty(saidaDto.observacao) ? "" : " | ")}Saída: R-{saidaDto.qtdRetirada} de E-{qtdOld}";

                    if (estoque.Quantidade == 0)
                    {
                        Obs += " | Produto Zerado no Estoque";
                    }
                    estoque =db.Estoque.Include(e => e.Endereco).FirstOrDefault(e => e.EstoqueId == saidaDto.estoqueId);
                    var movimentacao = new Movimentacao
                    {
                        EstoqueId = estoque.EstoqueId,
                        ProdutoId = (int)estoque.ProdutoId,
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
                   db.Movimentacoes.Add(movimentacao);
                   db.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw;
                }
                return true;
            }
            catch (Exception ex)
            {
                ex.GetErro(saidaDto);
                throw;
            }


        }

        public bool SetCorrecaoProduto(CorrecaoDto correcaoDto)
        {
            if (DtoValidator.Validate(correcaoDto, out var erros).Any())
            {
                throw new Exception(string.Join("\n", erros.Select(x => "\n" + x.ErrorMessage)));
            }
            using var db = ContextFactory.CreateDb();
            using var transaction =db.Database.BeginTransaction();

            try
            {
                var estoqueExistente =db.Estoque.FirstOrDefault(e => e.EstoqueId == correcaoDto.estoqueId);

                if (estoqueExistente == null)
                    throw new Exception($"Estoque não encontrado.");

                string Obs = correcaoDto.observacao ?? "";
                Obs += $" {(string.IsNullOrEmpty(correcaoDto.observacao) ? "" : " | ")}Correção: (Q:{estoqueExistente.Quantidade} - DF:{DataFormatter.FormatarData(estoqueExistente.DataF)} - SF:{estoqueExistente.SemF} - LT:{estoqueExistente.Lote} )";

                estoqueExistente.Quantidade = correcaoDto.produto.quantidade;
                estoqueExistente.Lote = correcaoDto.produto.lote;
                estoqueExistente.DataF = correcaoDto.produto.dataf;
                estoqueExistente.SemF = correcaoDto.produto.semf;
                estoqueExistente.Obs = correcaoDto.observacao;

               db.Estoque.Update(estoqueExistente);
               db.SaveChanges();


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
               db.Movimentacoes.Add(movimentacao);
               db.SaveChanges();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ex.GetErro(correcaoDto);
                return false;
            }
        }

        public bool SetTransferencia(TranferenciaDto transferenciaDto)
        {
            if (DtoValidator.Validate(transferenciaDto, out var erros).Any())
            {
                throw new Exception(string.Join("\n", erros.Select(x => "\n" + x.ErrorMessage)));
            }

            using var db = ContextFactory.CreateDb();
            using var transaction = db.Database.BeginTransaction();

            try
            {
                // 🔥 CORREÇÃO 1: Busca endereço somente NO BANCO (não usa .Local)
                var endereco = db.Enderecos
                    .FirstOrDefault(e =>
                        e.Rua == transferenciaDto.rua &&
                        e.Coluna == transferenciaDto.bloco &&
                        e.Palete == transferenciaDto.apt);

                bool novoEnderecoAdicionado = false;

                if (endereco == null)
                {
                    endereco = new Endereco
                    {
                        Rua = transferenciaDto.rua,
                        Coluna = transferenciaDto.bloco,
                        Palete = transferenciaDto.apt
                    };
                    endereco.GerarEnderecoId();
                    db.Enderecos.Add(endereco);
                    novoEnderecoAdicionado = true;
                }

                // 🔥 Somente salva se um novo endereço foi criado
                if (novoEnderecoAdicionado)
                {
                    db.SaveChanges();
                }

                // --------------------- PRODUTO ---------------------

                if (!transferenciaDto.produto.IsValid(out string msg))
                    throw new Exception($"Produto inválido: {transferenciaDto.produto.codigo} — {msg}");

                // 🔥 Busca estoque sem anexos indevidos
                var estoqueExistente = db.Estoque
                    .FirstOrDefault(e => e.EstoqueId == transferenciaDto.estoqueID);

                if (estoqueExistente == null)
                    throw new Exception("Estoque ID não existe");

                // ------------------- TRANSFERÊNCIA -----------------

                // Atualiza o endereço do estoque
                estoqueExistente.EnderecoId = endereco.EnderecoId;

                // Não chama SaveChanges aqui — será consolidado no final


                // ------------------- MOVIMENTAÇÃO -------------------

                var movimentacao = new Movimentacao
                {
                    EstoqueId = estoqueExistente.EstoqueId,
                    ProdutoId = transferenciaDto.produto.produtoId,
                    Tipo = transferenciaDto.tipo,
                    Quantidade = transferenciaDto.produto.quantidade,
                    Obs = transferenciaDto.observacao +
                          $" | S: {transferenciaDto.endOld} -> P: {endereco.EnderecoId}",
                    UserId = transferenciaDto.userId,
                    DataF = transferenciaDto.produto.dataf,
                    SemF = transferenciaDto.produto.semf,
                    Lote = transferenciaDto.produto.lote,
                    Endereco = endereco.EnderecoId,
                    DataL = transferenciaDto.dataEntrada
                };

                db.Movimentacoes.Add(movimentacao);

                // 🔥 SAVECHANGES CONSOLIDADO — apenas 1 vez
                db.SaveChanges();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ex.GetErro(transferenciaDto);
                return false;
            }
        }


        public bool SetPicking(PickingDto pickingDto)
        {
            try
            {
                using var db = ContextFactory.CreateDb();
                if (DtoValidator.Validate(pickingDto, out var erros).Any())
                {
                    throw new Exception(string.Join("\n", erros.Select(x => "\n" + x.ErrorMessage)));
                }

                if (pickingDto.entradaId is not null)
                {

                    var entrada =db.Entradas.FirstOrDefault(x => x.EntradaId == pickingDto.entradaId);


                    if (entrada.EntradaId == null && pickingDto.produtos.Count ==1)
                    {
                        throw new Exception("Id do picking não foi passado, ou a quantidade de itens é maios que 1.");
                    }

                    if (!entradasService.SetEntradaLivreConferida(entrada.EntradaId, pickingDto.produtos.FirstOrDefault().quantidade))
                    {
                        return false;
                    }
                }
                

                foreach (var p in pickingDto.produtos)
                {
                    var movimentacao = new Movimentacao
                    {
                        ProdutoId = p.produtoId,
                        Tipo = pickingDto.tipo,
                        Quantidade = p.quantidade,
                        Obs = pickingDto.observacao,
                        UserId = pickingDto.userId,
                        DataF = p.dataf,
                        SemF = p.semf,
                        Lote = p.lote,
                        DataL = pickingDto.dataEntrada


                    };
                   db.Movimentacoes.Add(movimentacao);
                }
               db.SaveChanges();

                
                return true;
            }
            catch (Exception ex)
            {
                ex.GetErro(pickingDto);
                return false;
            }
        }
    }

    
}
