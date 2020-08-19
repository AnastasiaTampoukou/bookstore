using bUtility.WebApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace bookstore.api.App_Start
{
    public class ConfigProfile : ConfigurationProxy
    {
        public static ConfigProfile Current { get; set; }

        public readonly Func<IDbConnection> AuditDbConnection = () =>
        {
            var c = new System.Data.SqlClient.SqlConnection(LoadString("auditConnection"));
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