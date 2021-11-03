using StackExchange.Redis;

namespace API.Services
{
    public class RedisCahceService : ICacheService
    {
        private readonly IConnectionMultiplexer connectionMultiplexer;

        public RedisCahceService(IConnectionMultiplexer connectionMultiplexer)
        {
            this.connectionMultiplexer = connectionMultiplexer;
        }
        public async Task<string> GetStringAsync(string key)
        {
            var db = connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public async Task SetStringAsync(string key, string value)
        {
            var db = connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key, value);    
        }
    }
}
