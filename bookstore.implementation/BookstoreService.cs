using bookstore.interfaces;
using bUtility.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
