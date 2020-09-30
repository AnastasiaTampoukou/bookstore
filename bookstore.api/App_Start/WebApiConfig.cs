using bookstore.implementation;
using bookstore.interfaces;
using bookstore.types;
using bUtility.Json;
using bUtility.Logging;
using bUtility.WebApi;
using ibank.Audit;
using Newtonsoft.Json;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Web.Http.Filters;

namespace bookstore.api
{
    public static class WebApiConfig
    {
        private static readonly Container Container = new Container();

        public static void Configure()
        {
            try
            {
                GlobalConfiguration.Configure(httpConf =>
                {
                    RegisterRoutes(httpConf);
                    RegisterLogger();
                    RegisterServices();
                    RegisterSqlFactories();
                    RegisterGlobalFilters(httpConf.Filters);
                });

                GlobalConfiguration.Configuration.EnsureInitialized();
                Logger.Current.Info("Application Started");
            }
            catch (Exception ex)
            {
                Logger.Current.Error(ex, "Could not initialize Application");
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
            Container.RegisterAuditService(ConfigProfile.Current.AuditDbConnection);
        }
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
            filters.Add(new ExceptionHandlingAttribute());
            filters.Add(new AuditFilterAttribute(
              Container.GetInstance<IAuditService>(),
              Logger.Current,
              AuditSerializerSettingsProvider,
              AuditFilterAttributeFactory.CreateAuditFilterConfigurator(),
              null));
        }

        private static JsonSerializerSettings AuditSerializerSettingsProvider()
        {
            var settings = new JsonSerializerSettings();
            SetAuditJsonSerializationSettings(settings);
            return settings;
        }

        private static void SetAuditJsonSerializationSettings(JsonSerializerSettings settings)
        {
            settings.ContractResolver = new GenericDataContractResolver(new List<string>());
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            settings.Error = ExceptionHandlingAttribute.OnSerializationError;
        }

        public static void RegisterSqlFactories()
        {
            Container.RegisterSingleton<DbProvider<IDbConnection>>(() => () => ConfigProfile.Current.DbConnection());
        }

        /*public static bool RegisterAuditService(this Container container,
            Func<IDbConnection> auditDbConnection)
        {
            var isRegistered = container.GetCurrentRegistrations().Any(r => r.ServiceType == typeof(IAuditService));
            if (!isRegistered)
            {
                container.Register<IAuditService>(() => new AuditService(() => auditDbConnection()));
                return true;
            }
            return false;
        }*/

    }
}