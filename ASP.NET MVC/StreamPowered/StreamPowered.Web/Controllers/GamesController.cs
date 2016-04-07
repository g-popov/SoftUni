using Microsoft.AspNet.Identity;
using StreamPowered.Models;
using StreamPowered.Web.Models.BindingModels;
using StreamPowered.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamPowered.Web.Controllers
{
    public class GamesController : BaseController
    {
        public ActionResult Index(int page = 1, int count = 5)
        {
            var games = this.Data.Games.All()
                .OrderBy(g => g.Title)
                .Skip((page - 1) * count)
                .Take(count)
                .Select(GameShortViewModel.Create);
            var gamesCount = this.Data.Games.All().Count();
            this.ViewBag.TotalPages = (gamesCount + count - 1) / count;
            this.ViewBag.CurrentPage = page;

            return View(games);
        }

        public ActionResult Details(int id)
        {
            var game = this.Data.Games.Find(id);
                
            if (game == null)
            {
                return this.HttpNotFound();
            }
            var gameViewModel = this.Data.Games.All()
                .Where(g => g.Id == id)
                .Select(GameDetailsViewModel.Create)
                .FirstOrDefault();
            var userId = this.User.Identity.GetUserId();
            var userHasRated = game.Ratings.Any(r => r.AuthorId == userId);
            var userRating = game.Ratings
                .Where(r => r.AuthorId == userId).Select(r => r.RatingValue).FirstOrDefault();

            this.ViewBag.UserHasRated = userHasRated;
            this.ViewBag.UserRating = userRating;

            return this.View(gameViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            var genres = this.Data.Genres.All().Select(g => new SelectListItem
            {
                Text = g.Name,
                Value = g.Id.ToString()
            });

            this.ViewBag.GenreItems = genres;
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddGameBindingModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var game = new Game
                {
                    Title = model.Title,
                    GenreId = model.GenreId,
                    Description = model.Description,
                    SystemRequirements = model.SystemRequirements
                };
                this.Data.Games.Add(game);
                this.Data.SaveChanges();
                TempData["message"] = "Successfully added a new game";
                TempData["status"] = "info";
            }
            return this.RedirectToAction("Index");
        }
    }
}