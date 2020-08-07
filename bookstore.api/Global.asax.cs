using System;
using System.Web.Http;

namespace bookstore.api
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            WebApiConfig.Configure();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}