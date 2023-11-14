using XCRS.Core.Utility;
using XCRS.Services.UserService.Domain.Enums;

namespace XCRS.Core.Enums
{

    public record LocationCodes : EnumerationUtil<LocationCodes> {
        public string CityName { get; set; }
        public string CityNameKo { get; set; }

        public static new LocationCodes FromDisplayName(string displayName)
        {
            if (AllItemsByName.Value.TryGetValue(displayName, out var matchingItem))
                return matchingItem;
            else 
                //값이 없을 경우 ICN을 기본값으로 출력
                return new(68, "ICN", "Incheon/Seoul", "인천/서울");
        }

        public static readonly LocationCodes ICN
          = new(88, nameof(ICN), "Incheon/Seoul", "인천/서울");
        public static readonly LocationCodes PUS
          = new(0, nameof(PUS), "Busan", "부산");
        public static readonly LocationCodes TAE
          = new(0, nameof(TAE), "Daegu", "대구");
        public static readonly LocationCodes KWJ
          = new(0, nameof(KWJ), "Gwangju", "광주");
        public static readonly LocationCodes CJJ
          = new(0, nameof(CJJ), "Cheongju", "청주");
        public static readonly LocationCodes MWX
          = new(0, nameof(MWX), "Muan", "무안");
        public static readonly LocationCodes JEU
          = new(0, nameof(JEU), "Jeju", "제주");
        public static readonly LocationCodes CJU
          = new(0, nameof(CJU), "Jeju", "제주");
        public static readonly LocationCodes YNY
          = new(0, nameof(YNY), "Yangyang", "양양");

        public LocationCodes(int value, string displayName, string cityName, string cityNameKo) : base(value, displayName)
        {
           CityName = cityName;
            CityNameKo = cityNameKo;
        }
    }
}