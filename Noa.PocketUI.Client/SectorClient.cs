using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Noa.PocketUI.Client;

public class SectorClient : ISectorClient
{
    private readonly HttpClient _httpClient;

    public SectorClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetSectorAsync(double lat, double lng)
    {
        var uri = new Uri(_httpClient.BaseAddress, $"sector/?lat={lat.ToString(System.Globalization.CultureInfo.InvariantCulture)}&lng={lng.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
        var response = await _httpClient.GetAsync(uri);
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<string>(json) ?? "";
    }

    public async Task<List<string>> GetSectorAreaAsync(double lat, double lng)
    {
        var uri = new Uri(_httpClient.BaseAddress, $"sector/area/?lat={lat.ToString(System.Globalization.CultureInfo.InvariantCulture)}&lng={lng.ToString(System.Globalization.CultureInfo.InvariantCulture)}&radius={1}");
        var response = await _httpClient.GetAsync(uri);
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>() { };
    }
}
