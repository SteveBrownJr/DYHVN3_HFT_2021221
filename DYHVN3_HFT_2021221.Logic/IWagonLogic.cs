using DYHVN3_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

namespace DYHVN3_HFT_2021221.Logic
{
    public interface IWagonLogic
    {
        double AvarageStartingTorqueForTheWagon(Wagon w);
        void Create(Wagon Wagon);
        void Delete(int id);
        Wagon HeviestWagon();
        ICollection<Wagon> LongestTrain();
        Cargo_Type MostCommonCargoType();
        Wagon Read(int id);
        IQueryable<Wagon> ReadAll();
        void Update(Wagon w);
    }
}