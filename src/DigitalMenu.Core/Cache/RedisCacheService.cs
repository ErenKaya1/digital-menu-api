using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ServiceStack.Redis;

namespace DigitalMenu.Core.Cache
{
    public class RedisCacheService : IRedisCacheService
    {
        private int _timeout;
        private readonly RedisEndpoint _conf = null;

        public RedisCacheService(string host, int port, int timeout)
        {
            _timeout = timeout;
            _conf = new RedisEndpoint { Host = host, Port = port, Password = "", RetryTimeout = 1000 };
        }

        public void Set(string key, object data)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                {
                    var dataSerialize = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    });

                    client.Set(key, Encoding.UTF8.GetBytes(dataSerialize));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                    client.SetAll(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool IsSet(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                    return client.ContainsKey(key);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Remove(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                    client.Remove(key);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}