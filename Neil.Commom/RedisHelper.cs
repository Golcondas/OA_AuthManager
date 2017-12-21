using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neil.Commom
{
    public class RedisHelper
    {
        #region static field
        static string redisIp = System.Configuration.ConfigurationManager.AppSettings["redisIp"].ToString();
        static string redisPort = ConfigurationManager.AppSettings["redisPort"].ToString();
        static string redisPassword = ConfigurationManager.AppSettings["redisPassword"].ToString();
        static RedisClient client = new RedisClient(redisIp, 6379);

        public static void SetPassword()
        {
            client.Password = redisPassword;
        }

        public RedisHelper()
        {
            client.Password = redisPassword;
        }

        #endregion
        #region
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>对象</returns>
        public static T Get<T>(string token) where T : class,new()
        {
            if (client.Password == null)
            {
                SetPassword();
            }
            return client.Get<T>(token);
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>对象</returns>
        public static String GetString(string token)
        {
            if (client.Password == null)
            {
                SetPassword();
            }
            return client.Get<String>(token);
        }
        /// <summary>
        /// 设置信息
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="token">key</param>
        /// <param name="obj">对象</param>
        public static bool Set<T>(string token, T obj) where T : class,new()
        {
            if (client.Password == null)
            {
                SetPassword();
            }
           return client.Set<T>(token, obj);
        }

        /// <summary>
        /// 设置信息
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="token">key</param>
        /// <param name="obj">对象</param>
        public static bool SetString(string token, string value)
        {
            if (client.Password == null)
            {
                SetPassword();
            }
            return client.Set<String>(token, value);
        }

        public static bool SetTime<T>(string token, DateTime dt, T obj) where T : class,new() 
        {
            if (client.Password == null)
            {
                SetPassword();
            }
            return client.Set<T>(token, obj, dt);
        }

        /// <summary>
        /// 设置信息
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="token">key</param>
        /// <param name="obj">对象</param>
        public static bool SetStringTime(string token, string value,DateTime dt)
        {
            if (client.Password == null)
            {
                SetPassword();
            }
            return client.Set<String>(token, value, dt);
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static int DelKey(params string[] keys) 
        {
            if (client.Password == null)
            {
                SetPassword();
            }
            return client.Del(keys);
        }

        /// <summary>
        /// 设置指定Key的过期时间
        /// </summary>
        /// <param name="token">具体的key值</param>
        /// <param name="seconds">过期时间，单位：秒</param>
        public static int Expire(string token, int seconds)
        {
            if (client.Password == null)
            {
                SetPassword();
            }
           return client.Expire(token, seconds);
        }
        #endregion
    }
}
