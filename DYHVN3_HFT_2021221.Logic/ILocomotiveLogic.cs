using DYHVN3_HFT_2021221.Models;
using System.Collections.Generic;

namespace DYHVN3_HFT_2021221.Logic
{
    public interface ILocomotiveLogic
    {
        void Create(Locomotive locomotive);
        void Delete(int id);
        Locomotive FastestAcceleratingTrain();
        Locomotive LongestTrain();
        Locomotive MostPowerFulLocomotive();
        Locomotive Read(int id);
        IEnumerable<Locomotive> ReadAll();
        IEnumerable<Station> Route(int id);
        IEnumerable<Station> TouchedStations(int id);
        void Update(Locomotive l);
        Locomotive WeakestLocomotive();
    }
}