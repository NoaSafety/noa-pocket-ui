using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Noa.PocketUi.Main.Services;
using System.Collections.ObjectModel;

namespace Noa.PocketUi.Main.ViewModels;

public partial class MapViewModel : ObservableObject
{
    private readonly IMqttService _mqttService;
    private readonly ISectorService _sectorService;

    [ObservableProperty]
    bool isShowingUser;

    [ObservableProperty]
    ObservableCollection<PinItemViewModel> sosCalls = new ObservableCollection<PinItemViewModel>();

    public MapViewModel(IMqttService mqttService, ISectorService sectorService)
    {
        _mqttService = mqttService;
        _sectorService = sectorService;
        _mqttService.ConfigureSOSCallback((call) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                SosCalls.Add(new($"From {call.Name}", "SOS Call", new(call.Latitude, call.Longitude), call.Timestamp));
            });
        });
        // If assigning directly IsShowingUser to true, the map isn't displaying the user location,
        // maybe a bug related to this : https://stackoverflow.com/questions/26651329/isshowinguser-not-working-in-xamarin-forms
        Task.Factory.StartNew(() => { Thread.Sleep(2000); IsShowingUser = true; });
    }

    public async Task CheckPinsExpirationAsync()
    {
        /*foreach(var call in SosCalls)
        {
            if (call.Timestamp < DateTimeOffset.Now.ToUnixTimeSeconds() - 30)
                SosCalls.Remove(call);
        }*/
    }

    [RelayCommand]
    private async Task SendSOSCallAsync()
    {
        var location = await Geolocation.Default.GetLastKnownLocationAsync();
        await _mqttService.SendSosAsync(location, _sectorService.GetSector());
    }
}