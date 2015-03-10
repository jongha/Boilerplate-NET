using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        ILog log = LogManager.GetLogger(typeof(MvcApplication));

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            log.Info("Application Start");

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception currentError = Server.GetLastError();

            log.Error(currentError.ToString());
        }

        private void Application_BeginRequest(object Sender, EventArgs e)
        {
            log.Info("BeginRequest: " + Sender.ToString());
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            log.Info("EndRequest: " + sender.ToString());
        }
    }
}
