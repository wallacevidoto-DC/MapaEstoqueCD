using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Models;

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
                };
                CacheMP.Instance.Db.Entradas.Add(novaEntrada);
                //CacheMP.Instance.Db.SaveChanges();

                var movimentacao = new Movimentacao
                {
                    ProdutoId = entradaLvDto.produto.ProdutoId,
                    Tipo = entradaLvDto.tipo,
                    Quantidade = entradaLvDto.qtd_conferida,
                    UserId = entradaLvDto.userId,
                    DataL = DateTime.Now,


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
