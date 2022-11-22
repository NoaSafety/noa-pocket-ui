using Noa.PocketUi.Main.ViewModels;

namespace Noa.PocketUi.Main.Views;

public partial class Profile : ContentPage
{
	public Profile(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
        BindingContext = profileViewModel;
		Loaded += (s, e) =>
        {
            profileViewModel.LoadUserId();
        };
    }
}