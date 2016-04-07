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
    public class ReviewsController : BaseController
    {
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int id, ReviewBindingModel model)
        {
            var game = this.Data.Games.Find(id);
            if (game == null)
            {
                return this.HttpNotFound();
            }

            if (model != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var review = new Review
                {
                    Content = model.Content,
                    AuthorId = userId,
                    Game = game,
                    CreationTime = DateTime.Now
                };
                game.Reviews.Add(review);
                this.Data.SaveChanges();
                TempData["message"] = "Successfully added a new review";
                TempData["status"] = "info";
            }
            return this.RedirectToAction("Details", "Games", new { id = id });
        }
    }
}