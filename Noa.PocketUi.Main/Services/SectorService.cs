using Noa.PocketUi.Main.Configuration;
using Noa.PocketUI.Client;

namespace Noa.PocketUi.Main.Services;

public class SectorService : ISectorService
{
    private readonly ISectorClient _sectorClient;
    private readonly IMqttService _mqttService;
    private Location _currentLocation = new Location(0,0);
    private string _sector;
    private List<string> _sectorArea;

    public SectorService(ISectorClient sectorClient, IMqttService mqttService)
    {
        _sectorClient = sectorClient;
        _mqttService = mqttService;
        GetWorkerThread().Start();
    }

    public string GetSector() => _sector;

    public List<string> GetSectorArea() => _sectorArea;

    private Thread GetWorkerThread() => new(async () =>
    {
        while (true)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                _currentLocation = await Geolocation.Default.GetLastKnownLocationAsync() ?? new Location(0,0);
            });
            _sector = await _sectorClient.GetSectorAsync(_currentLocation.Latitude, _currentLocation.Longitude);
            _sectorArea = await _sectorClient.GetSectorAreaAsync(_currentLocation.Latitude, _currentLocation.Longitude);
            await _mqttService.ResetAndSubscribeAsync(_sectorArea);
            Thread.Sleep(NOAConfiguration.SectorRefreshDelay);
        }
    });
}
