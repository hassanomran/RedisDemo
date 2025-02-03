namespace RedisDemo.Repo.RedisRepo
{
    public interface IRedisCacheService
    {
        Task<T?> GetCacheAsync<T>(string key);
        Task SetCacheAsync<T>(string key, T value, TimeSpan expiration);
    }
}
