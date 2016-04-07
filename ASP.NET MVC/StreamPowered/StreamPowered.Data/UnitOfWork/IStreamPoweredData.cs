using StreamPowered.Data.Repositories;
using StreamPowered.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPowered.Data.UnitOfWork
{
    public interface IStreamPoweredData
    {
        IRepository<Game> Games { get; }

        IRepository<Genre> Genres { get; }

        IRepository<ImageUrl> ImageUrls { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Review> Reviews { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
