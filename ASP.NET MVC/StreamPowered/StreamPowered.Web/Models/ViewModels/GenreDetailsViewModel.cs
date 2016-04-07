using StreamPowered.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StreamPowered.Web.Models.ViewModels
{
    public class GenreDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<GameShortViewModel> Games { get; set; }

        public static Expression<Func<Genre, GenreDetailsViewModel>> Create
        {
            get
            {
                return g => new GenreDetailsViewModel
                {
                    Name = g.Name,
                    Games = g.Games.AsQueryable()
                        .OrderBy(gm => gm.Title)
                        .Select(GameShortViewModel.Create)
                };
            }
        }
    }
}