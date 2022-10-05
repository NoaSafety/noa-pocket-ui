using Noa.PocketUi.Main.ViewModels;

namespace Noa.PocketUi.Main.Views;

public partial class Map : ContentPage
{
	public Map(MapViewModel mapViewModel)
	{
		InitializeComponent();
        BindingContext = mapViewModel;
    }
}