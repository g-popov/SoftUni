using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPowered.Models
{
    public class Game
    {
        private ICollection<ImageUrl> imageUrls;
        private ICollection<Rating> ratings;
        private ICollection<Review> reviews;

        public Game()
        {
            this.imageUrls = new HashSet<ImageUrl>();
            this.ratings = new HashSet<Rating>();
            this.reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SystemRequirements { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<ImageUrl> ImageUrls
        {
            get { return this.imageUrls; }
            set { this.imageUrls = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

    }
}
