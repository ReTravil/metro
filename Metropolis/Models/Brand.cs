using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.Models
{
    public class Brand
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        public string BrandName { get; set; }

    }
}
