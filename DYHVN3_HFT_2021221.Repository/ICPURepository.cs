using DYHVN3_HFT_2021221.Models;
using System.Linq;

namespace DYHVN3_HFT_2021221.Repository
{
    interface ICPURepository
    {
        void Create(CPU cpu);
        void Delete(int id);
        IQueryable<CPU> GetAll();
        CPU Read(int id);
        void Update(CPU cpu);
    }
}