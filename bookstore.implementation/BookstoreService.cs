﻿using bookstore.interfaces;
using bookstore.types;
using bUtility.Logging;
using System;
using System.Data;

namespace bookstore.implementation
{
    public class BookstoreService : IBookstoreService
    {
        private readonly DbProvider<IDbConnection> _DbConnectionProvider;
        private readonly ILogger _logger;
        public static DatabaseStatus _databaseStatus=new DatabaseStatus();

        public BookstoreService(DbProvider<IDbConnection> DbConnectionProvider, ILogger logger)
        {
            _DbConnectionProvider = DbConnectionProvider;
            _logger = logger;
            
        }

        public string Test()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd/MM/yyyy"); ;
        }

        public void TestWithException()
        {
            throw new Exception("This is a test exception");
        }

        public string TestWithExceptionHandler()
        {
            throw new BookstoreException(103, "Hello is a test exception handler");
        }

        public string TestDatabaseConnection()
        {
            using (var connection = _DbConnectionProvider.Invoke())
            {
                _logger.Info($"Successfully opened connection to database: {_DbConnectionProvider.Invoke().Database}. Connection state: {_DbConnectionProvider.Invoke().State}");
                return _databaseStatus.DatabaseString(connection);
            }
        }
    }
}