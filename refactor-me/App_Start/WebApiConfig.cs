using System;
using System.Configuration;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.WebApi;
using Microsoft.Practices.ServiceLocation;
using refactor_me.Infrastructure;
using refactor_me.Services;
using Refactorme.Repository;
using Refactorme.Repository.Contracts;
using Refactorme.Data;
using Refactorme.Logging;

namespace refactor_me
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            SetupCors(config);
            SetupRoute(config);
            SetupAutofac(config);

            // Web API configuration and services
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            formatters.JsonFormatter.Indent = true;
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

        private static void SetupRoute(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void SetupAutofac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Services

            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductOptionService>().As<IProductOptionService>();

            //Repositories
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductOptionRepository>().As<IProductOptionRepository>();

            // Logging
            builder.RegisterType<Log4NetLogger>().As<ILogger>().SingleInstance();

            var container = builder.Build();
            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
