using NUnit.Framework;
using System;
using DYHVN3_HFT_2021221.Logic;
using DYHVN3_HFT_2021221.Repository;
using DYHVN3_HFT_2021221.Data;
using Moq;
using DYHVN3_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

namespace DYHVN3_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        
        DistributorLogic dfl;
        
        [SetUp]
        public void Init()
        {
            
            var mockDistributorRepository = new Mock<IDistributorRepository>();
            Distributor fakeDistributor = new Distributor();
            
            fakeDistributor.Distributor_Id = 1;
            fakeDistributor.EmployeeNumber = (new Random()).Next();
            fakeDistributor.Country = "Hungary";
            fakeDistributor.Name = "TestDistributor";

            Manufacturer fakeAMDManufacturer = new Manufacturer();
            Manufacturer fakeIntelManufacturer = new Manufacturer();
            var fakeIntelModells = new List<Modell>()
            {
                new Modell()
                {
                    ClockSpeed=2600,
                    Cores=2,
                    Name="i6",
                    HyperThreading=false,
                    Family="Intel",
                    Manufacturer=fakeIntelManufacturer,
                    Modell_Id=1,
                    Value=600
                },
                new Modell()
                {
                    ClockSpeed=3600,
                    Cores=6,
                    Name="i8",
                    HyperThreading=true,
                    Family="Intel",
                    Manufacturer=fakeIntelManufacturer,
                    Modell_Id=2,
                    Value=900
                }
            };
            var fakeAMDModells = new List<Modell>(){
                new Modell()
                {
                    ClockSpeed = 2700,
                    Cores = 3,
                    Name = "r6",
                    HyperThreading = false,
                    Family = "AMD",
                    Manufacturer = fakeAMDManufacturer,
                    Modell_Id = 3,
                    Value = 500
                },
                new Modell()
                {
                    ClockSpeed = 3600,
                    Cores = 8,
                    Name = "r8",
                    HyperThreading = true,
                    Family = "AMD",
                    Manufacturer = fakeAMDManufacturer,
                    Modell_Id = 4,
                    Value = 800
                }
            };
            fakeAMDManufacturer.Modells = fakeAMDModells;
            fakeIntelManufacturer.Modells = fakeIntelModells;
            fakeAMDManufacturer.Name = "AMD";
            fakeIntelManufacturer.Name = "Intel";
            fakeAMDManufacturer.Distributor = fakeDistributor;
            fakeIntelManufacturer.Distributor = fakeDistributor;
            fakeAMDManufacturer.DistributorId = 1;
            fakeIntelManufacturer.DistributorId = 1;
            fakeIntelManufacturer.colour = "green";
            fakeAMDManufacturer.colour = "orange";
            fakeIntelManufacturer.EmployeeNumber = 20000;
            fakeAMDManufacturer.EmployeeNumber = 5000;
            fakeDistributor.Manufacturers.Add(fakeIntelManufacturer);
            fakeDistributor.Manufacturers.Add(fakeAMDManufacturer);
            var fakeDistributorList = new List<Distributor>();
            fakeDistributorList.Add(fakeDistributor);
            mockDistributorRepository.Setup((t) => t.GetAll()).Returns(fakeDistributorList.AsQueryable);
            dfl = new DistributorLogic(mockDistributorRepository.Object);
        }
        [Test]
        public void Test1()
        {
           
        }
        [Test]
        public void Test2()
        {

        }
        [Test]
        public void Test3()
        {
            
        }
        [Test]
        public void Test5()
        {
        
        }
    }
}