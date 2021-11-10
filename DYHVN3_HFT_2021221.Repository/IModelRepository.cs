using DYHVN3_HFT_2021221.Models;
using System.Linq;

namespace DYHVN3_HFT_2021221.Repository
{
    public interface IModelRepository
    {
        void Create(Modell model);
        void Delete(int id);
        IQueryable<Modell> GetAll();
        Modell Read(int id);
        void Update(Modell modell);
    }
}