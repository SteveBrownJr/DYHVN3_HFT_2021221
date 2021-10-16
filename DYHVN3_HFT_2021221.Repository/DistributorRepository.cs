using DYHVN3_HFT_2021221.Data;
using DYHVN3_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Repository
{
    class DistributorRepository : IDistributorRepository
    {
        PCDbContext db;
        public DistributorRepository(PCDbContext db)
        {
            this.db = db;
        }

        public void Create(Distributor Distributor)
        {
            db.Distributors.Add(Distributor);
            db.SaveChanges();
        }

        public Distributor Read(int id)
        {
            return
                db.Distributors.FirstOrDefault(t => t.Distributor_Id == id);
        }

        public IQueryable<Distributor> GetAll()
        {
            return db.Distributors;
        }

        public void Delete(int id)
        {
            var DistributorToDelete = Read(id);
            db.Distributors.Remove(DistributorToDelete);
            db.SaveChanges();
        }

        public void Update(Distributor Distributor)
        {
            var DistributorToUpdate = Read(Distributor.Distributor_Id);
            DistributorToUpdate.Country = Distributor.Country;
            DistributorToUpdate.Name = Distributor.Name;

            db.SaveChanges();
        }
    }
}
