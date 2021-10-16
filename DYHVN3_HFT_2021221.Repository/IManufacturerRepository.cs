using DYHVN3_HFT_2021221.Models;
using System.Linq;

namespace DYHVN3_HFT_2021221.Repository
{
    interface IManufacturerRepository
    {
        void Create(Manufacturer manufacturer);
        void Delete(int id);
        IQueryable<Manufacturer> GetAll();
        Manufacturer Read(int id);
        void Update(Manufacturer Manufacturer);
    }
}