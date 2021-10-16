using DYHVN3_HFT_2021221.Models;
using System.Linq;

namespace DYHVN3_HFT_2021221.Repository
{
    interface IMotherboardRepository
    {
        void Create(Motherboard motherboard);
        void Delete(int id);
        IQueryable<Motherboard> GetAll();
        Motherboard Read(int id);
        void Update(Motherboard motherboard);
    }
}