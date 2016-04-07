using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamPowered.Data.Repositories;
using StreamPowered.Models;
using System.Data.Entity;

namespace StreamPowered.Data.UnitOfWork
{
    public class StreamPoweredData : IStreamPoweredData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public StreamPoweredData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Game> Games
        {
            get { return this.GetRepository<Game>(); }
        }

        public IRepository<Genre> Genres
        {
            get { return this.GetRepository<Genre>(); }
        }

        public IRepository<ImageUrl> ImageUrls
        {
            get { return this.GetRepository<ImageUrl>(); }
        }

        public IRepository<Rating> Ratings
        {
            get { return this.GetRepository<Rating>(); }
        }

        public IRepository<Review> Reviews
        {
            get { return this.GetRepository<Review>(); }
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public int SaveChangesAsync()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(
                    typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
