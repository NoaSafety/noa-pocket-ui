using Noa.PocketUi.Contract.Authentication;
using System.Net.Http.Json;

namespace Noa.PocketUI.Client
{
    public class AuthenticationClient : IAuthenticationClient
    {
        private readonly HttpClient _httpClient;

        public AuthenticationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SessionToken> LoginAsync(string username, string password)
        {
            var uri = new Uri(_httpClient.BaseAddress, $"tokens");
            var response = await _httpClient.PostAsJsonAsync<LoginDTO>(uri, new()
            {
                Username = username,
                Password = password
            });
            return await response.Content.ReadFromJsonAsync<SessionToken>();
        }

        public async Task<SessionToken> RegisterAsync(string username, string password, string email)
        {
            var uri = new Uri(_httpClient.BaseAddress, $"tokens/registration");
            var response = await _httpClient.PostAsJsonAsync<RegisterDTO>(uri, new()
            {
                Login = username,
                Password = password,
                Email = email
            });
            return await response.Content.ReadFromJsonAsync<SessionToken>();
        }
    }
}
