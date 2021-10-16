using DYHVN3_HFT_2021221.Data;
using DYHVN3_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Repository
{
    class MotherboardRepository
    {
        PCDbContext db;
        public MotherboardRepository(PCDbContext db)
        {
            this.db = db;
        }
        public void Create(Motherboard motherboard)
        {
            db.Motherboards.Add(motherboard);
            db.SaveChanges();
        }
        public Motherboard Read(int id)
        {
            return db.Motherboards.FirstOrDefault(x => x.Id == id);
        }
        public IQueryable<Motherboard> GetAll()
        {
            return db.Motherboards;
        }
        public void Delete(int id)
        {
            var motherboardToDelete = Read(id);
            db.Motherboards.Remove(motherboardToDelete);
            db.SaveChanges();
        }

        public void Update(Motherboard motherboard)
        {
            var motherboardToUpdate = Read(motherboard.Id);
            motherboardToUpdate.Name = motherboard.Name;



            db.SaveChanges();
        }
    }
}
