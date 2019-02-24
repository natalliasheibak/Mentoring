using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CachingSolutionsSamples
{
    public class RedisCache : ICache
    {
        private ConnectionMultiplexer redisConnection;
        string prefix;

        public RedisCache(string hostName, string prefix)
        {
            redisConnection = ConnectionMultiplexer.Connect(hostName);
            this.prefix = prefix;
        }

        public IEnumerable<T> Get<T>(string forUser) where T : new()
        {
            var serializer = new DataContractSerializer(typeof(IEnumerable<T>));
            var db = redisConnection.GetDatabase();
            byte[] s = db.StringGet(prefix + forUser);
            if (s == null)
                return null;

            return (IEnumerable<T>)serializer.ReadObject(new MemoryStream(s));

        }

        public void Set<T>(string forUser, IEnumerable<T> categories, int expirationTime = 5) where T : new()
        {
            var serializer = new DataContractSerializer(typeof(IEnumerable<T>));
            var db = redisConnection.GetDatabase();
            var key = prefix + forUser;

            if (categories == null)
            {
                db.StringSet(key, RedisValue.Null, TimeSpan.FromSeconds(expirationTime));
            }
            else
            {
                var stream = new MemoryStream();
                serializer.WriteObject(stream, categories);
                db.StringSet(key, stream.ToArray(), TimeSpan.FromSeconds(expirationTime));
            }
        }
    }
}
