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
    public class LocomotiveController : ControllerBase
    {
        ILocomotiveLogic Ll;

        IHubContext<SignalRHub> hub;

        public LocomotiveController(ILocomotiveLogic Ll, IHubContext<SignalRHub> hub)
        {
            this.Ll = Ll;
            this.hub = hub;
        }

        // GET: api/<LocomotiveController>
        [HttpGet]
        public IEnumerable<Locomotive> Get()
        {
            return Ll.ReadAll();
        }

        // GET api/<LocomotiveController>/5
        [HttpGet("{id}")]
        public Locomotive Get(int id)
        {
            return Ll.Read(id);
        }

        // POST api/<LocomotiveController>
        [HttpPost]
        public void Post([FromBody] Locomotive value)
        {
            Ll.Create(value);
            this.hub.Clients.All.SendAsync("LocomotiveCreated", value);
        }

        // PUT api/<LocomotiveController>/5
        [HttpPut]
        public void Put([FromBody] Locomotive value)
        {
            Ll.Update(value);
            this.hub.Clients.All.SendAsync("LocomotiveUpdated", value);
        }

        // DELETE api/<LocomotiveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var LocomotiveToDelete = this.Ll.Read(id);
            Ll.Delete(id);
            this.hub.Clients.All.SendAsync("LocomotiveDeleted", LocomotiveToDelete);
        }
    }
}
