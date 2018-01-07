using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace POC.EF.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Configure json formatter.
            JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;

            var settings = new JsonSerializerSettings
            {
                //looping resolve
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                //enum json conversion
                Formatting = Formatting.Indented
            };
        }
    }
}
