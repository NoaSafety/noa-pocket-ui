using CommunityToolkit.Mvvm.ComponentModel;
using Noa.PocketUi.Main.Services;

namespace Noa.PocketUi.Main.ViewModels;

public partial class ProfileViewModel : ObservableObject
{
    private readonly IAuthenticationService _authenticationService;

    [ObservableProperty]
    string userId;

    [ObservableProperty]
    string nfcError;

    [ObservableProperty]
    string connectionString;

    public ProfileViewModel(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task LoadUserData()
    {
        var data = await _authenticationService.GetUserDataAsync(_authenticationService.GetUserId());
        UserId = data.Id.ToString();
        ConnectionString = $"Connected as {data.UserName}";
    }
}