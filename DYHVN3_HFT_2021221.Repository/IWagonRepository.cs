using DYHVN3_HFT_2021221.Models;
using System.Linq;

namespace DYHVN3_HFT_2021221.Repository
{
    public interface IWagonRepository
    {
        void Create(Wagon Wagon);
        void Delete(int id);
        IQueryable<Wagon> GetAll();
        Wagon Read(int id);
        void Update(Wagon Wagon);
    }
}