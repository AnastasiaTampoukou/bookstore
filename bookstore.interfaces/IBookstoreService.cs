using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.interfaces
{
    public interface IBookstoreService
    {
        void TestWithException();
        string TestWithExceptionHandler();
        string Test();
        string TestDatabaseConnection();


    }
}
