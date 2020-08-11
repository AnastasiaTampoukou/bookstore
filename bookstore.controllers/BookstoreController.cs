using System;
using System.Web.Http;


namespace bookstore.controllers
{
    
    public class BookstoreController : ApiController
    {

        public BookstoreController() { }

        [HttpGet]
        public string Test()
        {
            DateTime now = DateTime.Now;          
            return $"Hello the current DateTime is: {now}";
        }

        private static void RegisterBookstore()
        {
            
        }

        

    }
}
