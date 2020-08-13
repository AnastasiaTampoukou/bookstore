using bookstore.interfaces;
using System;


namespace bookstore.implementation
{
    public class BookstoreService : IBookstoreService
    {
        
        public BookstoreService()
        {
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
