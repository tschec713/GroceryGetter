﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryGetter.BL.Models
{


    public enum StoreLocation
    {
        WALMART,
        ALDI,
        KROGGER,
        FESTIVAL,
        ALPHABETICAL


    }

    public enum AisleLocation
    {

        BREAD,
        CLEANING,
        DAIRY,
        PRODUCE,
        CEREAL,
        HOUSEHOLD
    }


    public class Product
    {
        public Guid Id { get; set; }
        [Display(Name = "Item Name")]
        public string Title { get; set; }
        

        public StoreLocation Store { get; set; }
        public AisleLocation Aisle { get; set; }

    }
}
