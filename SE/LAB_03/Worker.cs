using lab3_15.service;
using lab3_15;

namespace lab3_15;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }
    
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var userService = scope.ServiceProvider.GetRequiredService<FlightService>();
            var tcpServer = scope.ServiceProvider.GetRequiredService<TCPServer>();
            await tcpServer.StartAsync(stoppingToken);
        }
    }

}