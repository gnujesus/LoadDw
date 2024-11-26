using LoadDW.Data.Interfaces;

namespace LoadDW.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    using (var scope = _scopeFactory.CreateScope()) {
                        var dataService = scope.ServiceProvider.GetRequiredService<IDataServiceDw>();
                        var result = await dataService.LoadDHW();
                    }

                }
                await Task.Delay(_configuration.GetValue<int>("timerTime"), stoppingToken);
            }
        }
    }
}
