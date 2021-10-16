using DYHVN3_HFT_2021221.Data;
using DYHVN3_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Repository
{
    class ModelRepository : IModelRepository
    {
        PCDbContext db;
        public ModelRepository(PCDbContext db)
        {
            this.db = db;
        }

        public void Create(Modell model)
        {
            db.Modells.Add(model);
            db.SaveChanges();
        }

        public Modell Read(int id)
        {
            return
                db.Modells.FirstOrDefault(t => t.Modell_Id == id);
        }

        public IQueryable<Modell> GetAll()
        {
            return db.Modells;
        }

        public void Delete(int id)
        {
            var modellToDelete = Read(id);
            db.Modells.Remove(modellToDelete);
            db.SaveChanges();
        }

        public void Update(Modell modell)
        {
            var modellToUpdate = Read(modell.Modell_Id);
            modellToUpdate.ClockSpeed = modell.ClockSpeed;
            modellToUpdate.Cores = modell.Cores;
            modellToUpdate.Family = modell.Family;
            modellToUpdate.HyperThreading = modell.HyperThreading;
            modellToUpdate.Name = modellToUpdate.Name;
            db.SaveChanges();
        }

    }
}
