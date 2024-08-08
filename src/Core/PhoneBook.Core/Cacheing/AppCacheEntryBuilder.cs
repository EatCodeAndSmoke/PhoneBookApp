using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Cacheing
{
    public class AppCacheEntryBuilder<TKey, TValue>
    {
        private readonly AppCacheEntiry<TKey, TValue> _entiry;

        protected AppCacheEntryBuilder(TKey key, TValue value)
        {
            _entiry = new AppCacheEntiry<TKey, TValue>
            {
                Key = key,
                Value = value
            };
        }

        public static AppCacheEntryBuilder<TKey, TValue> Create(TKey key, TValue value)
        {
            return new AppCacheEntryBuilder<TKey, TValue>(key, value);
        }

        public AppCacheEntryBuilder<TKey, TValue> WithPriority(AppCachePriority priority)
        {
            _entiry.Priority = priority;
            return this;
        }

        public AppCacheEntryBuilder<TKey, TValue> WithExpiration(TimeSpan time, AppCacheExpiration expiration = AppCacheExpiration.Sliding)
        {
            _entiry.Expiration = expiration;
            _entiry.ExpirationTime = time;
            return this;
        }

        public AppCacheEntiry<TKey, TValue> Build()
        {
            return _entiry;
        }
    }
}
