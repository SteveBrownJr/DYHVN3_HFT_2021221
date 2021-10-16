using DYHVN3_HFT_2021221.Data;
using DYHVN3_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Repository
{
    class ManufacturerRepository : IManufacturerRepository
    {
        PCDbContext db;
        public ManufacturerRepository(PCDbContext db)
        {
            this.db = db;
        }

        public void Create(Manufacturer manufacturer)
        {
            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();
        }

        public Manufacturer Read(int id)
        {
            return
                db.Manufacturers.FirstOrDefault(t => t.Manufacturer_Id == id);
        }

        public IQueryable<Manufacturer> GetAll()
        {
            return db.Manufacturers;
        }

        public void Delete(int id)
        {
            var ManufacturerToDelete = Read(id);
            db.Manufacturers.Remove(ManufacturerToDelete);
            db.SaveChanges();
        }

        public void Update(Manufacturer Manufacturer)
        {
            var ManufacturerToUpdate = Read(Manufacturer.Manufacturer_Id);
            ManufacturerToUpdate.colour = Manufacturer.colour;
            ManufacturerToUpdate.Name = Manufacturer.Name;

            db.SaveChanges();
        }
    }
}
