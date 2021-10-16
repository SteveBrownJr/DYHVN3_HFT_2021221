using DYHVN3_HFT_2021221.Models;
using System.Linq;

namespace DYHVN3_HFT_2021221.Repository
{
    interface IRAMRepository
    {
        void Create(RAM ram);
        void Delete(int id);
        IQueryable<RAM> GetAll();
        RAM Read(int id);
        void Update(RAM ram);
    }
}