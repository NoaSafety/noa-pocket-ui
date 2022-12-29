using Noa.PocketUi.Main.ViewModels;

namespace Noa.PocketUi.Main.Views;

public partial class Map : ContentPage
{

    private readonly MapViewModel _mapViewModel;

    public Map(MapViewModel mapViewModel)
    {
        InitializeComponent();
        BindingContext = mapViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _mapViewModel.CheckPinsExpirationAsync();
    }
}