﻿using bookstore.implementation.db.extensions;
using bookstore.implementation.db.queries;
using bookstore.interfaces;
using bookstore.types;
using bUtility.Logging;
using System;
using System.Data;
using System.Linq;

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
            using (var connection = _DbConnectionProvider.SafelyInvoke(_logger))
            {
                var books = connection.GetBooks().ToList();
                var booksShortDetailsList = books.ToShortDetailsList();
                return new GetAllBooksResponse { Books = booksShortDetailsList };
            }
        }

        public GetBookDetailsResponse GetBookDetails(GetBookDetailsRequest request)
        {
            request.Validate();
            using (var connection = _DbConnectionProvider.SafelyInvoke(_logger))
            {
                var book = connection.GetBookById(request.BookId);
                if (book == null) throw BookstoreException.BookNotFound;
                var booksDetails = book.ToDetailsModel();
                return new GetBookDetailsResponse { BookDetails = booksDetails };
            }
        }
    }
}