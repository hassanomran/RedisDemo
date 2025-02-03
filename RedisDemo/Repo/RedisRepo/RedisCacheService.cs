
using System.Text.Json;
using StackExchange.Redis;

namespace RedisDemo.Repo.RedisRepo
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }
        public async Task<T?> GetCacheAsync<T>(string key)
        {
            var db = _redis.GetDatabase();
            var data = await db.StringGetAsync(key);
            return data.IsNullOrEmpty ? default : JsonSerializer.Deserialize<T>(data!);
        }

        public async Task SetCacheAsync<T>(string key, T value, TimeSpan expiration)
        {
            var db = _redis.GetDatabase();
            var jsonData = JsonSerializer.Serialize(value);
            await db.StringSetAsync(key, jsonData, expiration);
        }
    }
}
