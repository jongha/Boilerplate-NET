using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Lib.Utils
{
    public class TimeZoneUtil
    {
        public static ICollection<TimeZoneInfo> GetTimeZones(string country)
        {
            ICollection<TimeZoneInfo> timeZones;

            if (string.IsNullOrEmpty(country))
            {
                timeZones = TimeZoneInfo.GetSystemTimeZones();
            }
            else
            {
                timeZones = new List<TimeZoneInfo>();
                
                foreach(TimeZoneInfo timeZone in GetTimeZoneById(country)) {
                    timeZones.Add(timeZone);
                }
            }

            return timeZones;
        }

        public static TimeZoneInfo[] GetTimeZoneById(string country)
        {
            switch (country.ToLower())
            {
                case "korea":
                    return new TimeZoneInfo[] { 
                        TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time") 
                    };

                case "japan":
                    return new TimeZoneInfo[] { 
                        TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time") 
                    };

                case "united states of america":
                case "usa":
                    return new TimeZoneInfo[] { 
                        TimeZoneInfo.FindSystemTimeZoneById("Samoa Standard Time"),
                        TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time"),
                        TimeZoneInfo.FindSystemTimeZoneById("Alaskan Standard Time"),
                        TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"),
                        TimeZoneInfo.FindSystemTimeZoneById("US Mountain Standard Time"),
                        TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"),
                        TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time"),
                        TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
                        TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time"),
                        TimeZoneInfo.FindSystemTimeZoneById("Atlantic Standard Time") 
                    };

                default:
                    new NotSupportedException();
                    return null;
            }
        }
    }
}
