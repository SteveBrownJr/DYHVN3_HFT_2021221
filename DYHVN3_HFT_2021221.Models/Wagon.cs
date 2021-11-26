using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Models
{
    public enum Cargo_Type {Hopper, Passanger, Mail,Tank }
    public class Wagon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Wagon_Id { get; set; }//A vagon azonosítója
        
        [ForeignKey(nameof(Locomotive))]
        public int Locomotive_Id { get; set; }//A vagont húzó mozdony azonosítója
        [JsonIgnore]
        public virtual Locomotive locomotive { get; set; }//A vagont húzó mozdony
        public Cargo_Type CargoType { get; set; }//Ez adja meg milyen típusú szállítmányt lehet szállítani a kocsival

        public double Quantity { get; set; }//Az a mozgósúly amivel legnagyobb terhelésen a vagon pályára áll
    }
}