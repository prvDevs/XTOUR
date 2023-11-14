using System.Globalization;

namespace XCRS.Core.Utility
{
    public static class DateUtil
    {
        /// <summary>
        /// hàm parrse object to datetime
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime? ParseDateTime(object obj, string format = "")
        {
            try
            {
                if (obj == null) return null;
                if (!string.IsNullOrEmpty(format))
                {
                    return DateTime.ParseExact(obj.ToString(), format, CultureInfo.InvariantCulture);
                }
                DateTime result;
                if (DateTime.TryParse(obj.ToString(), out result))
                    return result;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string RequestDateTime(string reqDate, string format)
        {
            string reValue = "";
            DateTime reDate;

            if (!String.IsNullOrEmpty(reqDate))
            {
                if (reqDate.IndexOf("-") == -1 && reqDate.Length == 8)
                    reqDate = reqDate.Substring(0, 4) + "-" + reqDate.Substring(4, 2) + "-" + reqDate.Substring(6, 2);

                if (DateTime.TryParse(reqDate, out reDate))
                    reValue = reDate.ToString(format);
            }
            /*
            string format = "yyyyMMddHHmmss";
            string strDate = "20121129140000";

            DateTime date = DateTime.ParseExact(strDate, format, null);
            */

            return reValue;
        }
        public static bool IsDate(string Txt)
        {
            bool _return = true;
            try
            {
                DateTime _Date;
                if (String.IsNullOrEmpty(Txt))
                    _return = false;
                else
                    _Date = DateTime.Parse(Txt);
            }
            catch (Exception)
            {
                _return = false;
            }

            return _return;
        }

        public static DateTime GetDateTimeKoreaNow()
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
            var timeKorea = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
            return timeKorea;
        }
    }
}
