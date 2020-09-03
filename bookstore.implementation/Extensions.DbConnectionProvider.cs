using bookstore.types;
using bUtility.Logging;
using System;
using System.Data;

namespace bookstore.implementation
{
    internal static partial class Extensions
    {
        internal static IDbConnection SafelyInvoke(this DbProvider<IDbConnection> dbConnectionProvider, ILogger logger)
        {
            try
            {
                return dbConnectionProvider.Invoke();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Could not connect to database");
                throw BookstoreException.DatabaseConnectionError;
            }
        }
    }
}