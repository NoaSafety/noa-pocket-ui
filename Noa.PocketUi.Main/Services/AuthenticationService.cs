using Noa.PocketUi.Contract.Authentication;
using Noa.PocketUI.Client;

namespace Noa.PocketUi.Main.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationClient _authenticationClient;

    private SessionToken _sessionToken;

    public AuthenticationService(IAuthenticationClient authenticationClient)
    {
        _authenticationClient = authenticationClient;
    }

    public Guid GetUserId() => _sessionToken.UserId;

    public bool IsAdmin() => _sessionToken?.Role == "Admin";

    public async Task LoginAsync(string username, string password)
    {
        var token = await _authenticationClient.LoginAsync(username, password);
        _sessionToken = token;
    }

    public async Task RegisterAsync(string username, string password, string email)
    {
        var token = await _authenticationClient.RegisterAsync(username, password, email);
        _sessionToken = token;
    }
}
