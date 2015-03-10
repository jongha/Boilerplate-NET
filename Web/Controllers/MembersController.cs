using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MembersController : BaseController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MembersController));

        // GET: Members
        public ActionResult List()
        {
            log.Info("Members / Index");

            return View();
        }
    }
}