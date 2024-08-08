using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.DAL
{
    public interface IAppUnitOfWork
    {
        IAppRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IAppEntity;

        // add
        void Add<TEntity>(TEntity entity) where TEntity : class, IAppEntity;
        Task AddAsync<TEntity>(TEntity entity, CancellationToken token) where TEntity : class, IAppEntity;
        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IAppEntity;
        Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken token) where TEntity : class, IAppEntity;

        // update
        void Update<TEntity>(TEntity entity) where TEntity : class, IAppEntity;
        Task UpdateAsync<TEntity>(TEntity entity, CancellationToken token) where TEntity : class, IAppEntity;
        void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IAppEntity;
        Task UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken token) where TEntity : class, IAppEntity;

        // remove
        void Remove<TEntity>(TEntity entity) where TEntity : class, IAppEntity;
        Task RemoveAsync<TEntity>(TEntity entity, CancellationToken token) where TEntity : class, IAppEntity;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IAppEntity;
        Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken token) where TEntity : class, IAppEntity;

        // read
        IQueryable<TEntity> QueryAll<TEntity>() where TEntity : class, IAppEntity;
        Task<TEntity> GetByIdAsync<TEntity>(params object[] ids) where TEntity : class, IAppEntity;

        // save
        Task SaveAsync(CancellationToken token);
    }
}
