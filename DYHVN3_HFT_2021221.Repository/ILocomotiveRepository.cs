using DYHVN3_HFT_2021221.Models;
using System.Linq;

namespace DYHVN3_HFT_2021221.Repository
{
    public interface ILocomotiveRepository
    {
        void Create(Locomotive Locomotive);
        void Delete(int id);
        IQueryable<Locomotive> GetAll();
        Locomotive Read(int id);
        void Update(Locomotive Locomotive);
    }
}