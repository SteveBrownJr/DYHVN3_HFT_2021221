using DYHVN3_HFT_2021221.Logic;
using DYHVN3_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace DYHVN3_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WagonController : ControllerBase
    {
        IWagonLogic Wl;
        IHubContext<SignalRHub> hub;
        public WagonController(IWagonLogic Wl, IHubContext<SignalRHub> hub)
        {
            this.Wl = Wl;
            this.hub = hub;
        }

        // GET: api/<WagonController>
        [HttpGet]
        public IEnumerable<Wagon> Get()
        {
            return Wl.ReadAll();
        }

        // GET api/<WagonController>/5
        [HttpGet("{id}")]
        public Wagon Get(int id)
        {
            return Wl.Read(id);
        }

        // POST api/<WagonController>
        [HttpPost]
        public void Post([FromBody] Wagon value)
        {
            Wl.Create(value);
            this.hub.Clients.All.SendAsync("WagonCreated", value);
            this.hub.Clients.All.SendAsync("LocomotiveUpdated", value.locomotive);
        }

        // PUT api/<WagonController>/5
        [HttpPut]
        public void Put([FromBody] Wagon value)
        {
            Wl.Update(value);
            this.hub.Clients.All.SendAsync("WagonUpdated", value);
            this.hub.Clients.All.SendAsync("LocomotiveUpdated", value.locomotive);
        }

        // DELETE api/<WagonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var WagonToDelete = this.Wl.Read(id);
            Wl.Delete(id);
            this.hub.Clients.All.SendAsync("WagonDeleted", WagonToDelete);
        }
    }
}
