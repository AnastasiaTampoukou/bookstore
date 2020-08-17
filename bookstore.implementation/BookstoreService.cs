using bookstore.interfaces;
using System;
using System.Data;
using static bookstore.types.GeneralTypes;

namespace bookstore.implementation
{
    public class BookstoreService : IBookstoreService
    {
        private readonly DbProvider<IDbConnection> _DbConnectionProvider;
        public BookstoreService(DbProvider<IDbConnection> DbConnectionProvider)
        {
            _DbConnectionProvider = DbConnectionProvider;
        }
        
        public string Test()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd/MM/yyyy"); ;
           
        }
        public Exception TestWithException()
        {

            throw new System.Exception("This is a test exception");
        }
    }
}
