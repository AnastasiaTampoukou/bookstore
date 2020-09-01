using bookstore.implementation.db.entities;
using bUtility.Dapper;
using System;
using System.Collections.Generic;
using System.Data;



namespace bookstore.implementation.db.queries
{
    internal static class BookQueries
    {
        internal static IEnumerable<Book> GetBooks(this IDbConnection con)
        {
            // TODO: Fetch Books from database
            return con.Select<Book>();
        }
    }
}