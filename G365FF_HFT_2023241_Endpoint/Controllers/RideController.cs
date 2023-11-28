using G365FF_HFT_2023241.Logic.Interface;
using G365FF_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



namespace G365FF_HFT_2023241_Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        IRideLogic rideLogic;

        public RideController(IRideLogic rideLogic)
        {
            this.rideLogic = rideLogic;
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
        }


        [HttpPut]
        public void Update([FromBody] Ride value)
        {
            this.rideLogic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.rideLogic.Delete(id);
        }
    }
}
