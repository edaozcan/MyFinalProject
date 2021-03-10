using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(String key);
        object Get(String key);
        void Add(String key, object value, int duration);
        bool IsAdd(String key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
