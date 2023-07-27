using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Noa.PocketUi.Contract.Configuration;
using Noa.PocketUi.Main.Services;
using Noa.PocketUi.Main.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Noa.PocketUi.Main.ViewModels
{

    public partial class NetworkConfiguratorViewModel : ObservableObject
    {

        [ObservableProperty]
        string ssid;

        [ObservableProperty]
        string psk;

        [ObservableProperty]
        string encryption;

        [ObservableProperty]
        string ip;

        [ObservableProperty]
        string gateway;

        [ObservableProperty]
        string dns;

        [ObservableProperty]
        string jsonConfig;

        [RelayCommand]
        private async Task GenerateQRCode()
        {
            var config = new NetworkConfiguration(Ssid, Psk, Encryption, Ip, Gateway, Dns);
            JsonConfig = JsonSerializer.Serialize(config);
            Application.Current.MainPage.ShowPopup(new QRCodeDisplayer(this));   
        }
    }
}
