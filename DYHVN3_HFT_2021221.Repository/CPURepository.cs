using DYHVN3_HFT_2021221.Data;
using DYHVN3_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Repository
{
    class CPURepository : ICPURepository
    {
        PCDbContext db;
        public CPURepository(PCDbContext db)
        {
            this.db = db;
        }
        public void Create(CPU cpu)
        {
            db.CPUs.Add(cpu);
            db.SaveChanges();
        }
        public CPU Read(int id)
        {
            return db.CPUs.FirstOrDefault(x => x.Id == id);
        }
        public IQueryable<CPU> GetAll()
        {
            return db.CPUs;
        }
        public void Delete(int id)
        {
            var CPUToDelete = Read(id);
            db.CPUs.Remove(CPUToDelete);
            db.SaveChanges();
        }

        public void Update(CPU cpu)
        {
            var CPUToUpdate = Read(cpu.Id);
            CPUToUpdate.Brand = cpu.Brand;
            CPUToUpdate.Clock = cpu.Clock;
            CPUToUpdate.Cores = cpu.Cores;
            CPUToUpdate.FSB = cpu.FSB;
            CPUToUpdate.Model = cpu.Model;
            CPUToUpdate.Socket = cpu.Socket;



            db.SaveChanges();
        }
    }
}
