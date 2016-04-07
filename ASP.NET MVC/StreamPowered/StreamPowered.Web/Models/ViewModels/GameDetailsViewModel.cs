using StreamPowered.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StreamPowered.Web.Models.ViewModels
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double? Rating { get; set; }

        public int GenreId { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string SystemRequirements { get; set; }

        public IEnumerable<string> Images { get; set; }

        public IEnumerable<ReviewShortViewModel> Reviews { get; set; }

        public static Expression<Func<Game, GameDetailsViewModel>>  Create 
        { 
            get
            {
                return g => new GameDetailsViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Rating = g.Ratings.Average(r => r.RatingValue),
                    GenreId = g.GenreId,
                    Genre = g.Genre.Name,
                    Description = g.Description,
                    SystemRequirements = g.SystemRequirements,
                    Images = g.ImageUrls.AsQueryable().Select(i => i.Url),
                    Reviews = g.Reviews.AsQueryable()
                        .OrderByDescending(r => r.CreationTime)
                        .Select(ReviewShortViewModel.Create)
                };
            }
        }
    }
}