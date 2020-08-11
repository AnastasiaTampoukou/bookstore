using bUtility.Logging;
using System;
using System.Web.Http;

namespace bookstore.controllers
{
    public class BookstoreController : ApiController
    {
        private readonly ILogger _logger;

        public BookstoreController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Test()
        {
            DateTime now = DateTime.Now;
            _logger.Info($"Hello the current DateTime is: {now}");

            return $"Hello the current DateTime is: {now}";
        }
    }
}