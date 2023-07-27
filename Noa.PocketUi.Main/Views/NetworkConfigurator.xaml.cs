using Noa.PocketUi.Main.ViewModels;

namespace Noa.PocketUi.Main.Views;

public partial class NetworkConfigurator : ContentPage
{
	public NetworkConfigurator(NetworkConfiguratorViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}