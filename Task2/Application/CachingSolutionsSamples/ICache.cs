using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingSolutionsSamples
{
    public interface ICache
    {
        IEnumerable<T> Get<T>(string forUser) where T : new();
        void Set<T>(string forUser, IEnumerable<T> categories, int expirationTime = 5) where T : new();
    }
}
