using bookstore.interfaces;
using bUtility.Logging;
using System;
using System.Data;
using static bookstore.types.GeneralTypes;

namespace bookstore.implementation
{
    public class BookstoreService : IBookstoreService
    {
        private readonly DbProvider<IDbConnection> _DbConnectionProvider;
        private readonly ILogger _logger;
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
        public string TestDatabaseConnection()
        {
            _DbConnectionProvider.Invoke().Open();
            _logger.Info($"Successfully opened connection to database: {_DbConnectionProvider.Invoke().Database}. Connection state: {_DbConnectionProvider.Invoke().State}");
            return $"Successfully opened connection to database: {_DbConnectionProvider.Invoke().Database}. Connection state: {_DbConnectionProvider.Invoke().State}";
        }
    }
}
