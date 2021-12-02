
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

            
        }
    }
}
