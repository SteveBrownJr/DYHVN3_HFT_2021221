using DYHVN3_HFT_2021221.Data;
using DYHVN3_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Repository
{
    public class WagonRepository : IWagonRepository
    {
        TrainDbContext db;
        public WagonRepository(TrainDbContext db)
        {
            this.db = db;
        }

        public void Create(Wagon Wagon)
        {
            db.Wagons.Add(Wagon);
            db.SaveChanges();
        }

        public Wagon Read(int id)
        {
            return db.Wagons.FirstOrDefault(t => t.Wagon_Id == id);
        }

        public IQueryable<Wagon> GetAll()
        {
            return db.Wagons;
        }

        public void Delete(int id)
        {
            var WagonToDelete = Read(id);
            db.Wagons.Remove(WagonToDelete);
            db.SaveChanges();
        }
        public void Update(Wagon Wagon)
        {
            var WagonToUpdate = Read(Wagon.Wagon_Id);
            WagonToUpdate.Locomotive_Id = Wagon.Locomotive_Id;
            db.SaveChanges();
        }
    }
}
