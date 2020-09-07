using bookstore.implementation.db.entities;
using bookstore.types;
using bUtility.Dapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace bookstore.implementation.db.queries
{
    internal static class BookQueries
    {
        internal static IEnumerable<Book> GetBooks(this IDbConnection con)
        {
            return con.Select<Book>();
        }

        internal static Book GetBookById(this IDbConnection con, string bookId)
        {
            Guid newBookId = Guid.Parse(bookId);
            return con.Select<Book>(new { Id = newBookId }).SingleOrDefault();
        }

        internal static Book StoreBook(this IDbConnection con, StoreBookRequest request)
        {
            var newBook = new Book
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.Now,
                Title = request.Name,
                Status = "Available",
                StatusTimestamp = null,
                Description = request.Description,
                Summary = request.Summary
            };
            var newInsert = con.Execute("insert into [dbo].[Book] ([Id],[Timestamp], [Title], [Summary], [Description], [Status], [StatusTimestamp]) values (@Id, @Timestamp, @Title, @Summary, @Description, @Status, @StatusTimestamp)",
                newBook);
            if (newInsert > 0)
            {
                return newBook;
            }
            else throw BookstoreException.NotBookStored;
        }
    }
}