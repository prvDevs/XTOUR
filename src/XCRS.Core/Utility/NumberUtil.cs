using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace XCRS.Core.Utility
{
    public static class NumberUtil
    {


        /// <summary>
        /// parse object to int
        /// exception return 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ParseInt(object obj)
        {
            try
            {
                int result;
                if (obj == null) return 0;
                if (int.TryParse(obj.ToString(), out result))
                    return result;
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static double ParseDouble(object obj, NumberFormatInfo provider)
        {
            try
            {
                double result;
                if (obj == null) return 0;
                if (double.TryParse(obj.ToString(), NumberStyles.Any, provider, out result))
                    if (!Double.IsInfinity(result) && !Double.IsNaN(result))
                    {
                        return result;
                    }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static float ParseFloat(object obj)
        {
            try
            {
                float result;
                if (obj == null) return 0;
                if (float.TryParse(obj.ToString(), out result))
                    return result;
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static decimal ParseDecimal(object obj)
        {
            try
            {
                decimal result;
                if (obj == null) return 0;
                var value = obj.ToString();
                if (decimal.TryParse(value, out result))
                    return result;
                if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                    return result;
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        
        public static string[] ParseStringToArray(string input)
        {
            List<string> lst = new List<string>(input.Split(','));
            return lst.ToArray();
        }

        
    }
}
