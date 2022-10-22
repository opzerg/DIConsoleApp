


using ChannelApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


// Channel을 사용하여 비동기 환경에서 Queue를 사용하는 것 처럼 메시지를 전달.

var builder = Host.CreateDefaultBuilder()
    .ConfigureHostConfiguration(configure =>
    {
        configure.AddCommandLine(args);
    })
    .ConfigureServices((context, services) =>
    {
        // channel wrapper
        services.AddSingleton<IMessageChannel, MessageChannel>();
        
        // 사용자의 input을 channel에 write
        services.AddSingleton<Sender>();
        
        // channel read
        services.AddHostedService<App>();
    })
    .Build();
    
// async 실행
builder.RunAsync();

// singleton sender service get
var sender = builder.Services.GetRequiredService<Sender>();

// message input loop
await sender.SendLoop();

