using System;
using System.Runtime.Caching;

namespace NorthwindTest.Infrastructure
{
    public class MemoryCacheService : ICacheService
    {
        private readonly MemoryCache _cache;

        public MemoryCacheService()
        {
            _cache = MemoryCache.Default;
        }

        public bool Exists(string cacheKey)
        {
            return _cache.Contains(cacheKey);
        }

        public T Get<T>(string cacheKey)
        {
            return Exists(cacheKey) ? (T)_cache[cacheKey] : default(T);
        }

        public T Add<T>(string cacheKey, T objectToCache)
        {
            _cache.Set(cacheKey,
                            objectToCache,
                            new DateTimeOffset(DateTime.Now.AddDays(1)));

            return objectToCache;
        }

        public void Remove(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }
    }
}