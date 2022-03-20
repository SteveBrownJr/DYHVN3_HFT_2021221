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
    public class StationController : ControllerBase
    {
        IStationLogic Sl;
        IHubContext<SignalRHub> hub;
        public StationController(IStationLogic Sl, IHubContext<SignalRHub> hub)
        {
            this.Sl = Sl;
            this.hub = hub;
        }

        // GET: api/<StationController>
        [HttpGet]
        public IEnumerable<Station> Get()
        {
            return Sl.ReadAll();
        }

        // GET api/<StationController>/5
        [HttpGet("{id}")]
        public Station Get(int id)
        {
            return Sl.Read(id);
        }

        // POST api/<StationController>
        [HttpPost]
        public void Post([FromBody] Station value)
        {
            Sl.Create(value);
            this.hub.Clients.All.SendAsync("StationCreated", value);
        }

        // PUT api/<StationController>/5
        [HttpPut]
        public void Put([FromBody] Station value)
        {
            Sl.Update(value);
            this.hub.Clients.All.SendAsync("StationUpdated", value);
        }

        // DELETE api/<StationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var StationToDelete = this.Sl.Read(id);
            Sl.Delete(id);
            this.hub.Clients.All.SendAsync("StationDeleted", StationToDelete);
        }
    }
}
