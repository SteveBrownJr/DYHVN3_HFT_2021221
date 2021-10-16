using DYHVN3_HFT_2021221.Data;
using System;
using System.Linq;

namespace DYHVN3_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PCDbContext db = new PCDbContext();

            var test=db.Distributors.ToList();
            ;
        }
    }
}
