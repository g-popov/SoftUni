using Restauranteur.Models;
using Restaurants.Data.Repositories;
using Restaurants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Data
{
    public interface IRestaurantsData
    {
        IRepository<Rating> Ratings { get; }

        IRepository<Town> Towns { get; }

        IRepository<Restaurant> Restaurants { get; }

        IRepository<Meal> Meals { get; }

        IRepository<MealType> MealTypes { get; }

        IRepository<Order> Orders { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }

}
