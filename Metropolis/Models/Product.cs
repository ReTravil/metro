using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cost { get; set; }


        [DisplayName("Brand")]
        public int BrandId { get; set; }
        [DisplayName("Country")]
        public int CountryId { get; set; }
        [DisplayName("Type")]
        public int Product_type_id { get; set; }



        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        [ForeignKey("TypeId")]
        public Product_type Product_types { get; set; }
    }
}
