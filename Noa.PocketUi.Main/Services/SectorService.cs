using Noa.PocketUi.Main.Configuration;
using Noa.PocketUI.Client;

namespace Noa.PocketUi.Main.Services;

public class SectorService : ISectorService
{
    private readonly ISectorClient _sectorClient;
    private readonly IMqttService _mqttService;
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
            var location = await Geolocation.Default.GetLastKnownLocationAsync();
            _sector = await _sectorClient.GetSectorAsync(location.Latitude, location.Longitude);
            _sectorArea = await _sectorClient.GetSectorAreaAsync(location.Latitude, location.Longitude);
            await _mqttService.ResetAndSubscribeAsync(_sectorArea);
            Thread.Sleep(NOAConfiguration.SectorRefreshDelay);
        }
    });
}
