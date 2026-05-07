using MapaEstoqueCD.Database;
using MapaEstoqueCD.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MapaEstoqueCD.Services
{
    public class CifsService
    {
        private readonly AppDbContext _db;

        public CifsService()
        {
            _db = new AppDbContext();
        }

        public List<Cifs> ListarTodos()
        {
            return _db.Cifs.OrderByDescending(c => c.CifId).ToList();
        }

        public void Salvar(Cifs cif)
        {
            if (cif.CifId == 0)
            {
                cif.CreateAt = DateTime.Now;
                cif.UpdateAt = DateTime.Now;
                _db.Cifs.Add(cif);
            }
            else
            {
                cif.UpdateAt = DateTime.Now;
                _db.Entry(cif).State = EntityState.Modified;
            }
            _db.SaveChanges();
        }

        public Cifs ObterUltimoCif()
        {
            return _db.Cifs.OrderByDescending(c => c.CifId).FirstOrDefault();
        }

        public Cifs ObterPorId(int id)
        {
            return _db.Cifs.Find(id);
        }

        public bool ExisteCif(string cod, int idExcluir = 0)
        {
            return _db.Cifs.Any(c => c.CifCod == cod && c.CifId != idExcluir);
        }
    }
}
