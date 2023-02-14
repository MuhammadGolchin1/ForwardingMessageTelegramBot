using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingRaamVoiceBot
{
    internal static class ExtentionMethod
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value) + "/" + pc.GetDayOfMonth(value);
        }
        public static string Time(this DateTime value)
        {
            return value.Hour + ":" + value.Minute;
        }
    }
}
