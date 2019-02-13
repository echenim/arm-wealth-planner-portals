using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace Portal.Areas.Client.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }

    public static class CacheExtensions
    {
        public static void Set<T>(this IDistributedCache cache, string key, T value, DistributedCacheEntryOptions options)
        {
            cache.SetStringAsync(key, JsonConvert.SerializeObject(value), options);
        }

        public static T Get<T>(this IDistributedCache cache, string key)
        {
            var value = cache.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }
}
