using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> DDCountry { get; set; }
        public IEnumerable<SelectListItem> DDBrand { get; set; }
        public IEnumerable<SelectListItem> DDProduct_Type { get; set; }
    }
}
