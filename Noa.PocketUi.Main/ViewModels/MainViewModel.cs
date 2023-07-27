using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Noa.PocketUi.Main.Services;
using System.Collections.ObjectModel;

namespace Noa.PocketUi.Main.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IAuthenticationService _authenticationService;

    [ObservableProperty]
    bool isAdmin;

    public MainViewModel(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
        IsAdmin = authenticationService.IsAdmin();
    }
}