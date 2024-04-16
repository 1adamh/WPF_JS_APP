using G365FF_HFT_2023241.Logic.Interface;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241_Endpoint.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace G365FF_HFT_2023241_Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        IPassengerLogic passengerLogic;
        IHubContext<SignalRHub> hub;

        public PassengerController(IPassengerLogic passengerLogic, IHubContext<SignalRHub> hub)
        {
            this.passengerLogic = passengerLogic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("PassengerCreated", value);
        }


        [HttpPut]
        public void Update([FromBody] Passenger value)
        {
            this.passengerLogic.Update(value);
            this.hub.Clients.All.SendAsync("PassengerUpdated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var passengerToDelete = this.passengerLogic.Read(id);
            this.passengerLogic.Delete(id);
            this.hub.Clients.All.SendAsync("PassengerDeleted", passengerToDelete);
        }
    }
}
