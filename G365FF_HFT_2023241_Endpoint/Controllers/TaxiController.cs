using G365FF_HFT_2023241.Logic.Class;
using G365FF_HFT_2023241.Logic.Interface;
using G365FF_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace G365FF_HFT_2023241_Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiController : ControllerBase
    {
        ITaxiLogic taxiLogic;

        public TaxiController(ITaxiLogic taxiLogic)
        {
            this.taxiLogic = taxiLogic;
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
        }

        
        [HttpPut]
        public void Update( [FromBody] Taxi value)
        {
            this.taxiLogic.Update(value);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.taxiLogic.Delete(id);
        }
    }
}
