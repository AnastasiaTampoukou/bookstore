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
        public static readonly BookstoreException NotBookStored = new BookstoreException(1003, "The book didn't store at database");
        public static readonly BookstoreException NotBookDeleted = new BookstoreException(1004, "The book can't deleted from database or doesn't exist at database");
        public static readonly BookstoreException NotBookUpdated = new BookstoreException(1005, "The book didn't update at database");

        #endregion Technical Exceptions (1001 - 1999)

        #region Validation Exceptions (2001 - 2999)

        public static readonly BookstoreException InvalidJsonData = new BookstoreException(2001, "Invalid JSON data");
        public static readonly BookstoreException InvalidBookId = new BookstoreException(2002, "BookId must be a valid GUID");
        public static readonly BookstoreException NameNotNull = new BookstoreException(2003, "Book must have a name");
        public static readonly BookstoreException SummaryNotNull = new BookstoreException(2004, "Book must have a summary");
        public static readonly BookstoreException InvalidName = new BookstoreException(2005, "Invalid book name");
        public static readonly BookstoreException InvalidDescription = new BookstoreException(2006, "Description must have at least 1000 characters");
        public static readonly BookstoreException DescriptionNotNull = new BookstoreException(2007, "Book must have a description");
        public static readonly BookstoreException InvalidSummary = new BookstoreException(2008, "Invalid book summary");

        #endregion Validation Exceptions (2001 - 2999)

        #region Db Entity Exceptions (3001-3999)

        public static readonly BookstoreException BookNotFound = new BookstoreException(3001, "Book not found");

        #endregion Db Entity Exceptions (3001-3999)

        #endregion Exceptions
    }
}