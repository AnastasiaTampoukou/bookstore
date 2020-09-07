using bookstore.types;
using System;
using System.Linq;

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
            if (request.Name == null) throw BookstoreException.NameNotNull;
            if (request.Description == null) throw BookstoreException.DescriptionNotNull;
            if (request.Summary == null) throw BookstoreException.SummaryNotNull;
            if (request.Name.Count() > 100) throw BookstoreException.InvalidName;
            if (request.Description.Count() > 1000)  throw BookstoreException.InvalidDescription;
            if (request.Summary.Count() > 250) throw BookstoreException.InvalidSummary;
        }
    }
}