using Microsoft.Extensions.Hosting;

namespace DefaultApp;

public class App : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Hello World!!!");
        return Task.CompletedTask;
    }
}