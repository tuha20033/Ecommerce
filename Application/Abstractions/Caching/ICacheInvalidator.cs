namespace Application.Abstractions.Caching;


public interface ICacheInvalidator
{

    string[] CacheKeysToInvalidate { get; }
}
