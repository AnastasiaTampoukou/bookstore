using bookstore.types;
using System;

namespace bookstore.implementation
{
    internal static partial class Extensions
    {
        internal static void Validate(this GetBookDetailsRequest request)
        {
            if (request == null) throw BookstoreException.InvalidJsonData;
            if (!Guid.TryParse(request.BookId, out Guid bookIdAsGuid)) throw BookstoreException.InvalidBookId;
        }

        internal static void Validate(this StoreBookRequest request)
        {
            if (request == null) throw BookstoreException.InvalidJsonData;
            if (string.IsNullOrEmpty(request.Name)) throw BookstoreException.NameNotNull;
            if (string.IsNullOrEmpty(request.Description)) throw BookstoreException.DescriptionNotNull;
            if (string.IsNullOrEmpty(request.Summary)) throw BookstoreException.SummaryNotNull;
            if (request.Name.Length > 100) throw BookstoreException.InvalidName;
            if (request.Description.Length > 1000)  throw BookstoreException.InvalidDescription;
            if (request.Summary.Length > 250) throw BookstoreException.InvalidSummary;
        }

        internal static void Validate(this RemoveBookRequest request)
        {
            if (request == null) throw BookstoreException.InvalidJsonData;
            if (!Guid.TryParse(request.BookId, out Guid bookIdAsGuid)) throw BookstoreException.InvalidBookId;
        }

        internal static void Validate(this UpdateBookDetailsRequest request)
        {
            if (request == null) throw BookstoreException.InvalidJsonData;
            if (!Guid.TryParse(request.BookId, out Guid bookIdAsGuid)) throw BookstoreException.InvalidBookId;
            if (string.IsNullOrEmpty(request.Name)) throw BookstoreException.NameNotNull;
            if (string.IsNullOrEmpty(request.Description)) throw BookstoreException.DescriptionNotNull;
            if (string.IsNullOrEmpty(request.Summary)) throw BookstoreException.SummaryNotNull;
            if (request.Name.Length > 100) throw BookstoreException.InvalidName;
            if (request.Description.Length > 1000) throw BookstoreException.InvalidDescription;
            if (request.Summary.Length > 250) throw BookstoreException.InvalidSummary;
        }

        internal static void Validate(this BorrowBookRequest request)
        {
            if (request == null) throw BookstoreException.InvalidJsonData;
            if (!Guid.TryParse(request.BookId, out Guid bookIdAsGuid)) throw BookstoreException.InvalidBookId;
        }
        }
}