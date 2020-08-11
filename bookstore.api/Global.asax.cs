﻿using bookstore.controllers;
using bUtility.Logging;
using System;
using System.Web.Http;

namespace bookstore.api
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly string _logSourceName = "BookstoreApiSource";
        private static readonly ILogger _logger = new Logger(_logSourceName);
        private static readonly BookstoreController bookStoreController = new BookstoreController();

        protected void Application_Start(object sender, EventArgs e)
        {
            Logger.SetCurrent(_logger);
            //Logger.Current.Warn("Test");
            Logger.Current.Info("Application Started");
            Logger.Current.Info(bookStoreController.Test());
            WebApiConfig.Configure();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}