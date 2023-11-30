using G365FF_HFT_2023241.Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace G365FF_HFT_2023241_Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PassengerStatcontroller : ControllerBase
    {

        IPassengerLogic passengerLogic;

        public PassengerStatcontroller(IPassengerLogic passengerLogic)
        {
            this.passengerLogic = passengerLogic;
        }

        [HttpGet]
        public IEnumerable AvgPassByDriver()
        {
            return passengerLogic.AvgPassByDriver();
        }
    }
}
