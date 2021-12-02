using DYHVN3_HFT_2021221.Logic;
using DYHVN3_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
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
        public WagonController(IWagonLogic Wl)
        {
            this.Wl = Wl;
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
        }

        // PUT api/<WagonController>/5
        [HttpPut]
        public void Put([FromBody] Wagon value)
        {
            Wl.Update(value);
        }

        // DELETE api/<WagonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Wl.Delete(id);
        }
    }
}
