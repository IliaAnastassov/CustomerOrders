using CustomerOrders.Data.Interfaces;
using CustomerOrders.Data.Repositories;
using CustomerOrders.WebAPI.Configuration;
using CustomerOrders.WebAPI.Resolver;
using CustomerOrders.WebAPI.Services;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;

namespace CustomerOrders.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IRepository, Repository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMapperService, DtoMapperService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            AutoMapperConfiguration.Configure();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var provider = new EnableCorsAttribute("*", "*", "GET");
            config.EnableCors(provider);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
