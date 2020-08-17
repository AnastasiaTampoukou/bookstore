using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.types
{
    public class GeneralTypes
    {
        public delegate T DbProvider<out T>();
    }
    
}
