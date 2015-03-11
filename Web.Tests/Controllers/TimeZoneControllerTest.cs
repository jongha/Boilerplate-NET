using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers.API;
using System.Web.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class TimeZoneControllerTest
    {
        [TestMethod]
        public void TimeZoneControllerGet()
        {
            TimeZoneController controller = new TimeZoneController();

            IEnumerable<TimeZoneInfo> result = controller.Get() as IEnumerable<TimeZoneInfo>;

            Assert.IsNotNull(result);
        }
    }
}
