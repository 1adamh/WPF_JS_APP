using G365FF_HFT_2023241.Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace G365FF_HFT_2023241_Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RideStatController : ControllerBase
    {
        IRideLogic rideLogic;

        public RideStatController(IRideLogic rideLogic)
        {
            this.rideLogic = rideLogic;
        }
        [HttpGet]
        public IEnumerable AvgDistanceByDriver()
        {
            return rideLogic.AvgDistanceByDriver();
        }
        [HttpGet]
        public IEnumerable AvgDistanceByPassenger()
        {
            return rideLogic.AvgDistanceByPassenger();
        }
        [HttpGet]
        public IEnumerable AvgCostByPassenger() 
        {
            return rideLogic.AvgCostByPassenger();
        }
        [HttpGet]
        public IEnumerable AvgDriverRide()
        {
            return rideLogic.AvgDriverRide();
        }
    }
}
