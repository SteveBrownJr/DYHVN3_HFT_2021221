using DYHVN3_HFT_2021221.Models;
using System.Collections.Generic;

namespace DYHVN3_HFT_2021221.Logic
{
    public interface IStationLogic
    {
        void Create(Station Station);
        void Delete(int id);
        double DistanceBetweenTwoStation(int sid1, int sid2);
        IEnumerable<Cargo_Type> MovedCargoTypes(int sid);
        double MovedQuantity(int sid);
        Station Read(int id);
        IEnumerable<Station> ReadAll();
        Locomotive TouchingLocomotive(int sid);
        IEnumerable<Wagon> TouchingWagons(int sid);
        void Update(Station l);
    }
}