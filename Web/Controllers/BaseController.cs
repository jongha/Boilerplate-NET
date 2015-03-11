using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using Web.Lib.Helpers;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            try // for unit-test
            {
                ViewBag.SiteName = ConfigurationManager.AppSettings["SiteName"].ToString();
                ViewBag.LatestCacheTag = ConfigurationManager.AppSettings["LatestCacheTag"].ToString();
            }
            catch {
                ViewBag.SiteName = "Default Site Name";
                ViewBag.LatestCacheTag = "";
            }

            String culture = CultureHelper.GetCurrentCulture();
        }
    }
}