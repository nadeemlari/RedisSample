namespace API.Services
{
    public interface ICacheService
    {
        public Task<string> GetStringAsync(string key);
        public Task SetStringAsync(string key, string value);
    }
}
