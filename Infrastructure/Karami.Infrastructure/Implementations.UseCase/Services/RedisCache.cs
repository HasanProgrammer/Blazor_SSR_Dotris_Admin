using Karami.UseCase.Commons.Contracts.Interfaces;
using StackExchange.Redis;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

public class RedisCache : IRedisCache
{
    private readonly IDatabase _RedisDB;
        
    public RedisCache(IConnectionMultiplexer Connection) => _RedisDB = Connection.GetDatabase();

    public async Task<string> GetCacheValueAsync(string Key) => await _RedisDB.StringGetAsync(Key);

    public async Task SetCacheValueAsync(KeyValuePair<string, string> KeyValue, TimeSpan Time) => await _RedisDB.StringSetAsync(KeyValue.Key, KeyValue.Value, Time);

    public async Task<bool> DeleteKeyAsync(string Key) => await GetCacheValueAsync(Key) != null && _RedisDB.KeyDelete(Key);
}