using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.DAL;

namespace PhoneBook.Infrastructure.DAL
{
    public abstract class AppRepository<TEntity> : IAppRepository<TEntity> where TEntity : class, IAppEntity
    {
        public AppRepository(PhoneBookDbContext context)
        {
            Context = context;
            Set = Context.Set<TEntity>();
        }

        public PhoneBookDbContext Context { get; }
        public DbSet<TEntity> Set { get; }

        public IQueryable<TEntity> QueryAll() 
        {
            return Set.AsNoTracking();
        }

        public virtual async Task<TEntity> GetByIdAsync(params object[] ids)
        {
            return await Set.FindAsync(ids);
        }

        public virtual async Task<bool> ExistsByIdAsync(params object[] ids)
        {
            return await GetByIdAsync(ids) != null;
        }

        public virtual void Add(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            Set.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            ArgumentNullException.ThrowIfNull(entities, nameof(entities));
            Set.AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            Set.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            ArgumentNullException.ThrowIfNull(entities, nameof(entities));
            Set.RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            Set.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            ArgumentNullException.ThrowIfNull(entities, nameof(entities));
            Set.UpdateRange(entities);
        }
    }
}
