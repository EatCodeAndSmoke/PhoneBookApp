using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.DAL
{
    public interface IAppRepository<TEntity> where TEntity : class, IAppEntity
    {
        IQueryable<TEntity> QueryAll();
        Task<TEntity> GetByIdAsync(params object[] ids);
        Task<bool> ExistsByIdAsync(params object[] ids);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
