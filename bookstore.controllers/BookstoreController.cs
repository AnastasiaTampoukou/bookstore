using System.Web.Http;


namespace bookstore.controllers
{
    
    public class BookstoreController : ApiController
    {

        public BookstoreController() { }

        [HttpGet]
        public string Test()
        {
           
            return "Hello";
        }

        private static void RegisterBookstore()
        {
            
        }

        

    }
}
