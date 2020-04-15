using MySql.Data.MySqlClient;

namespace TinyAchievements.Commons.DataAccess
{
    public class MySqlConnectionHelper
    {
        private readonly string _connectionString;

        public MySqlConnectionHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Obtains a new MySqlConnection, based on the previously injected connection string.  
        /// The caller is expected to ensure the connection is opened / closed as appropriate
        /// </summary>
        /// <remarks>
        /// Note that no attempt is made here to deal with connection pooling / thread pooling.
        /// It is assumed this is happening at the driver-level. The MySql documentation strongly
        /// discourages the consumer from making any attempt to pool connections,
        /// and strongly encourages you to use the underlying functionality.
        /// </remarks>
        /// <returns>A new MySqlConnection, initialized with the given connection string.</returns>
        public MySqlConnection GetConnection() => new MySqlConnection(_connectionString);
    }
}
