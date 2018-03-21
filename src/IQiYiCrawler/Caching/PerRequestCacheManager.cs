using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQiYiCrawler.Caching
{
    public class PerRequestCacheManager : ICacheManager
    {

        #region Fields

        private IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public PerRequestCacheManager(IHttpContextAccessor  httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Utilities

        /// <summary>
        /// Gets a key/value collection that can be used to share data within the scope of this request 
        /// </summary>
        protected virtual IDictionary<object, object> GetItems()
        {
            return _httpContextAccessor.HttpContext?.Items;
        }

        #endregion

        #region Methods
        public T Get<T>(string key)
        {
            var items = GetItems();
            if (items == null)
                return default(T);
            return (T)items[key];
        }
        public void Set(string key, object data, int cacheTime)
        {
            var items = GetItems();
            if (items == null)
                return;

            if (data != null)
                items[key] = data;
        }

        public bool IsSet(string key)
        {
            var items = GetItems();
            return items?[key] != null;
        }

        public void Remove(string key)
        {
            var items = GetItems();
            items?.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var items = GetItems();
            if (items == null)
                return;
            this.RemoveByPattern(pattern, items.Keys.Select(p => p.ToString()));
        }

        public void Clear()
        {
            var items = GetItems();

            items?.Clear();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

}
