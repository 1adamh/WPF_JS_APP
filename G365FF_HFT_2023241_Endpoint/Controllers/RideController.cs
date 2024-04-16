using G365FF_HFT_2023241.Logic.Interface;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241_Endpoint.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;



namespace G365FF_HFT_2023241_Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        IRideLogic rideLogic;
        IHubContext<SignalRHub> hub;

        public RideController(IRideLogic rideLogic, IHubContext<SignalRHub> hub)
        {
            this.rideLogic = rideLogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Ride> ReadAll()
        {
            return this.rideLogic.ReadAll();
        }


        [HttpGet("{id}")]
        public Ride Read(int id)
        {
            return this.rideLogic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Ride value)
        {
            this.rideLogic.Create(value);
            this.hub.Clients.All.SendAsync("RideCreated", value);
        }


        [HttpPut]
        public void Update([FromBody] Ride value)
        {
            this.rideLogic.Update(value);
            this.hub.Clients.All.SendAsync("RideUpdated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rideToDelete= this.rideLogic.Read(id);
            this.rideLogic.Delete(id);
            this.hub.Clients.All.SendAsync("RideDeleted", rideToDelete);

        }
    }
}
