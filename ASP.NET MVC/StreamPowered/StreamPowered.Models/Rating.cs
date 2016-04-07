using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPowered.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 5)]
        public int RatingValue { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

    }
}
