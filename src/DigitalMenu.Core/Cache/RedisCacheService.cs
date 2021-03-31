using System;
using ServiceStack.Redis;

namespace DigitalMenu.Core.Cache
{
    public class RedisCacheService : IRedisCacheService
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }
        private readonly RedisEndpoint _conf = null;

        public RedisCacheService()
        {
            if (string.IsNullOrEmpty(this.Host)) throw new ArgumentNullException(nameof(this.Host));
            _conf = new RedisEndpoint { Host = this.Host, Port = this.Port, Password = "", RetryTimeout = 1000 };
        }
    }
}