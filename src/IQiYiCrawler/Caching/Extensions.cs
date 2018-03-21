using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IQiYiCrawler.Caching
{
    public static class CacheExtensions
    {
        private static int DefaultCacheTimeMinutes { get { return 60; } }

        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            //use default cache time
            return Get(cacheManager, key, DefaultCacheTimeMinutes, acquire);
        }

        private static T Get<T>(ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            if (cacheManager.IsSet(key))
                return cacheManager.Get<T>(key);

            var result = acquire();

            if (cacheTime > 0)
                cacheManager.Set(key, result, cacheTime);

            return result;
        }

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="pattern">Pattern</param>
        /// <param name="keys">All keys in the cache</param>
        public static void RemoveByPattern(this ICacheManager cacheManager, string pattern, IEnumerable<string> keys)
        {
            //get cache keys that matches pattern
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var matchesKeys = keys.Where(key => regex.IsMatch(key)).ToList();

            //remove matching values
            matchesKeys.ForEach(cacheManager.Remove);
        }
    }
}
