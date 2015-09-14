using Restaurants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Restaurants.Services.Models.ViewModels
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Rating { get; set; }

        public TownViewModel Town { get; set; }

        public static Expression<Func<Restaurant, RestaurantViewModel>> Create
        {
            get
            {
                return r => new RestaurantViewModel
                {

                    Id = r.Id,
                    Name = r.Name,
                    Rating = r.Ratings.Average(rt => rt.Stars),
                    Town = new TownViewModel
                    {
                        Id = r.TownId,
                        Name = r.Town.Name
                    }
                };
            }
        }
    }
}