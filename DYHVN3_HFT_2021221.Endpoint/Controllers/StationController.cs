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
    public class StationController : ControllerBase
    {
        IStationLogic Sl;
        public StationController(IStationLogic Sl)
        {
            this.Sl = Sl;
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
        }

        // PUT api/<StationController>/5
        [HttpPut]
        public void Put([FromBody] Station value)
        {
            Sl.Update(value);
        }

        // DELETE api/<StationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Sl.Delete(id);
        }
    }
}
