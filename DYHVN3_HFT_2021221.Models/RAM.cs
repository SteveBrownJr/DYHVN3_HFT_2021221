using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Models
{
    public class RAM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Brand { get; set; }//Intel vagy AMD
        public string Model { get; set; }
        public string Slot { get; set; }
        public int Storage { get; set; }
        public int Clock { get; set; }
        public int Latency { get; set; }
    }
}
