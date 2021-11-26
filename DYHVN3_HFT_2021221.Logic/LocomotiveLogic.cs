using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYHVN3_HFT_2021221.Repository;
using DYHVN3_HFT_2021221.Models;

namespace DYHVN3_HFT_2021221.Logic
{
    public class LocomotiveLogic : ILocomotiveLogic
    {
        ILocomotiveRepository locomotiveRepo;
        IStationRepository StationRepo;
        IWagonRepository WagonRepo;
        public LocomotiveLogic(ILocomotiveRepository locomotiveRepo,IStationRepository StationRepo,IWagonRepository WagonRepo)
        {
            this.locomotiveRepo = locomotiveRepo;
            this.StationRepo = StationRepo;
            this.WagonRepo = WagonRepo;
        }

        public void Create(Locomotive locomotive)
        {
            if (locomotive.Name.Length < 4 || locomotive.Starting_Torque < 20 || locomotive.Type.Length < 4 || locomotive.Staff < 1)
                throw new ArgumentOutOfRangeException();
            locomotive.load = 0;
            locomotiveRepo.Create(locomotive);
            
        }

        public Locomotive Read(int id)
        {
            Locomotive l = locomotiveRepo.Read(id); ;
            if (l == null)
                    throw new IndexOutOfRangeException();
            return l;
        }

        public IEnumerable<Locomotive> ReadAll()
        {
            IEnumerable<Locomotive> returnvalue = locomotiveRepo.GetAll();
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
                locomotiveRepo.Delete(id);
            }
            catch (Exception)
            {
                throw/* new InvalidOperationException("We can't delete a locomotive with wagons and destinations")*/;
            }
        }
        public void Update(Locomotive locomotive)
        {
            if (locomotive.Name.Length < 4 || locomotive.Starting_Torque < 20 || locomotive.Type.Length < 4 || locomotive.Staff < 1)
                throw new ArgumentOutOfRangeException();
            locomotiveRepo.Update(locomotive);
        }

        //non-crud methods
        public IEnumerable<Station> TouchedStations(int id)//Controllerbe implementálva
        {
            return locomotiveRepo.Read(id).Stations;
        }
        public Locomotive LongestTrain()//Controllerbe implementálva
        {
            return locomotiveRepo.GetAll().OrderByDescending(t => t.Wagons.Count).First();
        }
        public Locomotive MostPowerFulLocomotive() //Controllerbe implementálva
        {
            return ReadAll().OrderByDescending(t => t.Starting_Torque).First();
        }
        public Locomotive WeakestLocomotive() //Controllerbe implementálva
        {
            return ReadAll().OrderBy(t => t.Starting_Torque).First();
        }
        public IEnumerable<Station> Route(int id)//Az állomások sorrendben - Controllerbe implementálva
        {
            Locomotive l = locomotiveRepo.Read(id);
            ICollection<Station> stations = l.Stations;
            Station first = stations.OrderBy(s => s.DistanceFrom(new Station() { x_cordinate = 0, y_cordinate = 0 })).First(); //Elso allomas az ami legkozelebb van a 0;0 koordinátához;
            return stations.OrderBy(s => s.DistanceFrom(first));//Az elsőtől való távolságuk növekvő sorrendben
        }
        public Locomotive FastestAcceleratingTrain()//Controllerbe implementálva
        {
            return ReadAll().OrderBy(t => t.load / t.Starting_Torque).First();
        }



    }
}
