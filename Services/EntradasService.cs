using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Common;
using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;
using System.Data.Entity;

namespace MapaEstoqueCD.Services
{
    public class EntradasService
    {
        public bool SetEntradaLivre(EntradaLvDto entradaLvDto)
        {
            using var db = ContextFactory.CreateDb();
            using var transaction = db.Database.BeginTransaction();

            try
            {
                var novaEntrada = new Entradas
                {
                    ProdutoId = entradaLvDto.produto.ProdutoId,
                    Tipo = entradaLvDto.tipo,
                    QtdConferida = entradaLvDto.qtd_conferida,
                    UserId = entradaLvDto.userId,
                    DataF = entradaLvDto.dataf,
                    SemF = entradaLvDto.semf,
                    Lote = entradaLvDto.lote,

                };
                db.Entradas.Add(novaEntrada);

                var movimentacao = new Movimentacao
                {
                    ProdutoId = entradaLvDto.produto.ProdutoId,
                    Tipo = entradaLvDto.tipo,
                    Quantidade = entradaLvDto.qtd_conferida,
                    UserId = entradaLvDto.userId,
                    DataL = DateTime.Now,
                    DataF = entradaLvDto.dataf,
                    SemF = entradaLvDto.semf,
                    Lote = entradaLvDto.lote,
                    Obs = entradaLvDto.obs,

                };
                db.Movimentacoes.Add(movimentacao);

                db.SaveChanges();

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

        public List<EntradasViewerDto> GetAllEntradas()
        {
            using var db = ContextFactory.CreateDb();
            return db.Entradas
                .Include(e => e.User)
                .Include(e => e.Produto)
                .Include(e => e.Cifs)
                .Where(e => e.IsConf == false)
                .Select(e => new EntradasViewerDto
                {
                    EntradaId = e.EntradaId,
                    Tipo = e.Tipo,
                    ProdutoId = e.ProdutoId,
                    UserNome = e.User != null ? e.User.Name : null,
                    ProdutoCodigo = e.Produto != null ? e.Produto.Codigo : null,
                    ProdutoDescricao = e.Produto != null ? e.Produto.Descricao : null,
                    QtdConferida = e.QtdConferida,
                    QtdEntrada = e.QtdEntrada,
                    Lote = e.Lote,
                    DataF = e.DataF,
                    SemF = e.SemF,
                    CreateAt = e.CreateAt,
                    UpdateAt = e.UpdateAt
                }).OrderBy(x => x.CreateAt)
                .ToList();
        }

        public void SetEntradaLivreConferida(EntradasViewerDto entradaSelecionado)
        {
            using var db = ContextFactory.CreateDb();
            Entradas model = db.Entradas.FirstOrDefault(x => x.EntradaId == entradaSelecionado.EntradaId);
            if (model != null)
            {
                model.IsConf = true;
                db.SaveChanges();
            }
        }
        public bool SetEntradaLivreConferida(int id, int qtd)
        {
            try
            {
                using var db = ContextFactory.CreateDb();
                var model = db.Entradas.FirstOrDefault(x => x.EntradaId == id);



                if (model == null && model.Produto == null)
                {
                    throw new Exception("Id do picking não foi passado");
                }

                model.QtdConferida -= qtd;
                model.IsConf = model.QtdConferida <= 0 ? true : false;

                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetErro(((id, qtd)));
                return false;
            }


        }

        public bool SetCorrecaoEntrada(CorrecaoEntradaDto correcaoDto)
        {
            using var db = ContextFactory.CreateDb();
            using var transaction = db.Database.BeginTransaction();

            try
            {
                var entradaExistente = db.Entradas.Include(X => X.Produto).FirstOrDefault(e => e.EntradaId == correcaoDto.conferenciaId);

                if (entradaExistente == null)
                    throw new Exception($"Estoque não encontrado.");

                string Obs = $"Correção: (Q:{entradaExistente.QtdConferida} - DF:{DataFormatter.FormatarData(entradaExistente.DataF)} - SF:{entradaExistente.SemF} - LT:{entradaExistente.Lote} )";

                entradaExistente.QtdConferida = correcaoDto.qtd_conferida;
                entradaExistente.Lote = correcaoDto.lote;
                entradaExistente.DataF = correcaoDto.dataf.Replace(" ", "");
                entradaExistente.SemF = correcaoDto.semf;

                db.Entradas.Update(entradaExistente);
                db.SaveChanges();


                var movimentacao = new Movimentacao
                {
                    ProdutoId = entradaExistente.Produto.ProdutoId,
                    Tipo = correcaoDto.tipo,
                    Quantidade = correcaoDto.qtd_conferida,
                    Obs = Obs,
                    UserId = correcaoDto.userId,
                    DataF = correcaoDto.dataf.Replace(" ", ""),
                    SemF = correcaoDto.semf,
                    Lote = correcaoDto.lote,
                    DataL = DateTime.Now


                };
                db.Movimentacoes.Add(movimentacao);
                db.SaveChanges();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
                return false;
            }
        }

        public void RemoveConferencia(EntradasViewerDto remove)
        {
            try
            {
                using var db = ContextFactory.CreateDb();

                var temp = db.Entradas.FirstOrDefault(c => c.EntradaId == remove.EntradaId);

                if (temp == null) { throw new Exception("Conferencia não existe."); }

                db.Entradas.Remove(temp);


                var movimentacao = new Movimentacao
                {
                    ProdutoId = temp.Produto.ProdutoId,
                    Tipo = "RM. CONFERÊNCIA",
                    Quantidade = (int)temp.QtdConferida,
                    UserId = CacheMP.Instance.UserCurrent.UserId,
                    DataL = (DateTime)temp.CreateAt,
                    DataF = temp.DataF,
                    SemF = temp.SemF,
                    Lote = temp.Lote,
                    Obs = "REMOVIDO",

                };
                db.Movimentacoes.Add(movimentacao);

                db.SaveChanges();

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
