using Noa.PocketUi.Contract.Authentication;

namespace Noa.PocketUi.Main.Services;

public interface IAuthenticationService
{
    Guid GetUserId();
    Task<UserData> GetUserDataAsync(Guid id);
    bool IsAdmin();
    Task LoginAsync(string username, string password);
    Task RegisterAsync(string username, string password, string email);
}
