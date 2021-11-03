using API.Services;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CacheController : ControllerBase
    {
        private readonly ICacheService cacheService;

        public CacheController(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }
        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            var value = await cacheService.GetStringAsync(key);
            return value==null ? NotFound() : Ok(value);    
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CacheEntry entry)
        {
            await cacheService.SetStringAsync(entry.Key, entry.Value);
            return Ok();   
        }
    }
}