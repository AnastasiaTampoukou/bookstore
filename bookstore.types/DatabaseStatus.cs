using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.types
{
    public class DatabaseStatus
    {
        public string DatabaseString(IDbConnection _DbConnectionProvider)
        {
            
            return $"Successfully opened connection to " +
                $"database: {_DbConnectionProvider.Database}. Connection state: {_DbConnectionProvider.State}";
        }
        
    }
}
