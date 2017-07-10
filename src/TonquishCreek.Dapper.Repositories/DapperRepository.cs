using System;
using System.Diagnostics.CodeAnalysis;
using Dapper;

namespace TonquishCreek.Dapper.Repositories
{
    /// <summary>Provides a base class for a generic repository using the Dapper data access library.</summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public abstract class DapperRepository<TKey, TEntity> : ReadOnlyDapperRepository<TEntity>
    {
        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="DapperRepository{TKey, TEntity}" /> class.</summary>
        protected DapperRepository(String connectionString)
            : base(connectionString)
        {
        }
        #endregion

        #region Public Method(s)
        /// <summary>Adds the specified entity.</summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns><c>true</c> if the entity was added; otherwise, <c>false</c>.</returns>
        public Boolean Add(TEntity entity)
        {
            return AddItem(entity);
        }

        /// <summary>Removes the entity with the specified id.</summary>
        /// <param name="id">The id of the entity to remove.</param>
        /// <returns><c>true</c> if the entity was removed; otherwise, <c>false</c>.</returns>
        public Boolean Remove(TKey id)
        {
            var entity = WithId(id);

            if (entity == null)
            {
                return false;
            }

            return RemoveItem(entity);
        }

        /// <summary>Removes the specified entity.</summary>
        /// <param name="entity">The entity to remove.</param>
        /// <returns><c>true</c> if the entity was removed; otherwise, <c>false</c>.</returns>
        public Boolean Remove(TEntity entity)
        {
            return RemoveItem(entity);
        }

        /// <summary>Updates the specified entity.</summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns><c>true</c> if the entity was updated; otherwise, <c>false</c>.</returns>
        public Boolean Update(TEntity entity)
        {
            return UpdateItem(entity);
        }

        /// <summary>Returns the entity with the specified identifier (primary key).</summary>
        /// <param name="id">The identifier (primary key) of the entity to retrieve.</param>
        /// <returns>The entity with the specified identifier.</returns>
        public TEntity WithId(TKey id)
        {
            return GetItem(id);
        }
        #endregion

        #region Protected Method(s)
        /// <summary>Adds the specified entity.</summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns><c>true</c> if the entity was added; otherwise, <c>false</c>.</returns>
        protected virtual Boolean AddItem(TEntity entity)
        {
            using (var connection = CreateConnection())
            {
                connection.Insert<TKey>(entity);
            }

            return true;
        }

        /// <summary>Returns the entity with the specified identifier (primary key).</summary>
        /// <param name="id">The identifier (primary key) of the entity to retrieve.</param>
        /// <returns>The entity with the specified identifier.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)")]
        protected virtual TEntity GetItem(TKey id)
        {
            TEntity entity;

            try
            {
                using (var connection = CreateConnection())
                {
                    entity = connection.Get<TEntity>(id);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Could not retrieve an entity with the {id} identifier.", ex);
            }

            return entity;
        }

        /// <summary>Removes the specified entity.</summary>
        /// <param name="entity">The entity to remove.</param>
        /// <returns><c>true</c> if the entity was removed; otherwise, <c>false</c>.</returns>
        protected virtual Boolean RemoveItem(TEntity entity)
        {
            using (var connection = CreateConnection())
            {
                var rowsAffected = connection.Delete(entity);

                return rowsAffected > 0;
            }
        }

        /// <summary>Updates the specified entity.</summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns><c>true</c> if the entity was updated; otherwise, <c>false</c>.</returns>
        protected virtual Boolean UpdateItem(TEntity entity)
        {
            using (var connection = CreateConnection())
            {
                var rowsAffected = connection.Update(entity);

                return rowsAffected > 0;
            }
        }
        #endregion
    }
}
