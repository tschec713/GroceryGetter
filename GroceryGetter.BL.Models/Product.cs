﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryGetter.BL.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "Aisle")]
        public string AisleNumber { get; set; }
    }
}
