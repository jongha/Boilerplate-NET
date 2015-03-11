using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Lib.Utils
{
    public class TimeZoneUtil
    {
        public static ICollection<TimeZoneInfo> GetTimeZones()
        {
            ICollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();

            return timeZones;
        }
    }
}
