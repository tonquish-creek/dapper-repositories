using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace TonquishCreek.Dapper.Repositories
{
    // NOTE: There is nothing Dapper specific about this class.
    internal class ConnectionFactory
    {
        #region Private Field(s)
        private readonly String _connectionString;
        private readonly Lazy<DbProviderFactory> _factory;
        #endregion

        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="ConnectionFactory" /> class.</summary>
        /// <param name="connectionString">A <see cref="String"/> containing the connection string used to establish the initial connection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> is <c>null</c>, an empty string ("") or contains only white-space characters.</exception>
        public ConnectionFactory(String connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            _connectionString = connectionString;
            _factory = new Lazy<DbProviderFactory>(CreateProviderFactory);
        }
        #endregion

        #region Public Method(s)
        /// <summary>Returns a new database connection using the specified connection string.</summary>
        /// <returns>An <see cref="IDbConnection"/> object representing the new connection.</returns>
        public IDbConnection CreateConnection()
        {
            var connection = _factory.Value.CreateConnection();

            connection.ConnectionString = _connectionString;

            return connection;
        }
        #endregion

        #region Private Method(s)
        private DbProviderFactory CreateProviderFactory()
        {
            var providerName = GetProviderName();

            if (providerName == null)
            {
                return null;
            }

            var factory = DbProviderFactories.GetFactory(providerName);

            return factory;
        }

        private String GetProviderName()
        {
            var connectionStringBuilder = new DbConnectionStringBuilder()
            {
                ConnectionString = _connectionString
            };

            Object provider = null;

            if (connectionStringBuilder.TryGetValue("provider", out provider))
            {
                return provider.ToString();
            }

            var connectionStringSetting = ConfigurationManager.ConnectionStrings
                                                              .Cast<ConnectionStringSettings>()
                                                              .FirstOrDefault(x => x.ConnectionString == _connectionString);

            if (connectionStringSetting != null)
            {
                return connectionStringSetting.ProviderName;
            }

            return null;
        }
        #endregion
    }
}
