using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Noa.PocketUi.Main.Services;
using Noa.PocketUi.Main.Views;

namespace Noa.PocketUi.Main.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IAuthenticationService _authenticationService;


    [ObservableProperty]
    string error;

    [ObservableProperty]
    string username;

    [ObservableProperty]
    string password;

    public LoginViewModel(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [RelayCommand]
    private async Task Login()
    {
        try
        {
            Error = "";
            await _authenticationService.LoginAsync(Username, Password);
            Application.Current.MainPage = new MainPage(new MainViewModel(_authenticationService));
        }
        catch (InvalidCredentialsException ex)
        {
            Error = "Invalid account";
        }
        catch (MissingAccountConfirmationException ex)
        {
            Error = "This account has not been verified"; 
        }
        catch (Exception ex)
        {
            Error = "An unknown error occured";
        }
    }

    [RelayCommand]
    private async Task Reg()
    {
        await Shell.Current.GoToAsync(nameof(Register));
    }
}