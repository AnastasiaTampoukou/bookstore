using bookstore.implementation;
using bookstore.interfaces;
using bookstore.types;
using bUtility.Logging;
using bUtility.WebApi;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Data;
using System.Web.Http;
using System.Web.Http.Filters;

namespace bookstore.api
{
    public static class WebApiConfig
    {
        private static readonly Container Container = new Container();

        public static void Configure(ConfigProfile cp)
        {
            try
            {
                GlobalConfiguration.Configure(httpConf =>
                {
                    RegisterRoutes(httpConf);
                    RegisterLogger();
                    RegisterServices();
                    RegisterGlobalFilters(httpConf.Filters);
                    RegisterSqlFactories(cp);
                });
            }
            catch (Exception)
            {
            }
        }

        public static void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "Default",
                "{controller}/{action}",
                null
            );
            config.Routes.MapHttpRoute(
                "API",
                "api/{controller}/{action}",
                null
            );
            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
        }

        public static void RegisterLogger()
        {
            Container.Register(() => Logger.Current, Lifestyle.Singleton);
        }
        public static void RegisterServices()
        {
            Container.Register<IBookstoreService, BookstoreService>(Lifestyle.Singleton);
        }
        public static void RegisterGlobalFilters(HttpFilterCollection filterss)
        {
            filterss.Add(new ExceptionHandlingAttribute());
        }

        public static void RegisterSqlFactories(ConfigProfile cp)
        {
            Container.RegisterSingleton<DbProvider<IDbConnection>>(() => () => cp.AuditDbConnection());
        }
        
    }
}