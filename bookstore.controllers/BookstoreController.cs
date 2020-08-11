using bUtility.Logging;
using System;
using System.Web.Http;


namespace bookstore.controllers
{
    
    public class BookstoreController : ApiController
    {
        private static readonly string _logSourceName = "BookstoreApiSource";
        private static readonly ILogger _logger = new Logger(_logSourceName);

        public BookstoreController() { }

        [HttpGet]
        public string Test()
        {
            DateTime now = DateTime.Now;
            Logger.Current.Info($"Hello the current DateTime is: {now}");
               
            return $"Hello the current DateTime is: {now}";
        }

        private static void RegisterBookstore()
        {
            
        }

        

    }
}
