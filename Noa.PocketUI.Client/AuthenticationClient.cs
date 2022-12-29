using Noa.PocketUi.Contract.Authentication;
using Noa.PocketUI.Client;
using System.Net.Http.Json;
using System.Text.Json;

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

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidCredentialsException("Wrong Login/Password combination");

            if (response.StatusCode == System.Net.HttpStatusCode.PreconditionRequired)
                throw new MissingAccountConfirmationException("This account has not been verified");

            return await response.Content.ReadFromJsonAsync<SessionToken>();
        }

        public async Task<bool> RegisterAsync(string username, string password, string email)
        {
            var uri = new Uri(_httpClient.BaseAddress, $"tokens/registration");
            var response = await _httpClient.PostAsJsonAsync<RegisterDTO>(uri, new()
            {
                Login = username,
                Password = password,
                Email = email
            });

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                throw new AccountAlreadyExistsException("Email address already in use");

            return response.IsSuccessStatusCode;
        }

        public async Task<UserData> GetUserDataAsync(Guid id)
        {
            var uri = new Uri(_httpClient.BaseAddress, $"people/username/{id}");
            var response = await _httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UserData>(json);
        }
    }
}
