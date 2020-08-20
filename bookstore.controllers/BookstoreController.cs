﻿using bookstore.implementation;
using bookstore.interfaces;
using bUtility.Logging;
using bUtility.Reflection;
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
        public void TestWithException()
        {
            try {
                _bookstoreService.TestWithException();
            } catch (Exception e) {
                _logger.Error(e.Message);
                throw;
            }
        }
        [HttpPost]
        public string TestDatabaseConnection()
        {
            return _bookstoreService.TestDatabaseConnection();
        }
        [HttpGet]
        public string GetAllBooks()
        {
            
            return "Hello ";
        }
    }
}