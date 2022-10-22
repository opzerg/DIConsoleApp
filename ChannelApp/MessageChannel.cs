using System.Threading.Channels;

namespace ChannelApp;

internal interface IMessageChannel
{
    public ValueTask WriteAsync(string msg);
    public ValueTask<string> ReadAsync();
}

public class MessageChannel : IMessageChannel
{
    private readonly Channel<string> _channel;
    public MessageChannel()
    {
        var option = new BoundedChannelOptions(3)
        {
            FullMode = BoundedChannelFullMode.Wait
        };
        _channel = Channel.CreateBounded<string>(option);
    }

    public async ValueTask WriteAsync(string msg)
    {
        await _channel.Writer.WriteAsync(msg);
    }

    public async ValueTask<string> ReadAsync()
    {
        return await _channel.Reader.ReadAsync();
    }
}