using StreamPowered.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StreamPowered.Web.Models.ViewModels
{
    public class ReviewShortViewModel
    {
        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreationTime { get; set; }

        public static Expression<Func<Review,ReviewShortViewModel>> Create
        {
            get
            {
                return r => new ReviewShortViewModel
                {
                    Content = r.Content,
                    Author = r.Author.UserName,
                    CreationTime = r.CreationTime
                };
            }
        }
    }
}