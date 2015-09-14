using Restaurants.Models;
using Restaurants.Services.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Restaurants.Services.Models.ViewModels;

namespace Restaurants.Services.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        [HttpPost]
        [Route("api/meals/{id}/order")]
        public IHttpActionResult CreateOrder(int id, OrderBindingModel model)
        {
            var meal = this.Data.Meals.Find(id);
            if (meal == null)
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
            var order = new Order
            {
                Quantity = model.Quantity,
                UserId = userId,
                MealId = meal.Id,
                CreatedOn = DateTime.Now,
                OrderStatus = OrderStatus.Pending
            };
            this.Data.Orders.Add(order);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        [Route("api/orders")]
        public IHttpActionResult GetPendingOrders(int startPage, int limit, int? mealId = null)
        {
            var userId = this.User.Identity.GetUserId();
            var orders = this.Data.Orders.All()
                .Where(o => o.UserId == userId && o.OrderStatus == OrderStatus.Pending)
                .OrderByDescending(o => o.CreatedOn)
                .Skip(startPage * limit)
                .Take(limit)
                .Select(o => new
                {
                    Id = o.Id,
                    Meal = new MealViewModel
                    {
                        Id = o.MealId,
                        Name = o.Meal.Name,
                        Price = o.Meal.Price,
                        Type = o.Meal.Type.Name
                    },
                    Quantity = o.Quantity,
                    Status = o.OrderStatus,
                    CratedOn = o.CreatedOn
                });
            return this.Ok(orders);
        }
    }
}
