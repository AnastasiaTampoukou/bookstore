using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.types
{
    public class BookstoreException : Exception
    {
        public string Code { get; set; }


        public BookstoreException(int code, string msg) : base(msg)
        {
            this.Code = $"{code}";
        }
    }
}