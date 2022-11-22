using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Noa.PocketUi.Main.Services;
using Noa.PocketUi.Main.Views;
using Map = Noa.PocketUi.Main.Views.Map;

namespace Noa.PocketUi.Main.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
    private readonly IAuthenticationService _authenticationService;

    [ObservableProperty]
    string error;

    [ObservableProperty]
    string username;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    string email;

    public RegisterViewModel(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [RelayCommand]
    private async Task Register()
    {
        try
        {  
            Error = "";
            await _authenticationService.RegisterAsync(Username, Password, Email);
            Application.Current.MainPage = new MainPage();
        }
        catch (Exception ex)
        {
            Error = "An error occured";
        }
    }
}