using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamPowered.Web.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<GameShortViewModel> Games { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; }
    }
}