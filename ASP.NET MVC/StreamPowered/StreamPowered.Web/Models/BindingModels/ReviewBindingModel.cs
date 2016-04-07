using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamPowered.Web.Models.BindingModels
{
    public class ReviewBindingModel
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}