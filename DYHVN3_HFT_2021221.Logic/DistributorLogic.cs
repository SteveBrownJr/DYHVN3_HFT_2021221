using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYHVN3_HFT_2021221.Models;
using DYHVN3_HFT_2021221.Repository;

namespace DYHVN3_HFT_2021221.Logic
{
    public class DistributorLogic
    {
        IDistributorRepository distributorRepo;
        public DistributorLogic(IDistributorRepository distributorRepo)
        {
            this.distributorRepo = distributorRepo;
        }
        public void Create(Distributor distributor)
        {
            if (distributor.Name==null)
                throw new ArgumentNullException("The distributor's name can't be null.");
            if (distributor.Country == null)
                throw new ArgumentNullException("The distributor's name can't be null.");
            distributorRepo.Create(distributor);

        }
        public Distributor Read(int id)
        {
            return distributorRepo.Read(id);
        }
        public Distributor ReadOrDefault(int id = 1)
        {
            return distributorRepo.Read(id);
        }
        public IEnumerable<Distributor> ReadAll()
        {
            if (distributorRepo.GetAll().Count()==0)
            {
                throw new ArgumentOutOfRangeException("Database isn't contains any Distributor");
            }
            return distributorRepo.GetAll();
        }
        public void Delete(int id)
        {
            distributorRepo.Delete(id);
        }
        public void Update(Distributor d)
        {
            distributorRepo.Update(d);
        }
        //non-Crud methods
        public string MostCommonCountry()
        {
            return distributorRepo.GetAll().GroupBy(t => t.Country).OrderByDescending(t=>t.Count()).Select(t=>t.Key).ToList()[0];
        }
        public IEnumerable<Manufacturer> Manufacturers(int id)
        {
            return distributorRepo.Read(id).Manufacturers;
        }
        public int NumberOfManufacturers(int id)
        {
            return distributorRepo.Read(id).Manufacturers.Count();
        }
        public int NumberOfEmployees(int id)
        {
            return distributorRepo.Read(id).EmployeeNumber;
        }
        public double AVGNumberOfEmployees()
        {
            return distributorRepo.GetAll().Average(t => t.EmployeeNumber);
        }

    }
}
