using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace XCRS.Core.Utility
{
    public static class StringUtil
    {
        /// <summary>
        /// hàm parse object to string
        /// exception return ""
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object? obj)
        {
            try
            {
                if (obj == null) 
                    return string.Empty;
                
                return obj.ToString().Trim();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static object? ConvertStringToObject(string json, Type type)
        {
            object? result = null;
            try
            {
                result = JsonConvert.DeserializeObject(json, type);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }

        public static string? ConvertObjectToString(object obj)
        {
            string result = string.Empty;
            //Migration Issue : obj 예외 처리
            if (obj == null)
                return result;

            if (obj.GetType() == typeof(string))
            {
                result = obj.ToString();
            }
            else
            {
                result = JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            return result;
        }

        /// <summary>
        /// Serialize Object With Ignore Properties And Settings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objToSerialize"></param>
        /// <param name="lstIgnoreProperties"></param>
        /// <returns></returns>
        public static string SerializeWithIgnoreProperties<T>(object objToSerialize, ICollection<string>? lstIgnoreProperties = null) where T : class
        {
            if (objToSerialize == null)
            {
                return string.Empty;
            }
            lstIgnoreProperties ??= new List<string>();
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new IgnoreSerializeContractResolver<T>(lstIgnoreProperties),
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(objToSerialize, serializerSettings);
        }

        public static string SerializeWithCamelStyle(object objectToSerialize)
        {
            return objectToSerialize == null
                    ? string.Empty
                    : JsonConvert.SerializeObject(objectToSerialize,
                        new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
        }
    }

    class IgnoreSerializeContractResolver<T> : DefaultContractResolver where T : class
    {
        private ICollection<string> _lstProperties;
        public IgnoreSerializeContractResolver(ICollection<string> lstProperties)
        {
            _lstProperties = lstProperties;
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (typeof(T).IsAssignableFrom(member.DeclaringType) && _lstProperties.Contains(member.Name))
            {
                property.Ignored = true;
            }
            return property;
        }
    }
}
