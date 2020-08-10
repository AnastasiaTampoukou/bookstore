using bUtility.Logging;
using System;
using System.Web.Http;

namespace bookstore.api
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly string _logSourceName = "BookstoreApiSource";
        private static readonly ILogger _logger = new Logger(_logSourceName);

        protected void Application_Start(object sender, EventArgs e)
        {
            Logger.SetCurrent(_logger);
            Logger.Current.Warn("Test");
            Logger.Current.Info("Application Started");
            WebApiConfig.Configure();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}