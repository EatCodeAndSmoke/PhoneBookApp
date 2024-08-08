using PhoneBook.Core.RequestBus;
using System.Linq.Expressions;

namespace PhoneBook.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> query)
        {
            return await Task.Factory.StartNew(() => query.ToList());
        }

        public static async Task<int> CountAsync<T>(this IQueryable<T> query)
        {
            return await Task.Factory.StartNew(() => query.Count());
        }

        public static async Task<int> CountAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression)
        {
            return await Task.Factory.StartNew(() => query.Where(expression).Count());
        }

        public static async Task<bool> AnyAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression)
        {
            return await Task.Factory.StartNew(() => query.Any(expression));
        }

        public static async Task<bool> AllAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression)
        {
            return await Task.Factory.StartNew(() => query.All(expression));
        }

        public static async Task<T> FirstAsync<T>(this IQueryable<T> query)
        {
            return await Task.Factory.StartNew(() => query.First());
        }

        public static async Task<T> FirstAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression)
        {
            return await Task.Factory.StartNew(() => query.First(expression));
        }

        public static async Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> query)
        {
            return await Task.Factory.StartNew(() => query.FirstOrDefault());
        }

        public static async Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression)
        {
            return await Task.Factory.StartNew(() => query.FirstOrDefault(expression));
        }

        public static async Task<T> SingleAsync<T>(this IQueryable<T> query)
        {
            return await Task.Factory.StartNew(() => query.Single());
        }

        public static async Task<T> SingleAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression)
        {
            return await Task.Factory.StartNew(() => query.Single(expression));
        }

        public static async Task<T> SingleOrDefaultAsync<T>(this IQueryable<T> query)
        {
            return await Task.Factory.StartNew(() => query.SingleOrDefault());
        }

        public static async Task<T> SingleOrDefaultAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression)
        {
            return await Task.Factory.StartNew(() => query.SingleOrDefault(expression));
        }
    }
}
