using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            log.Info("Home / Index");

            return View();
        }
    }
}