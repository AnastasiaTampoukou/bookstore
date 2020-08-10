using System.Web.Http;


namespace bookstore.controllers
{
    
    public class BookstoreController : ApiController
    {

        public BookstoreController() { }

        [HttpGet]
        [ActionName("savara")]
        public string Test()
        {
           
            return "Hello";
        }

        private static void RegisterBookstore()
        {
            
        }

        

    }
}
