using Restaurants.Models;
using Restaurants.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Restaurants.Services.Models.ViewModels;
using Restaurants.Services.Models.BindingModels;

namespace Restaurants.Services.Controllers
{
    [Authorize]
    public class RestaurantsController : BaseApiController
    {
        [AllowAnonymous]
        [Route("api/restaurants")]
        public IHttpActionResult GetRestaurantsByTown(int townId)
        {
            var town = this.Data.Towns.Find(townId);
            var restaurants = this.Data.Restaurants.All()
                .Where(r => r.TownId == townId)
                .OrderByDescending(r => r.Ratings.Average(rt => rt.Stars))
                .ThenBy(r => r.Name)
                .Select(RestaurantViewModel.Create);

            return this.Ok(restaurants);
        }

        [HttpPost]
        [Route("api/restaurants", Name = "CreateRestaurant")]
        public IHttpActionResult CreateRestaurant(CreateRestaurantBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var town = this.Data.Towns.Find(model.TownId);
            if (town == null)
            {
                return this.BadRequest("Invalid town Id.");
            }

            var userId = this.User.Identity.GetUserId();
            var restaurant = new Restaurant()
            {
                Name = model.Name,
                TownId = model.TownId,
                OwnerId = userId
            };

            this.Data.Restaurants.Add(restaurant);
            this.Data.SaveChanges();

            var resultData = this.Data.Restaurants.All()
                .Where(r => r.Id == restaurant.Id)
                .Select(RestaurantViewModel.Create)
                .FirstOrDefault();

            return this.Created(string.Format("http://localhost:1337/api/restaurants/{0}", restaurant.Id), resultData);
        }

        [HttpPost]
        [Route("api/restaurants/{id}/rate")]
        public IHttpActionResult RateRestaurant([FromUri]int id, RateRestaurantBindingModel model)
        {
            var restaurant = this.Data.Restaurants.Find(id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            if (restaurant.OwnerId == userId)
            {
                return this.BadRequest("You cannot rate your own restaurant");
            }

            if (this.Data.Ratings.All().Any(r => r.UserId == userId && r.RestaurantId == restaurant.Id))
            {
                return this.BadRequest("You cannot rate a restaurant more than once");
            }

            var rating = new Rating
            {
                Stars = model.Stars,
                UserId = userId,
                RestaurantId = restaurant.Id
            };
            this.Data.Ratings.Add(rating);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
