using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Noa.PocketUi.Main.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUi.Main.ViewModels
{
    public partial class ConfigureViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task GoToNetworkConfigurator()
        {
            await Shell.Current.GoToAsync(nameof(NetworkConfigurator));
        }
    }
}
