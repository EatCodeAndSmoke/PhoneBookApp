using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Cacheing
{
    public interface IAppCache
    {
        ValueTask SetAsync<TKey, TValue>(TKey key, TValue value, Action<AppCacheEntryBuilder<TKey, TValue>> action = null);
        ValueTask<bool> TryGetAsync<TValue>(object key, out TValue value);
        ValueTask Remove<TKey>(TKey key);
    }
}
