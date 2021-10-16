using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Models
{
    public class Modell
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Modell_Id { get; set; }
        public string Family { get; set; }
        public string Name { get; set; }
        public int ClockSpeed { get; set; }
        public int Cores { get; set; }
        public bool HyperThreading { get; set; }
        public virtual Manufacturer Manufacturer{get;set;}
        [ForeignKey(nameof(Manufacturer))]
        public int ManufacturerId { get; set; }

    }
}
