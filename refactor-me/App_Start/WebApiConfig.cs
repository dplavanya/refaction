using System.Configuration;
using System.Web.Http;
using refactor_me.Infrastructure;

namespace refactor_me
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            SetupCors(config);

            // Web API configuration and services
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            formatters.JsonFormatter.Indent = true;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void SetupCors(HttpConfiguration config)
        {
            var corsSitesAppSetting = ConfigurationManager.AppSettings["CorsSites"];

            if (string.IsNullOrWhiteSpace(corsSitesAppSetting))
            {
                throw new ConfigurationErrorsException("You are missing a CorsSites value in web.config");
            }

            var sites = corsSitesAppSetting.Split(',');

            if (sites.Length < 1)
            {
                throw new ConfigurationErrorsException("Your CorsSites contains no sites");
            }

            config.EnableCors(new ServerCorsPolicy(sites));
        }
    }
}
