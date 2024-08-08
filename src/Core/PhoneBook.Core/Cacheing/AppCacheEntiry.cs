using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Cacheing
{
    public record AppCacheEntiry<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public AppCachePriority Priority { get; set; }
        public AppCacheExpiration Expiration { get; set; }
        public TimeSpan? ExpirationTime { get; set; }
    }
}
