using bookstore.implementation.db.entities;
using bookstore.types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bookstore.implementation.db.extensions
{
    internal static class BookMappings
    {
        internal static BookShortDetails ToShortDetailsModel(this Book book)
        {
            // TODO: Convert database type Book to model type BookShortDetails
            throw new NotImplementedException();
        }

        internal static List<BookShortDetails> ToShortDetailsModel(this IEnumerable<Book> books)
        {
            return books?.ToList().ConvertAll(ToShortDetailsModel);
        }
    }
}