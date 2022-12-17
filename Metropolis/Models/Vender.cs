using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.Models
{
    public class Vender
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Vender_name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
