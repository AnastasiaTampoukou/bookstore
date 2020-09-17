using bUtility.WebApi;
using System;
using System.Data;
using System.Data.SqlClient;

namespace bookstore.api
{
    public class ConfigProfile : ConfigurationProxy
    {
        public static ConfigProfile Current { get; set; }

        public readonly Func<IDbConnection> DbConnection = () =>
        {
            
            var c = new SqlConnection(LoadString("testConnection"));
            c.Open();
            return c;
            
        };

        public readonly Func<IDbConnection> AuditDbConnection = () =>
        {
            var c = new SqlConnection(LoadString("auditDbConnection"));
            c.Open();
            return c;
        };

        public static ConfigProfile LoadConfigurationProfile()
        {
            Current = new ConfigProfile();
            return Current;
        }
    }
}