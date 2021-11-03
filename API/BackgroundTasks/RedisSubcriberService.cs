using StackExchange.Redis;

namespace API.BackgroundTasks
{
    public class RedisSubcriberService : BackgroundService
    {
        private readonly IConnectionMultiplexer connectionMultiplexer;

        public RedisSubcriberService(IConnectionMultiplexer connectionMultiplexer)
        {
            this.connectionMultiplexer = connectionMultiplexer;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subcriber = connectionMultiplexer.GetSubscriber();
            subcriber.Subscribe("messages", (ch, val) =>
             {
                 Console.WriteLine($"message was {val}");
             });
            return Task.CompletedTask;
        }
    }
}
