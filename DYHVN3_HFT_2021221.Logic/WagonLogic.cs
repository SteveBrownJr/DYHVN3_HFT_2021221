using DYHVN3_HFT_2021221.Models;
using DYHVN3_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Logic
{
    public class WagonLogic : IWagonLogic
    {
        IWagonRepository WagonRepo;
        ILocomotiveRepository LocomotiveRepo;

        public WagonLogic(IWagonRepository WagonRepo, ILocomotiveRepository LocomotiveRepo)
        {
            this.WagonRepo = WagonRepo;
            this.LocomotiveRepo = LocomotiveRepo;
        }

        public void Create(Wagon Wagon)
        {
            Locomotive l = LocomotiveRepo.GetAll().FirstOrDefault(t=>t.Locomotive_Id==Wagon.Locomotive_Id);
            if (l.load + Wagon.Quantity > l.Starting_Torque * 10)
            {
                throw new Exception("If we connect his wagon to the locomotive, the locomotive will be overloaded");
            }
            l.load += Wagon.Quantity;
            LocomotiveRepo.Update(l);
            WagonRepo.Create(Wagon);
        }

        public Wagon Read(int id)
        {
            return WagonRepo.Read(id);
        }

        public IQueryable<Wagon> ReadAll()
        {
            return WagonRepo.GetAll();
        }

        public void Delete(int id)
        {
            WagonRepo.Delete(id);
        }
        public void Update(Wagon w)
        {
            WagonRepo.Update(w);
        }
        //non-crud
        public Wagon HeviestWagon()
        {
            IQueryable<Wagon> t = ReadAll();
            return t.OrderByDescending(t => t.Quantity).First();
        }//Controllerbe implementálva

        public Cargo_Type MostCommonCargoType()
        {
            return (from x in ReadAll()
                    group x by x.CargoType
                    into g
                    select new
                    {
                        Cargo_Type = g.Key,
                        Count = g.Count()
                    }).OrderByDescending(t => t.Count).First().Cargo_Type;
        }//Controllerbe implementálva
        public double AvarageStartingTorqueForTheWagon(int id)//Controllerbe implementálva
        {
            return WagonRepo.Read(id).locomotive.Starting_Torque / WagonRepo.Read(id).locomotive.Wagons.Count();
        }
    }
}
