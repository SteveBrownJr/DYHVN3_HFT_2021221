using DYHVN3_HFT_2021221.Logic;
using DYHVN3_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DYHVN3_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        ILocomotiveLogic Ll;
        IWagonLogic Wl;
        IStationLogic Sl;
        public TrainController(ILocomotiveLogic Ll, IWagonLogic Wl, IStationLogic Sl)
        {
            this.Ll = Ll;
            this.Wl = Wl;
            this.Sl = Sl;
        }

        [HttpGet]
        public Locomotive FastestAcceleratingTrain()
        {
            return Ll.FastestAcceleratingTrain();
        }
        [HttpGet("{id}")]
        public Locomotive TouchingLocomotive(int id)
        {
            return Sl.TouchingLocomotive(id);
        }

        
    }
}
