using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace PhoneBook.Core.DAL
{
    public abstract class AppUnitOfWorkBase : IAppUnitOfWork
    {
        private readonly IServiceProvider _provider;
        private readonly ConcurrentDictionary<Type, object> _repositoryCache;

        protected AppUnitOfWorkBase(IServiceProvider provider)
        {
            _provider = provider;
            _repositoryCache = new ConcurrentDictionary<Type, object>();
        }

        public virtual IAppRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IAppEntity
        {
            if (_repositoryCache.TryGetValue(typeof(TEntity), out object repository))
                return repository as IAppRepository<TEntity>;

            var repo = _provider.GetRequiredService<IAppRepository<TEntity>>();
            _repositoryCache.TryAdd(typeof(TEntity), repo);
            return repo;
        }

        #region Add

        public virtual void Add<TEntity>(TEntity entity) where TEntity : class, IAppEntity
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            GetRepository<TEntity>().Add(entity);
        }

        public virtual async Task AddAsync<TEntity>(TEntity entity, CancellationToken token) where TEntity : class, IAppEntity
        {
            token.ThrowIfCancellationRequested();
            Add(entity);
            await SaveAsync(token);
        }

        public virtual void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IAppEntity
        {
            ArgumentNullException.ThrowIfNull(entities, nameof(entities));
            GetRepository<TEntity>().AddRange(entities);
        }

        public virtual async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken token) where TEntity : class, IAppEntity
        {
            token.ThrowIfCancellationRequested();
            AddRange(entities);
            await SaveAsync(token);
        }

        #endregion

        #region Update

        public virtual void Update<TEntity>(TEntity entity) where TEntity : class, IAppEntity
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            GetRepository<TEntity>().Update(entity);
        }

        public virtual async Task UpdateAsync<TEntity>(TEntity entity, CancellationToken token) where TEntity : class, IAppEntity
        {
            token.ThrowIfCancellationRequested();
            Update(entity);
            await SaveAsync(token);
        }

        public virtual void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IAppEntity
        {
            ArgumentNullException.ThrowIfNull(entities, nameof(entities));
            GetRepository<TEntity>().UpdateRange(entities);
        }

        public virtual async Task UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken token) where TEntity : class, IAppEntity
        {
            token.ThrowIfCancellationRequested();
            UpdateRange(entities);
            await SaveAsync(token);
        }

        #endregion

        #region Delete

        public virtual void Remove<TEntity>(TEntity entity) where TEntity : class, IAppEntity
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            GetRepository<TEntity>().Remove(entity);
        }

        public virtual async Task RemoveAsync<TEntity>(TEntity entity, CancellationToken token) where TEntity : class, IAppEntity
        {
            token.ThrowIfCancellationRequested();
            Remove(entity);
            await SaveAsync(token);
        }

        public virtual void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IAppEntity
        {
            ArgumentNullException.ThrowIfNull(entities, nameof(entities));
            GetRepository<TEntity>().RemoveRange(entities);
        }

        public virtual async Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken token) where TEntity : class, IAppEntity
        {
            token.ThrowIfCancellationRequested();
            RemoveRange(entities);
            await SaveAsync(token);
        }

        #endregion

        #region Read

        public virtual IQueryable<TEntity> QueryAll<TEntity>() where TEntity : class, IAppEntity
        {
            var repo = GetRepository<TEntity>();
            return repo.QueryAll();
        }


        public virtual async Task<TEntity> GetByIdAsync<TEntity>(params object[] id) where TEntity : class, IAppEntity
        {
            var repo = GetRepository<TEntity>();
            return await repo.GetByIdAsync(id);
        }

        public virtual async Task<bool> ExistsByIdAsync<TEntity>(params object[] id) where TEntity : class, IAppEntity
        {
            var repo = GetRepository<TEntity>();
            return await repo.ExistsByIdAsync(id);   
        }

        #endregion

        public abstract Task SaveAsync(CancellationToken token);
    }
}
