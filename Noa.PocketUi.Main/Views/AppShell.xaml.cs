namespace Noa.PocketUi.Main.Views;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Login), typeof(Login));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(Register), typeof(Register));
        Routing.RegisterRoute(nameof(NetworkConfigurator), typeof(NetworkConfigurator));
    }
}
