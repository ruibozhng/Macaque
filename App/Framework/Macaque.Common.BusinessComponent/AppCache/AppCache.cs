using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Common.BusinessComponent.AppCache
{
    public static class AppCache
    {
        private static ICacheManager cache
        {
            get { return EnterpriseLibraryContainer.Current.GetInstance<ICacheManager>(); }
        }

        public static bool Contains<T>(string key) where T : class
        {
            return GetValue<T>(key) != null;
        }

        public static T GetValue<T>(string key) where T : class
        {
            try
            {
                if (cache.Contains(key))
                    if (cache[key].GetType().Equals(typeof(T)))
                        return (T)cache[key];
            }
            catch { }
            return null;
        }

        public static void Add<T>(string key, T value) where T : class
        {
            cache.Add(key, value);

            //cache.Add(key, value,
            //    CacheItemPriority.Normal,
            //    new AppCacheRefreshAction(new AppCacheDefaultRefreshStrategy(key)),
            //    GetCacheDuration("LongCacheDuration", 15));

            __keyAdd(key);
        }

        //public static void Add<T>(string key, T value, IAppCacheRefreshStrategy refreshStrategy, CacheDuration cacheDuration) where T : class
        //{
        //    ICacheItemExpiration expiration;

        //    switch (cacheDuration)
        //    {
        //        case (CacheDuration.Long): expiration = GetCacheDuration("LongCacheDuration", 15); break;
        //        case (CacheDuration.Medium): expiration = GetCacheDuration("MediumCacheDuration", 5); break;
        //        case (CacheDuration.Short): expiration = GetCacheDuration("ShortCacheDuration", 1); break;
        //        default: expiration = new NeverExpired(); break;
        //    }

        //    cache.Add(key, value,
        //        CacheItemPriority.Normal,
        //        new AppCacheRefreshAction(refreshStrategy),
        //        expiration);

        //    __keyAdd(key);
        //}

        //private static AbsoluteTime GetCacheDuration(string configKey, int defaultValue)
        //{
        //    int numberOfMinutes = defaultValue;
        //    if (ConfigurationManager.AppSettings[configKey] != null)
        //        numberOfMinutes = Convert.ToInt32(ConfigurationManager.AppSettings[configKey]);
        //    return new AbsoluteTime(new TimeSpan(0, numberOfMinutes, 0));
        //}

        public static void Remove(string key)
        {
            cache.Remove(key);
        }

        public static void Clear()
        {
            cache.Flush();
        }

        public static int Count
        {
            get { return cache.Count; }
        }

        public enum CacheDuration
        {
            /// <summary>
            /// AppSettings["LongCacheDuration"] in minutes, OR defaultValue = 30 mins
            /// </summary>
            Long,

            /// <summary>
            /// AppSettings["MediumCacheDuration"] in minutes, OR defaultValue = 5 minutes
            /// </summary>
            Medium,

            /// <summary>
            /// AppSettings["ShortCacheDuration"] in minutes, OR defaultValue = 1 minute
            /// </summary>
            Short,

            /// <summary>
            /// No expiry date
            /// </summary>
            NeverExpired
        }

        static List<string> __key { get; set; }

        static void __keyAdd(string key)
        {
            if (__key == null)
                __key = new List<string>();
            if (__key.Contains(key) != true)
                __key.Add(key);
        }

        public static List<string> Keys
        {
            get
            {
                if (__key == null)
                    __key = new List<string>();
                foreach (var k in new List<string>(__key))
                    if (cache.Contains(k) != true)
                        __key.Remove(k);
                return __key;
            }
        }
    }
}
