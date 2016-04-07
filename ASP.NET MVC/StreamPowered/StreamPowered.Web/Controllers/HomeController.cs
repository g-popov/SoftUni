using StreamPowered.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamPowered.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var topGames = this.Data.Games.All()
                .OrderByDescending(g => g.Ratings.Average(r => r.RatingValue))
                .ThenBy(g => g.Title)
                .Take(5)
                .Select(GameShortViewModel.Create);
            var latestReviews = this.Data.Reviews.All()
                .OrderByDescending(r => r.CreationTime)
                .Take(5)
                .Select(ReviewViewModel.Create);
            var homeViewModel = new HomeViewModel
            {
                Games = topGames,
                Reviews = latestReviews
            };
            return View(homeViewModel);
        }
    }
}