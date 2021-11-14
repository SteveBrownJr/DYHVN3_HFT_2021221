using DYHVN3_HFT_2021221.Models;
using DYHVN3_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Logic
{
    class ManufacturerLogic
    {
        IManufacturerRepository ManufacturerRepo;
        public ManufacturerLogic(IManufacturerRepository ManufacturerRepo)
        {
            this.ManufacturerRepo = ManufacturerRepo;
        }
        public void Create(Manufacturer Manufacturer)
        {
            if (Manufacturer.Name == null)
                throw new ArgumentNullException("The Manufacturer's name can't be null.");
            if (Manufacturer.colour == null)
                throw new ArgumentNullException("The Manufacturer's name can't be null.");
            ManufacturerRepo.Create(Manufacturer);

        }
        public Manufacturer Read(int id)
        {
            return ManufacturerRepo.Read(id);
        }
        public Manufacturer ReadOrDefault(int id = 1)
        {
            return ManufacturerRepo.Read(id);
        }
        public IEnumerable<Manufacturer> ReadAll()
        {
            if (ManufacturerRepo.GetAll().Count() == 0)
            {
                throw new ArgumentOutOfRangeException("Database isn't contains any Manufacturer");
            }
            return ManufacturerRepo.GetAll();
        }
        public void Delete(int id)
        {
            ManufacturerRepo.Delete(id);
        }
        public void Update(Manufacturer d)
        {
            ManufacturerRepo.Update(d);
        }
        //non-crud methods
        public Manufacturer BestManufacturer(){//Best manufacturer is which has the best processor speed/value rate
            return ManufacturerRepo.GetAll().Select(t => t.Modells.OrderByDescending(t=>relativeSpeed(t)/t.Value).FirstOrDefault()).FirstOrDefault().Manufacturer;
            }
        private int relativeSpeed(Modell m)
        {
            if (m.HyperThreading)
                return m.ClockSpeed * m.Cores * 2;
            return m.Cores * m.ClockSpeed;
        }
        public double AVGNumberOfEmployees()
        {
            return ManufacturerRepo.GetAll().Average(t => t.EmployeeNumber);
        }
        public int NumberOfEmployees(int id)
        {
            return ManufacturerRepo.Read(id).EmployeeNumber;
        }
        public int GetIdFromName(string name)
        {
            return ManufacturerRepo.GetAll().FirstOrDefault(t => t.Name == name).DistributorId;
        }
    }
}
