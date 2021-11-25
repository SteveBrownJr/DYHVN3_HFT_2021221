using DYHVN3_HFT_2021221.Data;
using DYHVN3_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Repository
{
    class StationRepository : IStationRepository
    {
        TrainDbContext db = new TrainDbContext();
        public StationRepository(TrainDbContext db)
        {
            this.db = db;
        }

        public void Create(Station Station)
        {
            db.Stations.Add(Station);
            db.SaveChanges();
        }

        public Station Read(int id)
        {
            return db.Stations.FirstOrDefault(t => t.Station_Id == id);
        }

        public IQueryable<Station> GetAll()
        {
            return db.Stations;
        }

        public void Delete(int id)
        {
            var StationToDelete = Read(id);
            db.Stations.Remove(StationToDelete);
            db.SaveChanges();
        }
        public void Update(Station Station)
        {
            var StationToUpdate = Read(Station.Locomotive_Id);
            StationToUpdate.Name = Station.Name;
            StationToUpdate.Locomotive_Id = Station.Locomotive_Id;
            StationToUpdate.x_cordinate = Station.x_cordinate;
            StationToUpdate.y_cordinate = Station.y_cordinate;
            db.SaveChanges();
        }
    }
}
