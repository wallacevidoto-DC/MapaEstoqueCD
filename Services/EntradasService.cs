using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;
using System.Data.Entity;

namespace MapaEstoqueCD.Services
{
    public class EntradasService
    {
        public bool SetEntradaLivre(EntradaLvDto entradaLvDto)
        {
            using var transaction = CacheMP.Instance.Db.Database.BeginTransaction();

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
                CacheMP.Instance.Db.Entradas.Add(novaEntrada);

                var movimentacao = new Movimentacao
                {
                    ProdutoId = entradaLvDto.produto.ProdutoId,
                    Tipo = entradaLvDto.tipo,
                    Quantidade = entradaLvDto.qtd_conferida,
                    UserId = entradaLvDto.userId,
                    DataL = DateTime.Now,
                    DataF= entradaLvDto.dataf,
                    SemF= entradaLvDto.semf,
                    Lote= entradaLvDto.lote,
                    Obs= entradaLvDto.obs,

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

        public List<EntradasViewerDto> GetAllEntradas()
        {
            return CacheMP.Instance.Db.Entradas
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
                })
                .ToList();
        }

        public void SetEntradaLivreConferida(EntradasViewerDto entradaSelecionado)
        {
            Entradas model = CacheMP.Instance.Db.Entradas.FirstOrDefault(x => x.EntradaId == entradaSelecionado.EntradaId);
            if (model != null) {
                model.IsConf = true;
                CacheMP.Instance.Db.SaveChanges();
            }
        }
        public void SetEntradaLivreConferida(int? id)
        {
            if (id is null)
            {
                return;
            }
            Entradas model = CacheMP.Instance.Db.Entradas.FirstOrDefault(x => x.EntradaId == id);
            if (model != null)
            {
                model.IsConf = true;
                CacheMP.Instance.Db.SaveChanges();
            }
        }

        public bool SetCorrecaoEntrada(CorrecaoEntradaDto correcaoDto)
        {
            using var transaction = CacheMP.Instance.Db.Database.BeginTransaction();

            try
            {
                var entradaExistente = CacheMP.Instance.Db.Entradas.Include(X=>X.Produto).FirstOrDefault(e => e.EntradaId == correcaoDto.conferenciaId);

                if (entradaExistente == null)
                    throw new Exception($"Estoque não encontrado.");

                string Obs = $"Correção: (Q:{entradaExistente.QtdConferida} - DF:{DataFormatter.FormatarData(entradaExistente.DataF)} - SF:{entradaExistente.SemF} - LT:{entradaExistente.Lote} )";

                entradaExistente.QtdConferida = correcaoDto.qtd_conferida;
                entradaExistente.Lote = correcaoDto.lote;
                entradaExistente.DataF = correcaoDto.dataf.Replace(" ", "");
                entradaExistente.SemF = correcaoDto.semf;

                CacheMP.Instance.Db.Entradas.Update(entradaExistente);
                CacheMP.Instance.Db.SaveChanges();


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
                    DataL =  DateTime.Now


                };
                CacheMP.Instance.Db.Movimentacoes.Update(movimentacao);
                CacheMP.Instance.Db.SaveChanges();

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
    }
}
