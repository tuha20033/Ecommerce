using Application.Abstractions.Caching;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors;
// THằng này làm việc với khi gọi Query 
// thằng này nếu đã có cache thì trả luôn còn không có thì sẽ gọi database sau đó lưu cache 

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;

    public CachingBehavior(IMemoryCache cache, ILogger<CachingBehavior<TRequest, TResponse>> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request,RequestHandlerDelegate<TResponse> next,CancellationToken cancellationToken)
    {
        // Chỉ xử lý cache cho request có implement ICacheableQuery
        if (request is not ICacheableQuery cacheableQuery)
        {
            return await next();
        }

        var cacheKey = cacheableQuery.CacheKey;

        // Kiểm tra cache xem có dữ liệu hay không nếu có thì gắn vào thằng cachedResult 
        if (_cache.TryGetValue(cacheKey, out TResponse? cachedResult) && cachedResult is not null)
        {
            _logger.LogDebug("Cache HIT cho key: {CacheKey}", cacheKey);
            return cachedResult;
        }

     
        _logger.LogDebug("Cache MISS cho key: {CacheKey} → gọi Handler", cacheKey);
        var result = await next();

        // Lưu vào cache
        var expiration = cacheableQuery.Expiration ?? TimeSpan.FromMinutes(5);
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(expiration)
            .SetSize(1); 

        _cache.Set(cacheKey, result, cacheOptions);
        _logger.LogDebug("Đã cache key: {CacheKey} với TTL: {Expiration}", cacheKey, expiration);

        return result;
    }
}
