using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restauranteur.Models;
using Restaurants.Data.Repositories;
using Restaurants.Models;
using System.Data.Entity;

namespace Restaurants.Data
{
    public class RestaurantsData : IRestaurantsData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public RestaurantsData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }


        public IRepository<Meal> Meals
        {
            get
            {
                return this.GetRepository<Meal>();
            }
        }

        public IRepository<MealType> MealTypes
        {
            get
            {
                return this.GetRepository<MealType>();
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                return this.GetRepository<Order>();
            }
        }

        public IRepository<Rating> Ratings
        {
            get
            {
                return this.GetRepository<Rating>();
            }
        }

        public IRepository<Restaurant> Restaurants
        {
            get
            {
                return this.GetRepository<Restaurant>();
            }
        }

        public IRepository<Town> Towns
        {
            get
            {
                return this.GetRepository<Town>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
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
