using DocumentFormat.OpenXml.Spreadsheet;
using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.View.Modal;
using Microsoft.EntityFrameworkCore;
using MapaEstoqueCD.Database.Common;

namespace MapaEstoqueCD.Services
{
    public class ProdutoService
    {
        private readonly AppDbContext _db;

        public ProdutoService()
        {
            _db = CacheMP.Instance.Db;
        }

        public List<Produtos> ListarTodos()
        {
            return _db.Produtos.AsNoTracking().ToList();
        }

        public List<Produtos> Filtrar(string coluna, string termo, bool exato)
        {
            termo = termo.ToLower();
            var query = _db.Produtos.AsQueryable();

            switch (coluna)
            {
                case "Descrição":
                    query = exato ? query.Where(p => p.Descricao.ToLower() == termo)
                                  : query.Where(p => p.Descricao.ToLower().Contains(termo));
                    break;
                case "Código":
                    query = exato ? query.Where(p => p.Cod.ToLower() == termo)
                                  : query.Where(p => p.Cod.ToLower().Contains(termo));
                    break;
                case "codigo_barras_ean13":
                    query = exato ? query.Where(p => p.CodigoBarrasEan13.ToLower() == termo)
                                  : query.Where(p => p.CodigoBarrasEan13.ToLower().Contains(termo));
                    break;
                case "codigo_barras_dun13":
                    query = exato ? query.Where(p => p.CodigoBarrasDun13.ToLower() == termo)
                                  : query.Where(p => p.Descricao.ToLower().Contains(termo));
                    break;
                case "codigo_barras_dun14":
                    query = exato ? query.Where(p => p.CodigoBarrasDun14.ToLower() == termo)
                                  : query.Where(p => p.CodigoBarrasDun14.ToLower().Contains(termo));
                    break;
            }

            return query.ToList();
        }

        public void Adicionar(Produtos p)
        {
            _db.Produtos.Add(p);
            _db.SaveChanges();
        }

        public void Atualizar(Produtos p)
        {
            _db.Produtos.Update(p);
            _db.SaveChanges();
        }

        public void Remover(Produtos p)
        {
            _db.Produtos.Remove(p);
            _db.SaveChanges();
        }

        public Produtos? ObterPorId(int id)
        {
            return _db.Produtos.Find(id);
        }

        public bool ExisteCodigo(string codigo)
        {
            return _db.Produtos.Any(p => p.Cod == codigo);
        }

        public List<Produtos> GetProdutosByFilter(List<FiltroItem> filtroItems)
        {
            var query = QueryGeneric.FiltrarQuery<Produtos>(filtroItems);

            return query.ToList();
        }
    }
}
