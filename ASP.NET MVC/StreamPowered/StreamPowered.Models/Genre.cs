using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPowered.Models
{
    public class Genre
    {
        private ICollection<Game> games;

        public Genre()
        {
            this.games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Game> Games
        {
            get { return this.games; }
            set { this.games = value; }
        }
    }
}
