using DYHVN3_HFT_2021221.Data;
using DYHVN3_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Repository
{
    class RAMRepository : IRAMRepository
    {
        PCDbContext db;
        public RAMRepository(PCDbContext db)
        {
            this.db = db;
        }
        public void Create(RAM ram)
        {
            db.RAMs.Add(ram);
            db.SaveChanges();
        }
        public RAM Read(int id)
        {
            return db.RAMs.FirstOrDefault(x => x.Id == id);
        }
        public IQueryable<RAM> GetAll()
        {
            return db.RAMs;
        }
        public void Delete(int id)
        {
            var RAMToDelete = Read(id);
            db.RAMs.Remove(RAMToDelete);
            db.SaveChanges();
        }

        public void Update(RAM ram)
        {
            var RAMToUpdate = Read(ram.Id);
            RAMToUpdate.Brand = ram.Brand;
            RAMToUpdate.Clock = ram.Clock;
            RAMToUpdate.Latency = ram.Latency;
            RAMToUpdate.Model = ram.Model;
            RAMToUpdate.Slot = ram.Slot;
            RAMToUpdate.Storage = ram.Storage;
            db.SaveChanges();
        }
    }
}
