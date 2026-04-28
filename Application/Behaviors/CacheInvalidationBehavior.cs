using Application.Abstractions.Caching;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors;
// Thằng này dùng cho command khi create , update , Delete 
// Đây là lớp chen giữa của thằng Mediator ví dụ ở controller : webUI gọi await _mediator.Send(command) 
//thì nó sẽ đi qua thằng Behavior này  trước rồi mới đến handler 
public class CacheInvalidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<CacheInvalidationBehavior<TRequest, TResponse>> _logger;

    public CacheInvalidationBehavior(IMemoryCache cache, ILogger<CacheInvalidationBehavior<TRequest, TResponse>> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request,RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // TRequest request request ở đây là thằng command của từng Cqrs Create , Uddate , Delete 
        // Gọi Handler trước
        // RequestHandlerDelegate<TResponse> next thằng này là để chạy xuống thằng handler mà implent thằng command tương ứng 
        // TResponse kiểu dữ liệu trả về của thằng handler 
        var result = await next();
        // khi gọi next thì nó sẽ chạy xuống handler 

        // nếu ở command có định nghĩa thằng ICacheInvalidator này thì sẽ đánh dấu là xóa còn không có thì thôi 
        if (request is ICacheInvalidator invalidator)
        {
            foreach (var key in invalidator.CacheKeysToInvalidate)
            {
                _cache.Remove(key);
                _logger.LogDebug("Cache INVALIDATED key: {CacheKey} bởi {CommandName}", key, typeof(TRequest).Name);
            }
        }

        return result;
    }
}
