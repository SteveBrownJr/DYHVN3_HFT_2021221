using DYHVN3_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

namespace DYHVN3_HFT_2021221.Logic
{
    public interface IWagonLogic
    {
        double AvarageStartingTorqueForTheWagon(int id);
        void Create(Wagon Wagon);
        void Delete(int id);
        Wagon HeviestWagon();
        Cargo_Type MostCommonCargoType();
        Wagon Read(int id);
        IEnumerable<Wagon> ReadAll();
        void Update(Wagon w);
    }
}