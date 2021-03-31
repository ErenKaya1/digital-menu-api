using System.Collections.Generic;

namespace DigitalMenu.Core.Cache
{
    public interface IRedisCacheService
    {
        void Set(string key, object data);
        void SetAll<T>(IDictionary<string, T> values);
        bool IsSet(string key);
        void Remove(string key);
    }
}