using System;

namespace bookstore.types
{
    public class BookstoreException : Exception
    {
        private static readonly string ExceptionCodePrefix = "BKSR";
        public string Code { get; set; }

        public BookstoreException(int code, string msg) : base(msg)
        {
            this.Code = $"{code}";
        }

        public string CodeWithPrefix { get { return $"{ExceptionCodePrefix}-{Code}"; } }

        #region Exceptions

        #region Technical Exceptions (1001 - 1999)

        public static readonly BookstoreException UnrecognizedError = new BookstoreException(1001, "An unknown error occurred. Please contact  the developer or try again later");
        public static readonly BookstoreException DatabaseConnectionError = new BookstoreException(1002, "Could not connect to database");

        #endregion Technical Exceptions (1001 - 1999)

        #region Validation Exceptions (2001 - 2999)

        public static readonly BookstoreException InvalidJsonData = new BookstoreException(2001, "Invalid JSON data");
        public static readonly BookstoreException InvalidBookId = new BookstoreException(2002, "BookId must be a valid GUID");

        #endregion Validation Exceptions (2001 - 2999)

        #region Db Entity Exceptions (3001-3999)

        public static readonly BookstoreException BookNotFound = new BookstoreException(3001, "Book not found");

        #endregion Db Entity Exceptions (3001-3999)

        #endregion Exceptions
    }
}