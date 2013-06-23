using System;

namespace NorthwindTest.Infrastructure
{
    public interface ICacheService
    {
        T Add<T>(string cacheKey, T objectToCache);
        bool Exists(string cacheKey);
        T Get<T>(string cacheKey);
        void Remove(string cacheKey);
    }
}
