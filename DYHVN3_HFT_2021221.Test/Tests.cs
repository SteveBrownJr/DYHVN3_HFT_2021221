using NUnit.Framework;
using System;
using DYHVN3_HFT_2021221.Logic;
using DYHVN3_HFT_2021221.Repository;
using DYHVN3_HFT_2021221.Data;
using Moq;
using DYHVN3_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace DYHVN3_HFT_2021221.Test
{
    [TestFixture]
    class Tests
    {
        LocomotiveLogic locomotiveLogic;
        WagonLogic wagonLogic;
        StationLogic stationLogic;


        [SetUp]
        public void Init()
        {
            var mockLocomotiveRepository = new Mock<ILocomotiveRepository>();
            var mockStationRepository = new Mock<IStationRepository>();
            var mockWagonRepository = new Mock<IWagonRepository>();

            Random rnd = new Random();

            List<Locomotive> fakeLocomotives = new List<Locomotive>()
            {
               new Locomotive() { Locomotive_Id = 1, Name = "Szocske", Staff = 1, Starting_Torque = rnd.Next(198,202), Type = "V46",load=32000},
               new Locomotive() { Locomotive_Id = 2, Name = "Csorgo", Staff = 2, Starting_Torque = 204, Type = "M41",load=1300}
            };
            List<Station> fakeStations = new List<Station>() {
            new Station() { Station_Id = 1,Locomotive_Id=1,locomotive=fakeLocomotives[0],Name="London", x_cordinate = rnd.Next(0, 10), y_cordinate = rnd.Next(0, 10) },
            new Station() { Station_Id = 2, Locomotive_Id = 2,locomotive=fakeLocomotives[1], Name = "Kobanya", x_cordinate = rnd.Next(0, 10), y_cordinate = rnd.Next(0, 10) },
            new Station() { Station_Id = 3, Locomotive_Id = 2,locomotive=fakeLocomotives[1], Name = "Berlin", x_cordinate = rnd.Next(0, 10), y_cordinate = rnd.Next(0, 10) },
            new Station() { Station_Id = 4, Locomotive_Id = 2,locomotive=fakeLocomotives[1], Name = "Nis", x_cordinate = 11, y_cordinate = 11 },
            new Station() { Station_Id = 5, Locomotive_Id = 2,locomotive=fakeLocomotives[1], Name = "Nysa", x_cordinate = 3, y_cordinate = 6 },
            };

            List<Wagon> fakeWagons = new List<Wagon>() {
            new Wagon() { Wagon_Id = 1, CargoType = Cargo_Type.Tank, Locomotive_Id = 1,locomotive=fakeLocomotives[0], Quantity = 12000 },
            new Wagon() { Wagon_Id = 2, CargoType = Cargo_Type.Passanger, Locomotive_Id = 2,locomotive=fakeLocomotives[1], Quantity = 100 },
            new Wagon() { Wagon_Id = 3, CargoType = Cargo_Type.Passanger, Locomotive_Id = 2,locomotive=fakeLocomotives[1], Quantity = 100 },
            new Wagon() { Wagon_Id = 4, CargoType = Cargo_Type.Passanger, Locomotive_Id = 2,locomotive=fakeLocomotives[1], Quantity = 100 },
            new Wagon() { Wagon_Id = 5, CargoType = Cargo_Type.Mail, Locomotive_Id = 2,locomotive=fakeLocomotives[1], Quantity = 250 },
            new Wagon() { Wagon_Id = 6, CargoType = Cargo_Type.Mail, Locomotive_Id = 2,locomotive=fakeLocomotives[1], Quantity = 250 },
            new Wagon() { Wagon_Id = 7, CargoType = Cargo_Type.Mail, Locomotive_Id = 2,locomotive=fakeLocomotives[1], Quantity = 250 },
            new Wagon() { Wagon_Id = 8, CargoType = Cargo_Type.Mail, Locomotive_Id = 2,locomotive=fakeLocomotives[1], Quantity = 250 },
            new Wagon() { Wagon_Id = 9, CargoType = Cargo_Type.Hopper, Locomotive_Id = 1,locomotive=fakeLocomotives[0], Quantity = 10000 },
            new Wagon() { Wagon_Id = 10, CargoType = Cargo_Type.Hopper, Locomotive_Id = 1,locomotive=fakeLocomotives[0], Quantity = 10000 },
            };

            for (int i = 0; i < fakeWagons.Count; i++)
                fakeLocomotives[fakeWagons[i].Locomotive_Id - 1].Wagons.Add(fakeWagons[i]);
            for (int i = 0; i < fakeStations.Count; i++)
                fakeLocomotives[fakeStations[i].Locomotive_Id - 1].Stations.Add(fakeStations[i]);

            mockLocomotiveRepository.Setup((t) => t.GetAll()).Returns(fakeLocomotives.AsQueryable());

            for (int i = 1; i <= fakeLocomotives.Count; i++)
                mockLocomotiveRepository.Setup((t) => t.Read(i)).Returns(fakeLocomotives[i-1]);

            mockStationRepository.Setup((t) => t.GetAll()).Returns(fakeStations.AsQueryable());

            for (int i = 1; i <= fakeStations.Count; i++)
                mockStationRepository.Setup((t) => t.Read(i)).Returns(fakeStations[i-1]);

            mockWagonRepository.Setup((t) => t.GetAll()).Returns(fakeWagons.AsQueryable());
            for (int i = 1; i <= fakeWagons.Count; i++)
                mockWagonRepository.Setup((t) => t.Read(i)).Returns(fakeWagons[i - 1]);
            locomotiveLogic = new LocomotiveLogic(mockLocomotiveRepository.Object, mockStationRepository.Object, mockWagonRepository.Object);
            wagonLogic = new WagonLogic(mockWagonRepository.Object,mockLocomotiveRepository.Object);
            stationLogic = new StationLogic(mockStationRepository.Object, mockLocomotiveRepository.Object, mockWagonRepository.Object);
        }

        [Test]
        public void MostPowerFulLocomotiveAndWeakestLocomotiveTestTest()
        {
            Assert.That(locomotiveLogic.ReadAll().ElementAt(1).Equals(locomotiveLogic.MostPowerFulLocomotive()) && locomotiveLogic.ReadAll().ElementAt(0).Equals(locomotiveLogic.WeakestLocomotive()));
        }

        [Test]
        public void RouteTest()
        {
            bool correct = true;
            IEnumerable<Station> route = locomotiveLogic.Route(2);
            int j = 0;
            for (int i = 1; i < route.Count(); i++)
                if (route.ElementAt(i).DistanceFrom(new Station() { x_cordinate=0,y_cordinate=0}) < route.ElementAt(j).DistanceFrom(new Station() { x_cordinate = 0, y_cordinate = 0 }))//Azt nézzük meg, hogy az n-1 állomás mindig közelebb legyen az origóhoz mint az n-edik
                    correct = false;
            Assert.That(correct);
        }

        [Test]
        public void StationDistanceTest()
        {
            Assert.That(stationLogic.DistanceBetweenTwoStation(4, 5) == Math.Sqrt(89));
        }

        [Test]
        public void MovedQuantityTest()
        {
            Assert.That(stationLogic.MovedQuantity(1)==32000);
        }

        [Test]
        public void FastestAccelleratingTest()
        {
            Console.WriteLine(locomotiveLogic.FastestAcceleratingTrain().Locomotive_Id);
            Assert.That(locomotiveLogic.FastestAcceleratingTrain().Equals(locomotiveLogic.Read(2)));
        }

        [Test]
        public void TouchinWagonsTest()
        {
            //Act
            IEnumerable<Wagon> t = stationLogic.TouchingWagons(1);

            //Expected
            ICollection<Wagon> e = new Collection<Wagon>();
            e.Add(wagonLogic.Read(1));
            e.Add(wagonLogic.Read(9));
            e.Add(wagonLogic.Read(10));

            //Assert

            bool correct = true;
            foreach (var itemt in t)
            {
                bool innercorrect = false;
                foreach (var iteme in e)
                {
                    if (itemt.Wagon_Id==iteme.Wagon_Id)
                    {
                        if (!innercorrect&&correct)
                        {
                            innercorrect = true;
                        }
                    }
                }
                correct = innercorrect;
            } 

            Assert.That(correct);
        }

        [Test]
        public void OverloadExceptionTest()
        {
            Exception e=null;

                try
                {
                    wagonLogic.Create(new Wagon() { CargoType = Cargo_Type.Tank, Quantity = int.MaxValue, locomotive = locomotiveLogic.Read(1), Locomotive_Id = 1,Wagon_Id=11 });
                }
                catch (Exception n )
                {
                    e = n;
                }

            Assert.That(e.Message == "If we connect his wagon to the locomotive, the locomotive will be overloaded");
        }

        [Test]
        public void MovedCargoTypeTest()
        {
            //Act
            IEnumerable<Cargo_Type> type = stationLogic.MovedCargoTypes(1);
            //Assert
            Assert.That(type.Contains(Cargo_Type.Hopper) && type.Contains(Cargo_Type.Tank) && !type.Contains(Cargo_Type.Mail) && !type.Contains(Cargo_Type.Passanger));
        }

        [Test]
        public void TouchingLocomotiveTest()
        {
            //Act
           Locomotive t = stationLogic.TouchingLocomotive(1);

            //Expected

            Locomotive e = locomotiveLogic.Read(1);

            //Assert

            Assert.That(t.Equals(e));
        }

        [Test]
        public void LongestTrainTest()
        {
            //Act
            Locomotive t = locomotiveLogic.LongestTrain();
            //Expected
            Locomotive e = locomotiveLogic.Read(2);
            //Assert
            Assert.That(t.Equals(e));
        }

        [Test]
        public void LocomotiveCreateTest()
        {
            Locomotive l = new Locomotive() { Name = "Albert", Type = "D", Staff = 5, Starting_Torque = 510 };
            
            Assert.Throws<ArgumentOutOfRangeException>(() => locomotiveLogic.Create(l));
        }
        [Test]
        public void WagonCreateTest()
        {
            Wagon w = new Wagon() { CargoType = Cargo_Type.Hopper, Wagon_Id = 0, Locomotive_Id = 0, Quantity = 200 };
            
            Assert.Throws<ArgumentOutOfRangeException>(()=>wagonLogic.Create(w));
        }
        [Test]
        public void StationCreateTest()
        {
            Station s = new Station() { Locomotive_Id = 0, x_cordinate = 0, y_cordinate = 0, Name = "Afganistan" };

            Assert.Throws<ArgumentOutOfRangeException>(()=>stationLogic.Create(s));
        }
    }
}
