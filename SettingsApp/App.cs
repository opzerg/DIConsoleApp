using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SettingsApp;

internal class App : BackgroundService
{
    private readonly IConfiguration _configuration;

    public App(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Run as App");
        
        // appsettings에 각각 설정되어 있는 값을 출력
        Console.WriteLine($"{_configuration.GetValue<string>("Print")}");
        return Task.CompletedTask;
    }
}