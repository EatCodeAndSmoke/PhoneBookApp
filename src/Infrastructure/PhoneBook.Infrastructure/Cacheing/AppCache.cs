using Microsoft.Extensions.Caching.Memory;
using PhoneBook.Core.Cacheing;

namespace PhoneBook.Infrastructure.Cacheing
{
    public class AppCache : IAppCache
    {
        private readonly IMemoryCache _memCache;

        public AppCache(IMemoryCache memCache)
        {
            _memCache = memCache;
        }

        public ValueTask SetAsync<TKey, TValue>(TKey key, TValue value, Action<AppCacheEntryBuilder<TKey, TValue>> action = null)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions();

            if(action != null)
            {
                var entryBuilder = AppCacheEntryBuilder<TKey, TValue>.Create(key, value);
                action(entryBuilder);
                var entry = entryBuilder.Build();

                cacheEntryOptions.SetPriority(GetPriority(entry.Priority));

                if (entry.Expiration == AppCacheExpiration.Absolute)
                    cacheEntryOptions.SetAbsoluteExpiration(entry.ExpirationTime ?? TimeSpan.FromSeconds(10));
                else if (entry.Expiration == AppCacheExpiration.Sliding)
                    cacheEntryOptions.SetSlidingExpiration(entry.ExpirationTime ?? TimeSpan.FromSeconds(10));
            }
            else
            {
                cacheEntryOptions.SetPriority(CacheItemPriority.Low)
                                 .SetSlidingExpiration(TimeSpan.FromSeconds(10));
            }

            _memCache.Set(key, value, cacheEntryOptions);
            return ValueTask.CompletedTask;
        }

        public ValueTask<bool> TryGetAsync<TValue>(object key, out TValue value)
        {
            var val = _memCache.TryGetValue(key, out value);
            return ValueTask.FromResult(val);
        }

        public ValueTask Remove<TKey>(TKey key)
        {
            _memCache.Remove(key);
            return ValueTask.CompletedTask;
        }

        private static CacheItemPriority GetPriority(AppCachePriority priority)
        {
            var val = (int)priority;
            return (CacheItemPriority)val;
        }
    }
}
