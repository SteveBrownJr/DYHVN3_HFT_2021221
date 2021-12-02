using DYHVN3_HFT_2021221.Logic;
using DYHVN3_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



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
        #region Locomotive non-cruds
        [HttpGet]
        public Locomotive FastestAcceleratingTrain()
        {
            return Ll.FastestAcceleratingTrain();
        }
        [HttpGet("{id}")]
        public IEnumerable<Station> TouchedStations(int id)
        {
            return Ll.TouchedStations(id);
        }
        [HttpGet]
        public Locomotive LongestTrain()
        {
            return Ll.LongestTrain();
        }
        [HttpGet]
        public Locomotive MostPowerFulLocomotive()
        {
            return Ll.MostPowerFulLocomotive();
        }
        [HttpGet]
        public Locomotive WeakestLocomotive()
        {
            return Ll.WeakestLocomotive();
        }
        [HttpGet("{id}")]
        public IEnumerable<Station> Route(int id)
        {
            return Ll.Route(id);
        }
        #endregion

        #region Station non-cruds

        [HttpGet("{first}/{second}")]
        public double DistanceBetweenTwoStation(int first, int second)
        {
            return Sl.DistanceBetweenTwoStation(first, second);
        }

        [HttpGet("{id}")]
        public Locomotive TouchingLocomotive(int id)
        {
            return Sl.TouchingLocomotive(id);
        }

        [HttpGet("{id}")]
        public IEnumerable<Wagon> TouchingWagons(int id)
        {
            return Sl.TouchingWagons(id);
        }

        [HttpGet("{id}")]
        public double MovedQuantity(int id)
        {
            return Sl.MovedQuantity(id);
        }

        [HttpGet("{id}")]
        public IEnumerable<Cargo_Type> MovedCargoTypes(int id)
        {
            return Sl.MovedCargoTypes(id);
        }

        #endregion

        #region Wagon non-cruds

        [HttpGet]
        public Wagon HeviestWagon()
        {
            return Wl.HeviestWagon();
        }

        [HttpGet]
        public Cargo_Type MostCommonCargoType()
        {
            return Wl.MostCommonCargoType();
        }

        [HttpGet("{id}")]
        public double AvarageStartingTorqueForTheWagon(int id)
        {
            return Wl.AvarageStartingTorqueForTheWagon(id);
        }



        #endregion
    }
}
