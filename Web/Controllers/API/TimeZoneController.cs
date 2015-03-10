using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Lib.Utils;

namespace Web.Controllers.API
{
    public class TimeZoneController : ApiController
    {
        // GET: api/TimeZone?source=xxx
        public IEnumerable<TimeZoneInfo> Get([FromUri] string country)
        {
            return TimeZoneUtil.GetTimeZones(country);
        }

        // GET: api/TimeZone
        public IEnumerable<TimeZoneInfo> Get()
        {
            return Get(null);
        }


        // GET: api/TimeZone/5
        public string Get(int id)
        {
            return "value";
        }

        //// POST: api/TimeZone
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/TimeZone/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/TimeZone/5
        //public void Delete(int id)
        //{
        //}
    }
}
