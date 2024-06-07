using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendPentaNotification.ViewModel;
using System.Windows;

namespace SendPentaNotification;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
	{
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services)=> 
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();
            })
            .Build();
	}

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var startupForm = AppHost!.Services.GetRequiredService<MainWindow>();
        startupForm.Show();
        //Firebase Cloud Message 발송 세팅
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromJson(Config.FirebaseAdmJson)
        });

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}
