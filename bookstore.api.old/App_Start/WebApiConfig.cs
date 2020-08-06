using bUtility.Logging;
using bUtility.WebApi;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
//using System.Web.Mvc;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace bookstore.api.App_Start
{
    public static class WebApiConfig
    {
        private static readonly Container Container = new Container();
        public static void Configure(ConfigProfile cp)
        {
            try
            {
                GlobalConfiguration.Configure((httpConf) =>
                {
                    Container.Options.DefaultScoppedLifestyle = new AsyncScoppedLifestyle();
                    RegisterLogger();
                    //RegisterSqlFactories(cp);
                    RegisterRoutes(httpConf, cp);
                    RegisterServices(cp);
                    RegisterGlobalFilters(httpConf.Filters);
                    Container.Verify();
                });
            }
            catch (Exception ex)
            {
                Logger.Current.Error(ex);
            }
        }
        private static void RegisterLogger(ConfigProfile cp)
        {
            //Logger.SetCurrent(cp.Logger);
            Container.Register(() => Logger.Current, Lifestyle.Singleton);
        }
        private static void RegisterSqlFactories(ConfigProfile cp)
        {
            //Container.Register<System.Configuration.Provider<IDbConnection>>(() => () => cp.AuditDBConnection(), Lifestyle.Singleton);
        }
        static readonly string CONTROLLER_ACTION = "ControllerAction";
        static readonly string DEFAULT_ACTION = "Default";
        public static void RegisterRoutes(HttpConfiguration config, ConfigProfile cp)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: CONTROLLER_ACTION,
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional });
            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            GlobalConfiguration.Configuration.DEpendencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
        }

        private static void RegisterServices(ConfigProfile cp)
        {
            Container.Register<IPaymentService, PaymentService>(Lifestyle.Singleton);
            Container.Register<ISandboxService, SandboxService>(Lifestyle.Singleton);
        }
        private static void RegisterServices(HttpFilterCollection filters)
        {
                filters.Add(new ExceptionHandlingAttribute());
                filters.Add(new ExceptionHandlingAttribute());
        }
           
    }
}