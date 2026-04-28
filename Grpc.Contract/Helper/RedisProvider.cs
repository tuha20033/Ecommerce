using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace WebPortal.Grpc.Contracts.Helpers;

public interface ITokenProvider : IRedisProvider
{

}
public interface IDncProvider : IRedisProvider
{

}
public interface IMnpProvider : IRedisProvider
{
    Task<string?> GetTelcoFromCacheAsync(string phoneNumber);
}
public interface ICheckDuplicateContentProvider : IRedisProvider
{

}
public interface ICheckDuplicateIdProvider : IRedisProvider
{

}
public interface ICheckPreventPhoneNumber : IRedisProvider
{

}
public interface IRedisProvider
{
    Task SetAsync<T>(string key, T value);
    Task SetAsync<T>(string key, T value, TimeSpan timeout);
    Task<T?> GetAsync<T>(string key);
    Task<bool> RemoveAsync(string key);
    Task<bool> IsInCacheAsync(string key);
    Task<bool> SetIfNotExistAsync(string key, TimeSpan timeout);
    bool Set<T>(string key, T value, TimeSpan timeout);
    public T? Get<T>(string key);
}

public sealed class RedisProvider : IRedisProvider, ICheckDuplicateContentProvider, IDncProvider, ICheckDuplicateIdProvider, ICheckPreventPhoneNumber, ITokenProvider
{
    // To detect redundant calls
    private bool _disposedValue;

    ~RedisProvider() => Dispose(false);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private ConnectionMultiplexer? _redisClient;
    private readonly ILogger<RedisProvider>? _logger;
    public string? ConnectionString { get; private set; }
    public RedisProvider(string connectionString, IServiceProvider serviceProvider)
    {
        _logger = serviceProvider.GetService(typeof(ILogger<RedisProvider>)) as ILogger<RedisProvider>;
        ConnectionString = connectionString;
        _redisClient = GetClientAsync().Result;
    }
    private async Task<ConnectionMultiplexer?> GetClientAsync()
    {
        if (_redisClient == null && !string.IsNullOrEmpty(ConnectionString))
        {
            try
            {
                _redisClient = await ConnectionMultiplexer.ConnectAsync(ConnectionString);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "RedisProvider GetClient");
            }
        }
        return _redisClient;
    }
    public async Task SetAsync<T>(string key, T value)
    {
        await SetAsync(key, value, TimeSpan.Zero);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan timeout)
    {
        try
        {
            var connectionMultiplexer = await GetClientAsync();
            var db = connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key, JsonSerializer.Serialize(value), timeout, When.Always, CommandFlags.FireAndForget);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error set value for redis ");
            throw;
        }
    }
    public async Task<T?> GetAsync<T>(string key)
    {
        T? result = default;
        try
        {
            var connectionMultiplexer = await GetClientAsync();
            var db = connectionMultiplexer.GetDatabase();
            var data = await db.StringGetAsync(key);
            if (!string.IsNullOrEmpty(data))
                result = JsonSerializer.Deserialize<T>((string)data);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error get value for redis ");
            throw;
        }
        return result;
    }

    public async Task<bool> RemoveAsync(string key)
    {
        try
        {
            var connectionMultiplexer = await GetClientAsync();
            var db = connectionMultiplexer.GetDatabase();
            await db.KeyDeleteAsync(key);
            return true;
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error Remove value for redis");
            throw;
        }
    }

    public async Task<bool> IsInCacheAsync(string key)
    {
        try
        {
            var connectionMultiplexer = await GetClientAsync();
            var db = connectionMultiplexer.GetDatabase();
            return await db.KeyExistsAsync(key);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error Remove value for redis ");
            throw;
        }
    }

    public async Task<bool> SetIfNotExistAsync(string key, TimeSpan timeout)
    {
        try
        {
            var connectionMultiplexer = await GetClientAsync();
            IDatabase db = connectionMultiplexer.GetDatabase();
            return await db.StringSetAsync(key, 1, timeout, When.NotExists, CommandFlags.None);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error SetIfNotExist for redis");
            return true;
        }
    }
    public async Task<bool> SetIfNotExist(string key, TimeSpan timeout)
    {
        try
        {
            var connectionMultiplexer = await GetClientAsync();
            IDatabase db = connectionMultiplexer.GetDatabase();
            return db.StringSet(key, 1, timeout, When.NotExists, CommandFlags.None);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error SetIfNotExist for redis");
            return true;
        }
    }

    public async Task<T?> GetAsync<T>(string key, JsonTypeInfo<T> jsonTypeInfo)
    {
        T? result = default;
        try
        {
            var connectionMultiplexer = await GetClientAsync();
            var db = connectionMultiplexer.GetDatabase();
            var data = await db.StringGetAsync(key);
            if (!string.IsNullOrEmpty(data))
                result = JsonSerializer.Deserialize((string)data, jsonTypeInfo);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error get value for redis ");
            throw;
        }
        return result;
    }
    public async Task<T?> Get<T>(string key, JsonTypeInfo<T> jsonTypeInfo)
    {
        T? result = default;
        try
        {
            var connectionMultiplexer = await GetClientAsync();
            var db = connectionMultiplexer.GetDatabase();
            var data = db.StringGet(key);
            if (!string.IsNullOrEmpty(data))
                result = JsonSerializer.Deserialize((string)data, jsonTypeInfo);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error get value for redis ");
            throw;
        }
        return result;
    }
    public bool Set<T>(string key, T value, TimeSpan timeout)
    {
        try
        {
            var connectionMultiplexer = GetClientAsync().Result;
            var db = connectionMultiplexer.GetDatabase();
            return db.StringSet(key, JsonSerializer.Serialize(value), timeout, When.Always);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error set value for redis ");
            throw;
        }
    }
    public T? Get<T>(string key)
    {
        T? result = default;
        try
        {
            var connectionMultiplexer = GetClientAsync().Result;
            var db = connectionMultiplexer.GetDatabase();
            var data = db.StringGet(key);
            if (!string.IsNullOrEmpty(data))
                result = JsonSerializer.Deserialize<T>((string)data!);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error get value for redis ");
            throw;
        }
        return result;
    }
    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _redisClient?.Dispose();
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _disposedValue = true;
        }
    }
}

//[JsonSerializable(typeof(SmsMnp))]


