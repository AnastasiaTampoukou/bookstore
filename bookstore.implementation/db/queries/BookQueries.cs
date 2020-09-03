using bookstore.implementation.db.entities;
using bUtility.Dapper;
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
            // TODO: Fetch Books from database
            return con.Select<Book>();
        }
        internal static Book GetBookById(this IDbConnection con, string bookId)
        {
            Guid newBookId = Guid.Parse(bookId);
            return con.Select<Book>(new { Id = newBookId }).SingleOrDefault();
        }
    }
}