using DYHVN3_HFT_2021221.Data;
using DYHVN3_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Repository
{
    class LocomotiveRepository : ILocomotiveRepository
    {
        TrainDbContext db = new TrainDbContext();

        public LocomotiveRepository(TrainDbContext db)
        {
            this.db = db;
        }

        public void Create(Locomotive Locomotive)
        {
            db.Locomotives.Add(Locomotive);
            db.SaveChanges();
        }

        public Locomotive Read(int id)
        {
            return db.Locomotives.FirstOrDefault(t => t.Locomotive_Id == id);
        }

        public IQueryable<Locomotive> GetAll()
        {
            return db.Locomotives;
        }

        public void Delete(int id)
        {
            var LocomotiveToDelete = Read(id);
            db.Locomotives.Remove(LocomotiveToDelete);
            db.SaveChanges();
        }
        public void Update(Locomotive Locomotive)
        {
            var LocomotiveToUpdate = Read(Locomotive.Locomotive_Id);
            LocomotiveToUpdate.Name = Locomotive.Name;
            LocomotiveToUpdate.Staff = Locomotive.Staff;
            LocomotiveToUpdate.Starting_Torque = Locomotive.Starting_Torque;
            LocomotiveToUpdate.Type = Locomotive.Type;
            db.SaveChanges();
        }
    }
}
