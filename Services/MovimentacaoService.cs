using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Common;
using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Utils;
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
            using var db = ContextFactory.CreateDb();
            return db.Movimentacoes
              .Include(m => m.User)
              .Include(m => m.Produto)
              .Select(m => new MovimentacaoDto
              {
                  movimentacaoId = m.MovimentacaoId,
                  estoqueId = m.EstoqueId,
                  usuarioNome = m.User != null ? m.User.Name : string.Empty,
                  endereco = m.Endereco,
                  produtoCodigo = m.Produto != null ? m.Produto.Codigo : string.Empty,
                  produtoDescricao = m.Produto != null ? m.Produto.Descricao : string.Empty,
                  tipo = m.Tipo.ToUpper(),
                  dataF  = m.DataF != null? DataFormatter.FormatarMesAno(m.DataF):"",    
                  semF = m.SemF,
                  quantidade = m.Quantidade,
                  lote = m.Lote,
                  obs = m.Obs,
                  createAt = m.CreateAt
              })
              .OrderByDescending(e => e.createAt)
              .ToList();
        }

        public List<MovimentacaoDto> GetAllMovimeByIdEstoque(int estoqueId)
        {
            using var db = ContextFactory.CreateDb();
            return db.Movimentacoes
               .Include(m => m.User)
               .Include(m => m.Produto)
               .Where( x=> x.EstoqueId == estoqueId)
               .Select(m => new MovimentacaoDto
               {
                   movimentacaoId = m.MovimentacaoId,
                   estoqueId = m.EstoqueId,
                   usuarioNome = m.User != null ? m.User.Name : string.Empty,
                   endereco = m.Endereco,
                   produtoCodigo = m.Produto != null ? m.Produto.Codigo : string.Empty,
                   produtoDescricao = m.Produto != null ? m.Produto.Descricao : string.Empty,
                   tipo = m.Tipo.ToUpper(),
                   dataF = m.DataF != null ? DataFormatter.FormatarMesAno(m.DataF) : "",
                   semF = m.SemF,
                   quantidade = m.Quantidade,
                   lote = m.Lote,
                   obs = m.Obs,
                   createAt = m.CreateAt
               })
               .OrderByDescending(e => e.createAt)
               .ToList();
        }
    }
}
