using DYHVN3_HFT_2021221.Models;
using System.Linq;

namespace DYHVN3_HFT_2021221.Repository
{
    public interface IStationRepository
    {
        void Create(Station Station);
        void Delete(int id);
        IQueryable<Station> GetAll();
        Station Read(int id);
        void Update(Station Station);
    }
}