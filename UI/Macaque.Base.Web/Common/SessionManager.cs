using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Macaque.Base.Web.Common
{
    /// <summary>
    /// Session wrapper, all session should be through this class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal static class SessionManager
    {
        /// <summary>
        /// Add or update session data
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Add<T>(string key, T value) where T : class
        {
            HttpContext.Current.Session[key] = value;

            AddKey(key);
        }

        /// <summary>
        /// Get session data value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetValue<T>(string key) where T : class
        {
            if (HttpContext.Current.Session != null)
                if (HttpContext.Current.Session[key] != null)
                    if (HttpContext.Current.Session[key].GetType().Equals(typeof(T)))
                        return (T)HttpContext.Current.Session[key];
            return null;
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        /// <summary>
        /// Clear all
        /// </summary>
        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }

        /// <summary>
        /// Abandon session
        /// </summary>
        public static void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }

        /// <summary>
        /// Check session contains
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool ContainsKey<T>(string key) where T : class
        {
            return GetValue<T>(key) != null;
        }

        /// <summary>
        /// Get session id
        /// </summary>
        internal static string ID
        {
            get
            {
                if (HttpContext.Current.Session != null)
                    return HttpContext.Current.Session.SessionID;
                return "0";
            }
        }

        /// <summary>
        /// Get session count
        /// </summary>
        internal static int Count
        {
            get
            {
                if (HttpContext.Current.Session != null)
                    return HttpContext.Current.Session.Count;
                return 0;
            }
        }

        /// <summary>
        /// Get session timeout
        /// </summary>
        internal static int Timeout
        {
            get
            {
                var result = 3 * 60 * 1000;

                if (HttpContext.Current.Session != null)
                {
                    var timeOutMS = HttpContext.Current.Session.Timeout * 60 * 1000;
                    result = timeOutMS - result;
                }

                return result;
            }
        }

        /// <summary>
        /// List of session keys
        /// </summary>
        internal static List<string> Keys
        {
            get
            {
                if (HttpContext.Current.Session[WebConstant.SessionKey.Key] == null)
                    return new List<string>();

                List<string> result = (List<string>)HttpContext.Current.Session[WebConstant.SessionKey.Key];
                List<string> isValid = result.Where(r => HttpContext.Current.Session[r] != null).ToList();
                isValid.Sort();
                HttpContext.Current.Session[WebConstant.SessionKey.Key] = isValid;
                return isValid;
            }
            private set
            {
                HttpContext.Current.Session[WebConstant.SessionKey.Key] = value;
            }
        }

        /// <summary>
        /// Add session key
        /// </summary>
        private static void AddKey(string key)
        {
            var sessionKeys = Keys;
            sessionKeys.Add(key);
            Keys = sessionKeys.Distinct().ToList();

        }
    }
}