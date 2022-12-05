using Noa.PocketUi.Main.ViewModels;

namespace Noa.PocketUi.Main.Views;

public partial class Configure : ContentPage
{
	public Configure(ConfigureViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}