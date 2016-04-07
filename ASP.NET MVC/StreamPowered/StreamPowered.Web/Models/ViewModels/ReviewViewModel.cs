using StreamPowered.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StreamPowered.Web.Models.ViewModels
{
    public class ReviewViewModel
    {
        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreationTime { get; set; }

        public int GameId { get; set; }

        public string Game { get; set; }

        public static Expression<Func<Review, ReviewViewModel>> Create
        {
            get
            {
                return r => new ReviewViewModel
                {
                    Content = r.Content,
                    Author = r.Author.UserName,
                    CreationTime = r.CreationTime,
                    GameId = r.GameId,
                    Game = r.Game.Title
                };
            }
        }
    }
}