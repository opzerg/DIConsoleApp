


using DefaultApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder()
    .ConfigureHostConfiguration(configure =>
    {
        // 실행순서
        Console.WriteLine("first");
    })
    .ConfigureAppConfiguration((context, configure) =>
    {
        // 실행 인자 값 --environment로 넘어온 값이  
        // HostBuilderContext.HostingEnvironment.EnvironmentName에 set 된다
        // 위를 활용하여 설정 파일을 Development 환경과 Production 환경을 분리하여 관리할 수 있다.(launchSettings.json 참고)
        // 
        Console.WriteLine($"second {context.HostingEnvironment.EnvironmentName}");
    })
    .ConfigureServices((context, services) =>
    {
        Console.WriteLine("third");
        // 호스트앱 설정을 위해서는 IHostedService interface를 확장하거나
        // IHostedService를 확장하고 있는 BackgroundService 내장 class를 상속받아도 된다.
        services.AddHostedService<App>();
    })
    .RunConsoleAsync();