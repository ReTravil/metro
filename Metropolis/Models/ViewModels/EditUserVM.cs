﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.Models.ViewModels
{
    public class EditUserVM
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
