using System.Globalization;

namespace XCRS.Core.Utility
{
    public static class ErrorUtil
    {
        public static string GenerateErrorResult(string propertyName, object propertyValue)
        {
            return $"{propertyName.Substring(0, 1).ToLower(CultureInfo.InvariantCulture)}{propertyName.Substring(1, propertyName.Length - 1)}: {propertyValue}";
        }

        public static string GenerateErrorMessage(string name, object value)
        {
            return $"{name}: {StringUtil.ConvertObjectToString(value)}";
        }

        public static string GetExceptionMessage(Exception exception)
        {
            return exception.ToString();
        }
    }
}