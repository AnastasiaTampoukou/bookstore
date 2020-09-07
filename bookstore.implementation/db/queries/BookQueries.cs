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

        internal static int RemoveBook(this IDbConnection con, RemoveBookRequest request)
        {
            var deleteBook = con.Execute("DELETE FROM [dbo].[Book] WHERE Id = @Id",new { Id = request.BookId});
            if (deleteBook > 0)
            {
                return deleteBook;
            }
            else throw BookstoreException.NotBookDeleted;
            
        }

        internal static Book UpdateBook(this IDbConnection con, UpdateBookDetailsRequest request)
        {
            var newUpdate = con.Execute("UPDATE [dbo].[Book] SET [Title] = @Title, [Summary] = @Summary, [Description] = @Description WHERE Id = @Id",
                new { Id = request.BookId, Title = request.Name, Summary = request.Summary, Description = request.Description });
            if (newUpdate > 0)
            {
                Guid updatedBookId = Guid.Parse(request.BookId);
                return con.Select<Book>(new { Id = updatedBookId }).SingleOrDefault(); ;
            }
            else throw BookstoreException.NotBookUpdated;
        }
    }
}