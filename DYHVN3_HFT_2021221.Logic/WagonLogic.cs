﻿using DYHVN3_HFT_2021221.Models;
using DYHVN3_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Logic
{
    public class WagonLogic
    {
        IWagonRepository WagonRepo;

        public WagonLogic(IWagonRepository WagonRepo)
        {
            this.WagonRepo = WagonRepo;
        }

        public void Create(Wagon Wagon)
        {
            Locomotive l = Wagon.locomotive;
            if (l.load+Wagon.Quantity>l.Starting_Torque*10)
            {
                throw new Exception("If we connect his wagon to the locomotive, the locomotive will be overloaded");
            }
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
                    }).OrderByDescending(t=>t.Count).First().Cargo_Type;
        }

        public ICollection<Wagon> LongestTrain()
        {
            return (from x in ReadAll()
                            group x by x.locomotive
            into g select new {
                Locomotive = g.Key,
                Number = g.Count()
            }).OrderByDescending(t=>t.Number).First().Locomotive.Wagons;
        }

        public double AvarageStartingTorqueForTheWagon(Wagon w)
        {
            return w.locomotive.Starting_Torque / w.locomotive.Wagons.Count();
        }
    }
}
