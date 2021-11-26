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
    public class LocomotiveController : ControllerBase
    {
        ILocomotiveLogic Ll;

        public LocomotiveController(ILocomotiveLogic Ll)
        {
            this.Ll = Ll;
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
        }

        // PUT api/<LocomotiveController>/5
        [HttpPut]
        public void Put([FromBody] Locomotive value)
        {
            Ll.Update(value);
        }

        // DELETE api/<LocomotiveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Ll.Delete(id);
        }
    }
}
