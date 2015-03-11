using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Web.Controllers;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class MembersControllerTest
    {
        [TestMethod]
        public void MembersControllerList()
        {
            MembersController controller = new MembersController();

            ViewResult result = controller.List() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
