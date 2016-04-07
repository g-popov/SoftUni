using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamPowered.Web.Models.BindingModels
{
    public class AddRatingBindingModel
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        [Range(1, 5)]
        public int RatingValue { get; set; }
    }
}