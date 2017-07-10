using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Dapper;

namespace TonquishCreek.Dapper.Repositories
{
    /// <summary>Provides a base class for a generic read-only repository using the Dapper data access library.</summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public abstract class ReadOnlyDapperRepository<TEntity> : IEnumerable<TEntity>
    {
        #region Private Field(s)
        private readonly ConnectionFactory _connectionFactory;
        #endregion

        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="ReadOnlyDapperRepository{TEntity}" /> class.</summary>
        protected ReadOnlyDapperRepository(String connectionString)
        {
            _connectionFactory = new ConnectionFactory(connectionString);
        }
        #endregion

        #region Public Method(s)
        /// <summary>Returns an enumerator that iterates through the repository.</summary>
        /// <returns>An <see cref="IEnumerator{TEntity}"/> that can be used to iterate through the repository.</returns>
        public IEnumerator<TEntity> GetEnumerator()
        {
            var items = LoadItems();

            return items.GetEnumerator();
        }
        #endregion

        #region Protected Method(s)
        /// <summary>Creates a connection to the database.</summary>
        /// <returns>An <see cref="IDbConnection"/> object representing the connection.</returns>
        protected IDbConnection CreateConnection()
        {
            var connection = _connectionFactory.CreateConnection();

            return connection;
        }

        /// <summary>Returns the items contained in the repository.</summary>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> representing the items.</returns>
        protected virtual IEnumerable<TEntity> LoadItems()
        {
            using (var connection = CreateConnection())
            {
                return connection.GetList<TEntity>();
            }
        }
        #endregion

        #region IEnumerable Member(s)
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
