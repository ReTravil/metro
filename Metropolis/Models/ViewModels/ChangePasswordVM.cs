using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.Models.ViewModels
{
    public class ChangePasswordVM
        {
            public string Id { get; set; }
            public string Email { get; set; }
            [Required]
            public string NewPassword { get; set; }
        }
}
