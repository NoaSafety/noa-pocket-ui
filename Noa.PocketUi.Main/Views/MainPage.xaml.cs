using Noa.PocketUi.Main.ViewModels;

namespace Noa.PocketUi.Main.Views;

public partial class MainPage : Shell
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		CurrentItem = mapItem;
		BindingContext = viewModel;
    }
}

