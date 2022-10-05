using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Noa.PocketUi.Contract.Location;
using Noa.PocketUI.Client;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Position = Microsoft.Maui.Devices.Sensors.Location;

namespace Noa.PocketUi.Main.ViewModels;

public partial class MapViewModel : ObservableObject
{
    private readonly ILocationClient _locationClient;

    [ObservableProperty]
    bool isShowingUser;

    [ObservableProperty]
    ObservableCollection<PinItemViewModel> sosCalls;

    public MapViewModel(ILocationClient locationClient)
    {
        _locationClient = locationClient;
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
    private async Task LoadSOSCallsAsync()
    {
        /*
        var requestedSOSCalls = await _locationClient.GetNearSOSCalls();
        if(SOSCalls.Any())
        {
            SOSCalls.Clear();
        }
        requestedSOSCalls.ForEach(SOSCalls.Add);*/
    }
}