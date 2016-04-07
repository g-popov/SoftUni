using Microsoft.AspNet.Identity;
using StreamPowered.Data;
using StreamPowered.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamPowered.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
            : this(new StreamPoweredData(new ApplicationDbContext()))
        {
        }

        public BaseController(IStreamPoweredData data)
        {
            this.Data = data;
        }

        protected IStreamPoweredData Data { get; private set; }

        public bool isAdmin()
        {
            var userId = this.User.Identity.GetUserId();
            var isAdmin = (userId != null && this.User.IsInRole("Admin"));
            return isAdmin;
        }
    }
}