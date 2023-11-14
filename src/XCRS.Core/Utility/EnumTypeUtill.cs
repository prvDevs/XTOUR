namespace XCRS.Core.Utility
{
    //about enum type
    public static class EnumTypeUtill
    {
        public static List<ET> GetInvalidEnumValues<ET>(List<ET> enumValues)
        {
            if (enumValues == null || !enumValues.Any()) return new List<ET>();

            List<ET> result = new List<ET>();
            foreach (ET enumValue in enumValues)
            {
                if (!Enum.IsDefined(typeof(ET), nameof(enumValue)))
                    result.Add(enumValue);
            }
            return enumValues;
        }

        public static List<ET> GetDuplicatedEnumValues<ET>(List<ET> enumValues) where ET : notnull
        {
            if (enumValues == null || !enumValues.Any()) return new List<ET>();

            List<ET> result = new List<ET>();
            Dictionary<ET, int> keyValuePairs = enumValues.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .ToDictionary(x => x.Key, y => y.Count());

            foreach (ET enumValue in keyValuePairs.Keys)
            {
                if (keyValuePairs[enumValue] > 1)
                    result.Add(enumValue);
            }

            return enumValues;
        }

    }
}