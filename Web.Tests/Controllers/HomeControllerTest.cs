using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web;
using Web.Controllers;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void Sample()
        //{
        //    SampleController controller = new SampleController();

        //    ViewResult result = controller.List() as ViewResult;

        //    Assert.IsNotNull(result);
        //}
    }
}
