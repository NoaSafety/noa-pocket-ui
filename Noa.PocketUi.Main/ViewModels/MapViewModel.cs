using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Noa.PocketUi.Main.Services;
using Noa.PocketUI.Client;
using System.Collections.ObjectModel;
using Position = Microsoft.Maui.Devices.Sensors.Location;

namespace Noa.PocketUi.Main.ViewModels;

public partial class MapViewModel : ObservableObject
{
    private readonly IMqttService _mqttService;

    [ObservableProperty]
    bool isShowingUser;

    [ObservableProperty]
    ObservableCollection<PinItemViewModel> sosCalls;

    public MapViewModel(IMqttService mqttService)
    {
        _mqttService = mqttService;
        SosCalls = new ObservableCollection<PinItemViewModel>()
            {
                new PinItemViewModel("New York, USA", "The City That Never Sleeps", new Position(40.67, -73.94)),
                new PinItemViewModel("Los Angeles, USA", "City of Angels", new Position(34.11, -118.41)),
                new PinItemViewModel("San Francisco, USA", "Bay City", new Position(37.77, -122.45))
            };
        // If assigning directly IsShowingUser to true, the map isn't displaying the user location,
        // maybe a bug related to this : https://stackoverflow.com/questions/26651329/isshowinguser-not-working-in-xamarin-forms
        Task.Factory.StartNew(() => { Thread.Sleep(1000); IsShowingUser = true; });
    }

    [RelayCommand]
    private async Task SendSOSCallAsync()
    {
        var location = await Geolocation.Default.GetLastKnownLocationAsync();
        await _mqttService.SendSosAsync(location);
    }
}