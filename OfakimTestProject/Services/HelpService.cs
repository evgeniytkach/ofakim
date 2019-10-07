using System;
using System.Text.RegularExpressions;

namespace OfakimTestProject.Services
{
    public class HelpService
    {

        public static DateTime GetIsraelTime()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Israel Standard Time"));
        }

        public static string GetDecimalStr(string value)
        {
            return Regex.Match(value, @"\d+.+\d").Value;
        }
    }
}