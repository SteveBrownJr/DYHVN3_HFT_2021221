using DYHVN3_HFT_2021221.Models;
using DYHVN3_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Logic
{
    class ModellLogic
    {
        IModelRepository ModelRepo;
        public ModellLogic(IModelRepository ModelRepo)
        {
            this.ModelRepo = ModelRepo;
        }
        public void Create(Modell Model)
        {
            if (Model.Name == null)
                throw new ArgumentNullException("The Model's name can't be null.");
            if (Model.Cores == 0)
                throw new ArgumentOutOfRangeException("Core number can't be zero");
            ModelRepo.Create(Model);

        }
        public Modell Read(int id)
        {
            return ModelRepo.Read(id);
        }
        public Modell ReadOrDefault(int id = 1)
        {
            return ModelRepo.Read(id);
        }
        public IEnumerable<Modell> ReadAll()
        {
            if (ModelRepo.GetAll().Count() == 0)
            {
                throw new ArgumentOutOfRangeException("Database isn't contains any Model");
            }
            return ModelRepo.GetAll();
        }
        public void Delete(int id)
        {
            ModelRepo.Delete(id);
        }
        public void Update(Modell d)
        {
            ModelRepo.Update(d);
        }
        //non-crud
        public Modell MostPowerFul()
        {
            return ModelRepo.GetAll().OrderByDescending(t=>relativeSpeed(t)).FirstOrDefault();
        }
        public int relativeSpeed(Modell m)
        {
            if (m.HyperThreading)
                return m.ClockSpeed * m.Cores * 2;
            return m.Cores * m.ClockSpeed;
        }
        public double AVGNumberOfCores()
        {
            return ModelRepo.GetAll().Average(t=> t.Cores);
        }
        public double AVGPrice()
        {
            return ModelRepo.GetAll().Average(t => t.Value);
        }
        public IEnumerable<Modell> AllnonHTCPU()
        {
            return ModelRepo.GetAll().Where(t => t.HyperThreading);
        }



    }
}
