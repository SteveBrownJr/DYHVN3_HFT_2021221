using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Models
{
    public class Station
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Station_Id { get; set; }//Az állomás azonosítója
        [ForeignKey(nameof(Locomotive))]
        public int Locomotive_Id { get; set; }//Az állomást érintő vonat azonosítója
        
        public virtual Locomotive locomotive { get; set; }//Az állomást érintő vonat
        public string Name { get; set; }//Az állomás neve
        public int x_cordinate { get; set; }//Az állomás x koordinátája
        public int y_cordinate { get; set; }//Az állomás y koordinátája
        public double DistanceFrom(Station s1)
        {
            Station s2 = this;
            return Math.Sqrt(Math.Pow((s1.x_cordinate - s2.x_cordinate), 2) + Math.Pow((s1.y_cordinate - s2.y_cordinate), 2));
        }
    }
}
