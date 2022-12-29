using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;

namespace Noa.PocketUi.Main.Views;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    }
}
