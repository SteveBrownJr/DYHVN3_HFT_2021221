using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Models
{
    public class Distributor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Distributor_Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int EmployeeNumber { get; set; }
        [NotMapped]
        public virtual ICollection<Manufacturer> Manufacturers { get; set; }   
        public Distributor()
        {
            Manufacturers = new HashSet<Manufacturer>();
        }
    }
}
