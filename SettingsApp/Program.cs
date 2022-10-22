

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SettingsApp;

// 실행 상태가 개발 환경인 경우와 실 환경인 경우를 나눠서 설정 파일을
// 관리해야 하는 경우

// 개발환경 설정 파일: appsettings.Development.json
// 실환경 설정 파일: appsettings.Production.json

// 기본적으로 아무 세팅을 하지 않으면 
// context.HostingEnvironment.EnvironmentName = Production

await Host.CreateDefaultBuilder()
    .ConfigureHostConfiguration(configure =>
    {
        // (필수) 실행 인자 값을 set
        configure.AddCommandLine(args);
    })
    .ConfigureAppConfiguration((context, configure) =>
    {
        // (선택) default로 설정되어 있는 source 파일들을 clear 해줌
        configure.Sources.Clear();
        
        // 설정 파일을 추가
        // 추가할 때 실행한 환경이 개발환경인지 실환경인지에 따라 설정파일 load
        configure.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json");
    })
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<App>();
    })
    .RunConsoleAsync();

