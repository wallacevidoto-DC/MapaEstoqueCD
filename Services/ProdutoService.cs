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
                    query = exato ? query.Where(p => p.Codigo.ToLower() == termo)
                                  : query.Where(p => p.Codigo.ToLower().Contains(termo));
                    break;
                case "codigo_barras_ean13":
                    query = exato ? query.Where(p => p.UCodigoBarras.ToLower() == termo)
                                  : query.Where(p => p.UCodigoBarras.ToLower().Contains(termo));
                    break;
                case "codigo_barras_dun13":
                    query = exato ? query.Where(p => p.DCodigoBarras.ToLower() == termo)
                                  : query.Where(p => p.DCodigoBarras.ToLower().Contains(termo));
                    break;
                case "codigo_barras_dun14":
                    query = exato ? query.Where(p => p.CCodigoBarras.ToLower() == termo)
                                  : query.Where(p => p.CCodigoBarras.ToLower().Contains(termo));
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
            var local = _db.Produtos.Local.FirstOrDefault(x => x.ProdutoId == p.ProdutoId);
            if (local != null)
            {
                _db.Entry(local).State = EntityState.Detached; 
            }

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

        public Produtos? ObterPorCod(string cod)
        {
            return _db.Produtos.First(p => p.Codigo == cod);
        }

        public bool ExisteCodigo(string codigo)
        {
            return _db.Produtos.Any(p => p.Codigo == codigo);
        }

        public List<Produtos> GetProdutosByFilter(List<FiltroItem> filtroItems)
        {
            var query = QueryGeneric.FiltrarQuery<Produtos>(filtroItems);

            return query.ToList();
        }
    }
}
