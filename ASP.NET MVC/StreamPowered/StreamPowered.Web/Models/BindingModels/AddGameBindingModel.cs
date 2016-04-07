using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamPowered.Web.Models.BindingModels
{
    public class AddGameBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string SystemRequirements { get; set; }

        //public IEnumerable<string> Images { get; set; }
    }
}