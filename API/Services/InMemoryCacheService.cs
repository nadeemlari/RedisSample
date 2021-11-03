using Microsoft.Extensions.Caching.Memory;

namespace API.Services
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly MemoryCache cache = new(new MemoryCacheOptions());
        public Task<string> GetStringAsync(string key)
        {
            return Task.FromResult(cache.Get<string>(key));
        }

        public Task SetStringAsync(string key, string value)
        {
            cache.Set(key, value);
            return Task.CompletedTask;
        }
    }
}
