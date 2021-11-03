using API.BackgroundTasks;
using API.Services;

using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddSingleton<ICacheService, InMemoryCacheService>();
builder.Services.AddSingleton<IConnectionMultiplexer>(x =>
{
    return ConnectionMultiplexer.Connect(configuration.GetValue<string>("RedisConnection"));
});
builder.Services.AddSingleton<ICacheService, RedisCahceService>();
builder.Services.AddHostedService<RedisSubcriberService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
