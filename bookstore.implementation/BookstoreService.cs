using bookstore.interfaces;
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

        public BookstoreService(DbProvider<IDbConnection> DbConnectionProvider, ILogger logger)
        {
            _DbConnectionProvider = DbConnectionProvider;
            _logger = logger;
        }

        public string Test()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd/MM/yyyy");
        }

        public void TestWithException()
        {
            throw new Exception("This is a test exception");
        }

        public string TestWithExceptionHandler()
        {
            throw new BookstoreException(103, "Hello is a test exception handler");
        }

        public DatabaseStatus TestDatabaseConnection()
        {
            using (var connection = _DbConnectionProvider.Invoke())
            {
                var response = new DatabaseStatus();
                response.StatusMessage = $"Successfully opened connection to database: {_DbConnectionProvider.Invoke().Database}. Connection state: {_DbConnectionProvider.Invoke().State}";
                _logger.Info(response.StatusMessage);
                return response;
            }
        }

        public GetAllBooksResponse GetAllBooks()
        {
            // Step 1: Fetch books from database (datatype: List<Book>)
            // Step 2: Convert List<Book> to List GetAllBooksResponse
            // Step 3: Return response
            throw new NotImplementedException();
        }
    }
}