using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Models
{
    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Manufacturer_Id { get; set; }
        public string Name { get; set; }
        public string colour { get; set; }
        public virtual Distributor Distributor { get; set; }
        [NotMapped]
        public virtual ICollection<Modell> Modells { get; set; }
        public Manufacturer()
        {
            Modells = new HashSet<Modell>();
        }
        [ForeignKey(nameof(Distributor))]
        public int DistributorId { get; set; }
    }
}
