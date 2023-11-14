﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XCRS.Gateways.Apis.Main.Customizations.Swagger
{
    public class AlterStream
    {
        public static string AlterUpstreamSwaggerJson(HttpContext context, string swaggerJson)
        {
            var swagger = JObject.Parse(swaggerJson);
            // ... alter upstream json
            return swagger.ToString(Formatting.Indented);
        }
    }
}
