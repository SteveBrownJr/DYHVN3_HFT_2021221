using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Models
{
    public class Motherboard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        [NotMapped]
        public virtual ICollection<CPU> SuppoertedCPUs { get; set; }
        public virtual ICollection<RAM> SuppoertedRAMs { get; set; }
        public Motherboard()
        {
            SuppoertedCPUs = new HashSet<CPU>();
            SuppoertedRAMs = new HashSet<RAM>();
        }
    }
}
