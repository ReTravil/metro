using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.Models
{
    public class Product_type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type_name { get; set; }
    }
}
