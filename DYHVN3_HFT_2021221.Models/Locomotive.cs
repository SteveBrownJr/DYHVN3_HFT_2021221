using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Models
{
    public class Locomotive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Locomotive_Id { get; set; }//A mozdony pályaszámától ebben az esetben eltekintek így csak az ID fogja meghatározni őket
        public string Name { get; set; }//A feladatban szereplő mozdonyok a valóságban is léteznek a MÁV flottájában így a nevükbe az adott pályaszámú mozdony beceneve jelzi
        public string Type { get; set; }//A mozdony típusa, ám a típus becenevét fogom megadni, hogy színesebb legyen a feladat
        public int Staff { get; set; }//A vezérek száma akik a mozdonyon dolgoznak
        public int Starting_Torque { get; set; }//Indító vonóerő. 10 tonnánként kell 1, hogy a mozdony megtudja mozdítani a szerelvényt
        public double load { get; set; }
        [NotMapped]
        public virtual ICollection<Wagon> Wagons { get; set; }//A mozdony mögé csatolt vagonok
        [NotMapped]
        public virtual ICollection<Station> Stations { get; set; }//A mozdony állomásai
        public Locomotive()
        {
            Wagons = new HashSet<Wagon>();
            Stations = new HashSet<Station>();
        }
    }
}
