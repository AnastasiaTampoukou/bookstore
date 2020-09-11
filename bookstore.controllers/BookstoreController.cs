using bookstore.interfaces;
using bookstore.types;
using bUtility.Logging;
using ibank.Hosting.WebApi;
using System;
using System.Web.Http;

namespace bookstore.controllers
{
    public class BookstoreController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IBookstoreService _bookstoreService;
        private readonly bUtility.ExceptionHandler _exceptionHandler;

        public BookstoreController(ILogger logger, IBookstoreService bookstoreService)
        {
            _logger = logger;
            _bookstoreService = bookstoreService;
            _exceptionHandler = new bUtility.ExceptionHandler(logger, ex => (ex as BookstoreException)?.CodeWithPrefix, typeof(BookstoreException));
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
            try
            {
                _bookstoreService.TestWithException();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                throw;
            }
        }

        [HttpGet]
        public Response<string> TestWithExceptionHandler()
        {
            return _exceptionHandler.SafeExecutor<string>(() => _bookstoreService.TestWithExceptionHandler());
        }

        [HttpPost]
        public Response<DatabaseStatus> TestDatabaseConnection()
        {
            return _exceptionHandler.SafeExecutor(() => _bookstoreService.TestDatabaseConnection());
        }

        [HttpPost]
        public Response<GetAllBooksResponse> GetAllBooks()
        {
            return _exceptionHandler.SafeExecutor(() => _bookstoreService.GetAllBooks());
        }

        [HttpPost]
        public Response<GetBookDetailsResponse> GetBookDetails(Request<GetBookDetailsRequest> request)
        {
            return _exceptionHandler.SafeExecutor(() => _bookstoreService.GetBookDetails(request?.Payload));
        }

        [HttpPost]
        public Response<StoreBookResponse> StoreBook(Request<StoreBookRequest> request)
        {
            return _exceptionHandler.SafeExecutor(() => _bookstoreService.StoreBook(request?.Payload));
        }

        [HttpPost]
        public Response<RemoveBookResponse> RemoveBook(Request<RemoveBookRequest> request)
        {
            return _exceptionHandler.SafeExecutor(() => _bookstoreService.RemoveBook(request?.Payload));
        }

        [HttpPost]
        public Response<UpdateBookDetailsResponse> UpdateBook(Request<UpdateBookDetailsRequest> request)
        {
            return _exceptionHandler.SafeExecutor(() => _bookstoreService.UpdateBook(request?.Payload));
        }

        [HttpPost]
        public Response<BorrowBookResponse> BorrowBook(Request<BorrowBookRequest> request)
        {
            return _exceptionHandler.SafeExecutor(() => _bookstoreService.BorrowBook(request?.Payload));
        }

        [HttpPost]
        public Response<ReturnBookResponse> ReturnBook(Request<ReturnBookRequest> request)
        {
            return _exceptionHandler.SafeExecutor(() => _bookstoreService.ReturnBook(request?.Payload));
        }
    }
}