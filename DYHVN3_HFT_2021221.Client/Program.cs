
using DYHVN3_HFT_2021221.Models;
using System;
using System.Linq;


namespace DYHVN3_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            MyConsoleApplication app = new MyConsoleApplication(new RestService("http://localhost:38193"));
            app.Start();
            /*
            var Locomotives = rest.Get<Locomotive>("locomotive");
            var Wagons = rest.Get<Wagon>("wagon");
            rest.Post<Station>(new Station()
            {
                Locomotive_Id = 1,
                Name = "Wartburg",
                x_cordinate = -1000,
                y_cordinate = 250,
            }, "station");
            var Stations = rest.Get<Station>("station");
            double avgstartingtourque = 
            */


            
        }
    }
}
