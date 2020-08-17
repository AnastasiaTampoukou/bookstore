using bookstore.api.App_Start;
using bookstore.controllers;
using bUtility.Logging;
using System;
using System.Web.Http;

namespace bookstore.api
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly string _logSourceName = "BookstoreApiSource";
        private static readonly ILogger _logger = new Logger(_logSourceName);
       

        protected void Application_Start(object sender, EventArgs e, ConfigProfile cp)
        {
            Logger.SetCurrent(_logger);
            WebApiConfig.Configure(cp);
            GlobalConfiguration.Configuration.EnsureInitialized();
            Logger.Current.Info("Application Started");
        }
    }
}