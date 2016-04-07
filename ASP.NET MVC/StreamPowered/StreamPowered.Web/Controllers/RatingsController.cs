using Microsoft.AspNet.Identity;
using StreamPowered.Models;
using StreamPowered.Web.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamPowered.Web.Controllers
{
    public class RatingsController : BaseController
    {
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int id, AddRatingBindingModel model)
        {
            var game = this.Data.Games.Find(id);
            if (game == null)
            {
                return this.HttpNotFound();
            }
            var userId = this.User.Identity.GetUserId();
            if (!game.Ratings.Any(r => r.AuthorId == userId) && model != null && this.ModelState.IsValid)
            {
                var rating = new Rating
                {
                    RatingValue = model.RatingValue,
                    AuthorId = userId,
                    Game = game
                };
                game.Ratings.Add(rating);
                this.Data.SaveChanges();
                TempData["message"] = "Successfully added a new rating";
                TempData["status"] = "info";
            }
            return this.RedirectToAction("Details", "Games", new { id = id });
        }
    }
}