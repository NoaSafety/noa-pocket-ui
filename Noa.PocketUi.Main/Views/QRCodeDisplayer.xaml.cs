using CommunityToolkit.Maui.Views;
using Noa.PocketUi.Main.ViewModels;

namespace Noa.PocketUi.Main.Views;

public partial class QRCodeDisplayer : Popup
{
	public QRCodeDisplayer(NetworkConfiguratorViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}