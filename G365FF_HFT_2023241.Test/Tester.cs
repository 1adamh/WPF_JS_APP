using G365FF_HFT_2023241.Logic.Class;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace G365FF_HFT_2023241.Test
{
    [TestFixture]
    public class Tester
    {
        RideLogic rideLogic;
        Mock<IRepository<Ride>> mockRideRepo;
        TaxiLogic taxiLogic;
        Mock<IRepository<Taxi>> mockTaxiRepo;
        PassengerLogic passengerLogic;
        Mock<IRepository<Passenger>> mockPassengerRepo;

        [SetUp]
        public void Init()
        {
            var rides = new List<Ride>()
            {
                new Ride()
                {
                    RID = 1,
                    Cost=1500,
                    Distance=10,
                    TaxiId=1,

                },
                new Ride()
                {
                    RID = 2,
                    Cost=1500,
                    Distance=20,
                    TaxiId=2,

                }
            }.AsQueryable();

            var taxi = new List<Taxi>()
            {
                new Taxi()
                {
                    TID=1,
                    Name="tx",
                    RideID=1,

                },
                new Taxi()
                {
                    TID=2,
                    Name="ty",
                    RideID=2,

                }
            }.AsQueryable();


            var passenger = new List<Passenger>()
            {
                new Passenger()
                {
                    PID=1,
                    Name="px",
                    RideID=1,
                },
                new Passenger()
                {
                    PID=2,
                    Name="py",
                    RideID=2,
                }
            }.AsQueryable();

            mockRideRepo = new Mock<IRepository<Ride>>();
            mockRideRepo.Setup(r => r.ReadAll()).Returns(rides);

            mockTaxiRepo = new Mock<IRepository<Taxi>>();
            mockTaxiRepo.Setup(t => t.ReadAll()).Returns(taxi);

            mockPassengerRepo = new Mock<IRepository<Passenger>>();
            mockPassengerRepo.Setup(p => p.ReadAll()).Returns(passenger);

            rideLogic = new RideLogic(mockRideRepo.Object, mockTaxiRepo.Object, mockPassengerRepo.Object);
            taxiLogic = new TaxiLogic(mockTaxiRepo.Object);
            passengerLogic = new PassengerLogic(mockPassengerRepo.Object, mockTaxiRepo.Object);

        }
        [Test]
        public void Test1()
        {
            var sample = new Ride() { RID = 1 };

            rideLogic.Create(sample);

            mockRideRepo.Verify(m => m.Create(sample), Times.Once);
        }
        [Test]
        public void Test2()
        {
            var sample = new Ride() { RID = 1 };

            rideLogic.Update(sample);

            mockRideRepo.Verify(m => m.Update(sample), Times.Once);
        }
        [Test]
        public void Test3()
        {
            int id = 1;
            rideLogic.Delete(id);
            mockRideRepo.Verify(m => m.Delete(id), Times.Once);


        }

        [Test]
        public void Test4()
        {
            var p = new Passenger() { Name = "djkdwuivnuivivevneruvnervnrevneruvnreuivnernreunruvnreuivnneruvneruvnrevunerivneriuvnreuivnrevnervuirenvrnvuneruvneruivneruivnervurenveurvnreuvnruvneruivnerunvreuinvreuivnreuvnreuvnreuvnernvernveruivneriuvnreuivnreuivneruvnreuivneruivnervneievneriuvnerinveivniuernvuervnuiernviuervnerivnervnurvnernvuiervnernvuineruivneruivnreuivneruviv     " };
            
            try
            {
                //ACT
                passengerLogic.Create(p);
            }
            catch
            {

            }

            //ASSERT
            mockPassengerRepo.Verify(r => r.Create(p), Times.Never);
        }

        [Test]
        public void Test5()
        {
            // Arrange
            Taxi expected = new Taxi()
            {
                TID = 1,
                Name = "tx",
                RideID = 1,

            };

            mockTaxiRepo
                .Setup(r => r.Read(1))
                .Returns(expected);

            // Act
            var actual = taxiLogic.Read(1);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
            ;

            
        }

        [Test]
        public void Test6()
        {
            var result = rideLogic.AvgDistanceByPassenger();
            var expected = 15.0;
            var list = new List<double>();
            list.Add(expected);
            
            Assert.That(result, Is.EqualTo(list));


            
        }

        [Test]
        public void Test7()
        {
            var p = new Ride() { RID = 0 };

            try
            {
                //ACT
                rideLogic.Create(p);
            }
            catch
            {

            }

            //ASSERT
            mockRideRepo.Verify(r => r.Create(p), Times.Never);
        }
        [Test]
        public void Test8()
        {
            var result = rideLogic.AvgCostByPassenger();
            var expected = 1500.0;
            var list = new List<double>();
            list.Add(expected);

            Assert.That(result, Is.EqualTo(list));
        }
        [Test]
        public  void Test9()
        {
            var result = rideLogic.AvgDistanceByPassenger();
            var expected = 15.0;
            var list = new List<double>();
            list.Add(expected);

            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void Test10()
        {
            var result = rideLogic.AvgDriverRide();
            var expected = 1.0;
            var list = new List<double>();
            list.Add(expected);

            Assert.That(result, Is.EqualTo(list));
        }

        
        
    }
}
