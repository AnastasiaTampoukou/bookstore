using bookstore.implementation;
using bookstore.interfaces;
using bUtility.Logging;
using System;
using System.Web.Http;

namespace bookstore.controllers
{
    public class BookstoreController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IBookstoreService _book;

        public BookstoreController(ILogger logger, IBookstoreService book)
        {
            _logger = logger;
            _book = book;
        }


        [HttpGet]
        public string Test()
        {
            _logger.Info($"Test endpoint called on : {_book.Test()}");
            return "Hello from Bookstore API";
        }
    }
}