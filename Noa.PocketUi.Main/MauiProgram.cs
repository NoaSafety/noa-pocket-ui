using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Noa.PocketUi.Main.Configuration;
using Noa.PocketUi.Main.Services;
using Noa.PocketUi.Main.ViewModels;
using Noa.PocketUi.Main.Views;
using Noa.PocketUI.Client;
using Noa.PocketUI.Main.Configuration;
using System.Reflection;
using Map = Noa.PocketUi.Main.Views.Map;

namespace Noa.PocketUi.Main;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.ConfigureServices();


#if __ANDROID__ || __IOS__
        builder.UseMauiMaps();
#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	private static void ConfigureServices(this IServiceCollection services)
	{
        services.AddHttpClients();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IMqttService, MqttService>();
        services.AddSingleton<ISectorService, SectorService>();
        services.AddTransient<MainPage>();
        services.AddTransient<Map>();
        services.AddTransient<Login>();
        services.AddTransient<Register>();
        services.AddTransient<Profile>();
        services.AddTransient<LoginViewModel>();
        services.AddTransient<RegisterViewModel>();
        services.AddTransient<MapViewModel>();
        services.AddTransient<ProfileViewModel>();
    }
}
