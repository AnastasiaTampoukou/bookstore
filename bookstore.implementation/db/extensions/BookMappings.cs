using bookstore.implementation.db.entities;
using bookstore.implementation.db.queries;
using bookstore.types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace bookstore.implementation.db.extensions
{
    internal static class BookMappings
    {

        internal static BookShortDetails ToShortDetailsModel(this Book book)
        {
            // TODO: Convert database type Book to model type BookShortDetails

           /* string dateString = string.Empty;
            if (book.StatusTimestamp != null)
            {
                dateString = book.StatusTimestamp.ToString();
            }*/
            
            return new BookShortDetails
            {
                Name = book.Title,
                BookId = book.Id.ToString(),
                ShortDescription = book.Summary,
                StatusTimestamp = book.StatusTimestamp?.ToString(),
                Status = book.Status

            };
            
            

        }

        internal static List<BookShortDetails> ToShortDetailsList(this IEnumerable<Book> books)
        {
            return books?.ToList().ConvertAll(ToShortDetailsModel);
        }
    }
}