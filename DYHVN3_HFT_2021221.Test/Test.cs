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

        ModellLogic mdl;
        List<Modell> FakeModellList;

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
            
            List<Modell> FakeModells = new List<Modell>();
            FakeModells.Add(fakeIntelModells[0]);
            FakeModells.Add(fakeIntelModells[1]);
            FakeModells.Add(fakeAMDModells[0]);
            FakeModells.Add(fakeAMDModells[1]);
            FakeModellList = FakeModells;
            //FakeModells.ForEach(t => Console.WriteLine(t.Modell_Id));
            var mockModellsRepository = new Mock<IModelRepository>();
            mockModellsRepository.Setup((t) => t.GetAll()).Returns(FakeModells.AsQueryable);

            mdl = new ModellLogic(mockModellsRepository.Object);
            dfl = new DistributorLogic(mockDistributorRepository.Object);
        }
        [Test]
        public void Test1()
        {
            dfl.Delete(1);
            Assert.Throws<NullReferenceException>(()=>dfl.Read(1).Equals(null));
            
        }
        [Test]
        public void Test2()
        {
            var q2=mdl.AllnonHTCPU();
            for (int i = 0; i < q2.Count(); i++)
            {
                Console.WriteLine(q2.ElementAt(i).HyperThreading);
            }
            Assert.That((q2.Where(t=>t.HyperThreading).Count())==0);
        }
        [Test]
        public void Test3()
        {
            double q3 = mdl.AVGNumberOfCores();
            double v = 0;
            int i = 0;
            for (i = 0; i < FakeModellList.Count(); i++)
            {
                v += FakeModellList.ElementAt(i).Cores;
            }
            Assert.That(q3.Equals(v / i));
        }
        [Test]
        public void Test4()
        {
                Modell m = mdl.ReadAll().ElementAt(1);

                int k = m.Cores * m.ClockSpeed;
                if (m.HyperThreading)
                    k = k* 2;
            Assert.That(mdl.relativeSpeed(mdl.Read(m.Modell_Id)) == k );
        }
        [Test]
        public void Test5()
        {
            Assert.That(mdl.MostPowerFul().Name == "r8");
        }
    }
}