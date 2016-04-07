using StreamPowered.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StreamPowered.Web.Models.ViewModels
{
    public class GameShortViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double? Rating { get; set; }

        public string CoverImage { get; set; }

        public static Expression<Func<Game, GameShortViewModel>> Create
        {
            get
            {
                return g => new GameShortViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Rating = g.Ratings.Average(r => r.RatingValue),
                    CoverImage = g.ImageUrls.Select(i => i.Url).FirstOrDefault()
                };
            }
        }
    }
}