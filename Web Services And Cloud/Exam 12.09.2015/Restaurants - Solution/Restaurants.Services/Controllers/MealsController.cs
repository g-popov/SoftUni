using Restaurants.Services.Models.BindingModels;
using Restaurants.Services.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Restaurants.Models;

namespace Restaurants.Services.Controllers
{
    [Authorize]
    public class MealsController : BaseApiController
    {
        [HttpGet]
        [Route("api/restaurants/{id}/meals")]
        [AllowAnonymous]
        public IHttpActionResult GetRestaurantMeals(int id)
        {
            var restaurant = this.Data.Restaurants.Find(id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            var meals = this.Data.Meals.All()
                .Where(m => m.RestaurantId == id)
                .OrderBy(m => m.Type.Order)
                .ThenBy(m => m.Name)
                .Select(MealViewModel.Create);
            return this.Ok(meals);
        }

        [HttpPost]
        [Route("api/meals")]
        public IHttpActionResult CreateMeal(CreateMealBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var mealType = this.Data.MealTypes.Find(model.TypeId);
            if (mealType == null)
            {
                return this.BadRequest("Invalid meal type id.");
            }

            var restaurant = this.Data.Restaurants.Find(model.RestaurantId);
            if (restaurant == null)
            {
                return this.BadRequest("Invalid restaurant id.");
            }

            var userId = this.User.Identity.GetUserId();
            if (userId != restaurant.OwnerId)
            {
                return this.Unauthorized();
            }

            var meal = new Meal
            {
                Name = model.Name,
                Price = model.Price,
                TypeId = model.TypeId,
                RestaurantId = model.RestaurantId
            };
            this.Data.Meals.Add(meal);
            this.Data.SaveChanges();
            var dataResult = this.Data.Meals.All()
                .Where(m => m.Id == meal.Id)
                .Select(MealViewModel.Create)
                .FirstOrDefault();

            return this.Created(string.Format("http://localhost:1337/api/meals/{0}", meal.Id), dataResult);
        }

        [HttpPut]
        [Route("api/meals/{id}")]
        public IHttpActionResult EditMeal(int id, EditMealBindingModel model)
        {
            var meal = this.Data.Meals.Find(id);
            if (meal == null)
            {
                return this.NotFound();
            }

            var userId = this.User.Identity.GetUserId();
            if (meal.Restaurant.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var mealType = this.Data.MealTypes.Find(model.TypeId);
            if (mealType == null)
            {
                return this.BadRequest("Invalid meal type id.");
            }

            meal.Name = model.Name;
            meal.Price = model.Price;
            meal.TypeId = model.TypeId;
            this.Data.SaveChanges();

            var dataResult = this.Data.Meals.All()
                .Where(m => m.Id == meal.Id)
                .Select(MealViewModel.Create)
                .FirstOrDefault();
            return this.Ok(dataResult);
        }

        [HttpDelete]
        [Route("api/meals/{id}")]
        public IHttpActionResult DeleteMeal(int id)
        {
            var meal = this.Data.Meals.Find(id);
            if (meal == null)
            {
                return this.NotFound();
            }

            var userId = this.User.Identity.GetUserId();
            if (meal.Restaurant.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            this.Data.Meals.Delete(meal);
            this.Data.SaveChanges();
            return this.Ok(new { message = string.Format("Meal #{0} deleted.", meal.Id) });
        }


    }
}
