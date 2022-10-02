using Microsoft.Extensions.Logging;

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

#if __ANDROID__ || __IOS__
        builder.UseMauiMaps();
#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
