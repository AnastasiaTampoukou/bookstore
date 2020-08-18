using bookstore.implementation;
using bookstore.interfaces;
using bUtility.Logging;
using System;
using System.Security.Principal;
using System.Web.Http;

namespace bookstore.controllers
{
    public class BookstoreController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IBookstoreService _bookstoreService;
        //private readonly bUtility.ExceptionHandler _exceptionHandler;

        public BookstoreController(ILogger logger, IBookstoreService bookstoreService)
        {
            _logger = logger;
            _bookstoreService = bookstoreService;
            //_exceptionHandler = new bUtility.ExceptionHandler(logger, ex=>(ex as ), typeof(Exception) );
        }


        [HttpGet]
        public string Test()
        {
            _logger.Info($"Test endpoint called on : {_bookstoreService.Test()}");
            return "Hello from Bookstore API";
        }
        [HttpGet]
        public string TestWithException()
        {
            _logger.Info($"{_bookstoreService.TestWithException()}");
            return "Hello Exception";
        }
        [HttpPost]
        public string TestDatabaseConnection()
        {
            return _bookstoreService.TestDatabaseConnection();
        }
    }
}