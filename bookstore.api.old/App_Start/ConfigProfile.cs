using bUtility.Logging;
using bUtility.WebApi;
using System;
using System.Data;


namespace bookstore.api.App_Start
{
    public class ConfigProfile : ConfigurationProxy
    {
        public static ConfigProfile Current { get; set; }
        public readonly Func<IDbConnection> AuditDBConnection;

        internal static ConfigProfile LoadConfigurationProfile()
        {
            Current = new ConfigProfile();
            return Current;
        }

        static readonly ILogger Logger = new bUtility.Logging.Logger("ibankApiSource");
    }
}