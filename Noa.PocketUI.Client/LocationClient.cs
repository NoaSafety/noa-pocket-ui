using Noa.PocketUi.Contract.Location;

namespace Noa.PocketUI.Client
{
    public class LocationClient : ILocationClient
    {
        private readonly HttpClient _httpClient;

        public LocationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SOSCall>> GetNearSOSCalls()
        {
            // TODO : actually retrieve Near SOS Calls
            Console.WriteLine(_httpClient.BaseAddress);
            return new()
            {
                new() { UserId = Guid.NewGuid() },
                new() { UserId = Guid.NewGuid() },
            };
        }
    }
}