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
            if (Wagon.Locomotive_Id==0||Wagon.Wagon_Id==0)
            {
                throw new ArgumentOutOfRangeException();
            }
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
            Wagon l = WagonRepo.Read(id); ;
            if (l == null)
                throw new IndexOutOfRangeException();
            return l;
        }

        public IEnumerable<Wagon> ReadAll()
        {
            IEnumerable<Wagon> returnvalue = WagonRepo.GetAll();
            if (returnvalue.Count() < 1)
            {
                throw new Exception("No locomotive found");
            }
            return returnvalue;
        }

        public void Delete(int id)
        {
            try
            {
                WagonRepo.Delete(id);
            }
            catch (Exception)
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void Update(Wagon w)
        {
            if (LocomotiveRepo.Read(w.Locomotive_Id).load + w.Quantity > LocomotiveRepo.Read(w.Locomotive_Id).load * 10)
            {
                throw new Exception("If we connect his wagon to the locomotive, the locomotive will be overloaded");
            }
            Locomotive connect = LocomotiveRepo.Read(w.Locomotive_Id);
            connect.load += w.Quantity;
            LocomotiveRepo.Update(connect);

            Locomotive disconnect = LocomotiveRepo.Read(WagonRepo.Read(w.Wagon_Id).Locomotive_Id);
            disconnect.load -= w.Quantity;
            LocomotiveRepo.Update(disconnect);
            if (w.Locomotive_Id==0)
            {
                throw new IndexOutOfRangeException();
            }
            WagonRepo.Update(w);
        }
        //non-crud
        public Wagon HeviestWagon()
        {
            IEnumerable<Wagon> t = ReadAll();
            return t.OrderByDescending(t => t.Quantity).First();
        }

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
        }
        public double AvarageStartingTorqueForTheWagon(int id)
        {
            return WagonRepo.Read(id).locomotive.Starting_Torque / WagonRepo.Read(id).locomotive.Wagons.Count();
        }
    }
}
