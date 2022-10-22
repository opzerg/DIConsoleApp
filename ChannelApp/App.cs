using Microsoft.Extensions.Hosting;

namespace ChannelApp;

internal class App : BackgroundService
{
    private readonly IMessageChannel _messageChannel;

    public App(IMessageChannel messageChannel)
    {
        _messageChannel = messageChannel;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            string text = await _messageChannel.ReadAsync();
            
            Thread.Sleep(3 * 1000);
            Console.WriteLine($"readText: {text}");
        }
    }
}