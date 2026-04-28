namespace Application.Abstractions.Caching;

/// <summary>
/// Đánh dấu Query nào cần được cache tự động bởi CachingBehavior.
/// Chỉ cần implement interface này, pipeline sẽ tự xử lý cache.
/// </summary>
public interface ICacheableQuery
{
    /// <summary>
    /// Key dùng để lưu/truy xuất cache. Ví dụ: "products-all", "product-{id}"
    /// </summary>
    string CacheKey { get; }

    /// <summary>
    /// Thời gian cache tồn tại. Mặc định 5 phút nếu null.
    /// </summary>
    TimeSpan? Expiration => null;
}
