using G365FF_HFT_2023241.Logic.Interface;
using G365FF_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace G365FF_HFT_2023241_Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        IPassengerLogic passengerLogic;

        public PassengerController(IPassengerLogic passengerLogic)
        {
            this.passengerLogic = passengerLogic;
        }

        [HttpGet]
        public IEnumerable<Passenger> ReadAll()
        {
            return this.passengerLogic.ReadAll();
        }


        [HttpGet("{id}")]
        public Passenger Read(int id)
        {
            return this.passengerLogic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Passenger value)
        {
            this.passengerLogic.Create(value);
        }


        [HttpPut]
        public void Update([FromBody] Passenger value)
        {
            this.passengerLogic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.passengerLogic.Delete(id);
        }
    }
}
