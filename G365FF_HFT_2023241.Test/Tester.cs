using G365FF_HFT_2023241.Logic.Class;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    Cost=1000,
                    Distance=10,
                    TaxiId=1,
                    
                },
                new Ride()
                {
                    RID = 2,
                    Cost=2000,
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

            mockTaxiRepo= new Mock<IRepository<Taxi>>();
            mockTaxiRepo.Setup(t => t.ReadAll()).Returns(taxi);

            mockPassengerRepo = new Mock<IRepository<Passenger>>();
            mockPassengerRepo.Setup(p => p.ReadAll()).Returns(passenger);

            rideLogic= new RideLogic(mockRideRepo.Object,mockTaxiRepo.Object,mockPassengerRepo.Object);
            taxiLogic = new TaxiLogic(mockTaxiRepo.Object);
            passengerLogic = new PassengerLogic(mockPassengerRepo.Object,mockTaxiRepo.Object);
            
        }

        
        
    }
}
