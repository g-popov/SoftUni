using StreamPowered.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamPowered.Web.Controllers
{
    public class GenresController : BaseController
    {
        public ActionResult Details(int id)
        {
            var genre = this.Data.Genres.All()
                .Where(g => g.Id == id)
                .Select(GenreDetailsViewModel.Create)
                .FirstOrDefault();
            return View(genre);
        }
    }
}