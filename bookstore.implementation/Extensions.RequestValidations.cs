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
    }
}