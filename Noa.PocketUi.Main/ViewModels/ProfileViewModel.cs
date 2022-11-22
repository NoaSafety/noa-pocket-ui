using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Noa.PocketUi.Main.Services;
using Noa.PocketUi.Main.Views;
using Plugin.NFC;
using Map = Noa.PocketUi.Main.Views.Map;

namespace Noa.PocketUi.Main.ViewModels;

public partial class ProfileViewModel : ObservableObject
{
    private readonly IAuthenticationService _authenticationService;

    [ObservableProperty]
    string userId;

    public ProfileViewModel(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
        CrossNFC.Current.OnMessageReceived += OnNFCMessageReceived;
    }

    public void LoadUserId()
    {
        UserId = _authenticationService.GetUserId().ToString();
        CrossNFC.Current.StartListening();
    }

    private void OnNFCMessageReceived(ITagInfo info)
    {
        Console.WriteLine(info);
    }
}