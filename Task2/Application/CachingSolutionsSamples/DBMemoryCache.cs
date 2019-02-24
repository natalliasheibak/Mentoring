using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CachingSolutionsSamples
{
    public class DBMemoryCache : ICache
    {
        public DBMemoryCache(string prefix)
        {
            this.prefix = prefix;
        }

        ObjectCache cache = MemoryCache.Default;
        CacheItemPolicy policy = new CacheItemPolicy();
        string prefix;

        public IEnumerable<T> Get<T>(string forUser) where T : new()
        {
            return (IEnumerable<T>)cache.Get(prefix + forUser);
        }

        public void Set<T>(string forUser, IEnumerable<T> entities, int expirationTime = 5) where T : new()
        {
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5);
            cache.Set(prefix + forUser, entities, policy);
        }
    }
}
