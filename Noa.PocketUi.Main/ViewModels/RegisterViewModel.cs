using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Noa.PocketUi.Main.Services;
using Noa.PocketUi.Main.Views;
using System.Text.RegularExpressions;

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

            if (!Regex.IsMatch(Email, "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])"))
                throw new InvalidEmailException();

            await _authenticationService.RegisterAsync(Username, Password, Email);
            Application.Current.MainPage = new Login(new LoginViewModel(_authenticationService));
        }
        catch (InvalidEmailException ex)
        {
            Error = "Invalid Email Address";
        }
        catch (AccountAlreadyExistsException ex)
        {
            Error = "Email address already in use";
        }
        catch (Exception ex)
        {
            Error = "An error occured";
        }
    }
}