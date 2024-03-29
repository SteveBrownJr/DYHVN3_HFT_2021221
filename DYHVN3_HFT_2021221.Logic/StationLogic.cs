﻿using DYHVN3_HFT_2021221.Models;
using DYHVN3_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Logic
{
    public class StationLogic : IStationLogic
    {
        IStationRepository StationRepo;
        ILocomotiveRepository LocomotiveRepo;
        IWagonRepository WagonRepo;
        public StationLogic(IStationRepository StationRepo, ILocomotiveRepository LocomotiveRepo, IWagonRepository WagonRepo)
        {
            this.StationRepo = StationRepo;
            this.LocomotiveRepo = LocomotiveRepo;
            this.WagonRepo = WagonRepo;
        }

        public void Create(Station Station)
        {
            if (Station.Locomotive_Id==0||Station.x_cordinate==0||Station.y_cordinate==0)
            {
                throw new ArgumentOutOfRangeException();
            }
            StationRepo.Create(Station);
        }

        public Station Read(int id)
        {
            Station s = StationRepo.Read(id);
            if (s==null)
                throw new IndexOutOfRangeException();
            return StationRepo.Read(id);
        }

        public IEnumerable<Station> ReadAll()
        {
            IEnumerable<Station> returnvalue = StationRepo.GetAll();
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
                StationRepo.Delete(id);
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public void Update(Station s)
        {
            if (s.Name.Length<3||s.x_cordinate==0||s.y_cordinate==0||s.Locomotive_Id==0)
            {
                throw new ArgumentOutOfRangeException();
            }
            StationRepo.Update(s);
        }
        //noncrud
        public double DistanceBetweenTwoStation(int sid1, int sid2)
        {
            Station s1 = Read(sid1);
            Station s2 = Read(sid2);
            return Math.Sqrt(Math.Pow((s1.x_cordinate - s2.x_cordinate), 2) + Math.Pow((s1.y_cordinate - s2.y_cordinate), 2));
        }

        public Locomotive TouchingLocomotive(int sid) 
        {
            Station s = Read(sid);

            return LocomotiveRepo.Read(s.Locomotive_Id);
        }
        public IEnumerable<Wagon> TouchingWagons(int sid)
        {
            Station s = Read(sid);
            return WagonRepo.GetAll().Where(wagon=>(wagon.Locomotive_Id==s.Locomotive_Id));
        }

        public double MovedQuantity(int sid)
        {
            Station s = Read(sid);
            return s.locomotive.load;
        }
        public IEnumerable<Cargo_Type> MovedCargoTypes(int sid)
        {
            Station s = Read(sid);
            return s.locomotive.Wagons.Select(wagon => wagon.CargoType).Distinct();
        }
    }
}
