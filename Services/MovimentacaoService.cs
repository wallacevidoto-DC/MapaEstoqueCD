using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto;
using Microsoft.EntityFrameworkCore;

namespace MapaEstoqueCD.Services
{
    public class MovimentacaoService
    {


        public MovimentacaoService()
        {
            
        }

        public List<MovimentacaoDto> GetAllMovime()
        {

            return CacheMP.Instance.Db.Movimentacoes
              .Include(m => m.User)
              .Include(m => m.Produto)
              .Select(m => new MovimentacaoDto
              {
                  movimentacaoId = m.MovimentacaoId,
                  estoqueId = m.EstoqueId,
                  usuarioNome = m.User != null ? m.User.Name : string.Empty,
                  produtoCodigo = m.Produto != null ? m.Produto.Codigo : string.Empty,
                  produtoDescricao = m.Produto != null ? m.Produto.Descricao : string.Empty,
                  tipo = m.Tipo.ToUpper(),
                  dataF = m.DataF,
                  semF = m.SemF,
                  quantidade = m.Quantidade,
                  lote = m.Lote,
                  obs = m.Obs,
                  createAt = m.CreateAt
              })
              .OrderBy(e => e.createAt)
              .ToList();
        }
    }
}
