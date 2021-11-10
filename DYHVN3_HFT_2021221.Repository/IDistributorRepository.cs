using DYHVN3_HFT_2021221.Models;
using System.Linq;

namespace DYHVN3_HFT_2021221.Repository
{
    public interface IDistributorRepository
    {
        void Create(Distributor Distributor);
        void Delete(int id);
        IQueryable<Distributor> GetAll();
        Distributor Read(int id);
        void Update(Distributor Distributor);
    }
}