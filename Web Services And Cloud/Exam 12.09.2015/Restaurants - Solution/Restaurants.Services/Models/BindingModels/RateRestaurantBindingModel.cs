﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models.BindingModels
{
    public class RateRestaurantBindingModel
    {
        [Required]
        [Range(0, 10)]
        public int Stars { get; set; }
    }
}