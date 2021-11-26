using DYHVN3_HFT_2021221.Models;
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

        public StationLogic(IStationRepository StationRepo)
        {
            this.StationRepo = StationRepo;
        }

        public void Create(Station Station)
        {
            StationRepo.Create(Station);
        }

        public Station Read(int id)
        {
            return StationRepo.Read(id);
        }

        public IEnumerable<Station> ReadAll()
        {
            return StationRepo.GetAll();
        }

        public void Delete(int id)
        {
            StationRepo.Delete(id);
        }
        public void Update(Station l)
        {
            StationRepo.Update(l);
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
            return s.locomotive;
        }
        public ICollection<Wagon> TouchingWagons(int sid)
        {
            Station s = Read(sid);
            return s.locomotive.Wagons;
        }

        public double MovedQuantity(int sid)
        {
            Station s = Read(sid);
            return s.locomotive.load;
        }
        public IEnumerable<Cargo_Type> MovedCargoTypes(int sid)
        {
            Station s = Read(sid);
            return s.locomotive.Wagons.Select(wagon => wagon.CargoType);
        }
    }
}
