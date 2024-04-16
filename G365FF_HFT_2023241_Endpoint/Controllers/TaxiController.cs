using G365FF_HFT_2023241.Logic.Class;
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
    public class TaxiController : ControllerBase
    {
        ITaxiLogic taxiLogic;
        IHubContext<SignalRHub> hub;

        public TaxiController(ITaxiLogic taxiLogic, IHubContext<SignalRHub> hub)
        {
            this.taxiLogic = taxiLogic;
            this.hub = hub;
        }

        
        [HttpGet]
        public IEnumerable<Taxi> ReadAll()
        {
            return this.taxiLogic.ReadAll();
        }

        
        [HttpGet("{id}")]
        public Taxi Read(int id)
        {
            return this.taxiLogic.Read(id);
        }

        
        [HttpPost]
        public void Create([FromBody] Taxi value)
        {
            this.taxiLogic.Create(value);
            this.hub.Clients.All.SendAsync("TaxiCreated", value);
        }

        
        [HttpPut]
        public void Update( [FromBody] Taxi value)
        {
            this.taxiLogic.Update(value);
            this.hub.Clients.All.SendAsync("TaxiUpdated", value);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var TaxiToDelete = this.taxiLogic.Read(id);
            this.taxiLogic.Delete(id);
            this.hub.Clients.All.SendAsync("TaxiDeleted",TaxiToDelete);
        }
    }
}
