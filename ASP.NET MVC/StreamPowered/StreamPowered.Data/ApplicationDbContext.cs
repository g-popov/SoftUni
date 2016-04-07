using Microsoft.AspNet.Identity.EntityFramework;
using StreamPowered.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPowered.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<ImageUrl> ImageUrls { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
