using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;

namespace ChannelApp;

internal class Sender
{
    private readonly IMessageChannel _messageChannel;
    private readonly IHostApplicationLifetime _lifetime;

    public Sender(IMessageChannel messageChannel,
        IHostApplicationLifetime lifetime)
    {
        _messageChannel = messageChannel;
        _lifetime = lifetime;
    }

    public async ValueTask SendLoop()
    {
        while (!_lifetime.ApplicationStopping.IsCancellationRequested)
        {
            var text = Console.ReadLine();
            
            if (string.IsNullOrEmpty(text))
                continue;
            
            await _messageChannel.WriteAsync(text);
            
            Console.WriteLine($"sendText: {text}");
        }
    }
}