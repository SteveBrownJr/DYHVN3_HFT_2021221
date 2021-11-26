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

        public LocomotiveLogic(ILocomotiveRepository locomotiveRepo)
        {
            this.locomotiveRepo = locomotiveRepo;
        }

        public void Create(Locomotive locomotive)
        {
            locomotive.load = 0;
            locomotiveRepo.Create(locomotive);
        }

        public Locomotive Read(int id)
        {
            return locomotiveRepo.Read(id);
        }

        public IEnumerable<Locomotive> ReadAll()
        {
            return locomotiveRepo.GetAll();
        }

        public void Delete(int id)
        {
            locomotiveRepo.Delete(id);
        }
        public void Update(Locomotive l)
        {
            locomotiveRepo.Update(l);
        }
        //non-crud methods
        public ICollection<Station> TouchedStations(Locomotive l)//Az állomások
        {
            return l.Stations;
        }
        public Locomotive LongestTrain()
        {
            return ReadAll().OrderByDescending(t => t.Wagons.Count).First();
        }
        public Locomotive MostPowerFulLocomotive()
        {
            return ReadAll().OrderByDescending(t => t.Starting_Torque).First();
        }
        public Locomotive WeakestLocomotive()
        {
            return ReadAll().OrderBy(t => t.Starting_Torque).First();
        }
        public IEnumerable<Station> Route(Locomotive l)//Az állomások sorrendben
        {
            ICollection<Station> stations = l.Stations;
            Station first = stations.OrderBy(s => s.DistanceFrom(new Station() { x_cordinate = 0, y_cordinate = 0 })).First(); //Elso allomas az ami legkozelebb van a 0;0 koordinátához;
            return stations.OrderBy(s => s.DistanceFrom(first));//Az elsőtől való távolságuk növekvő sorrendben
        }
        public Locomotive FastestAcceleratingTrain()
        {
            return ReadAll().OrderBy(t => t.load / t.Starting_Torque).First();
        }



    }
}
