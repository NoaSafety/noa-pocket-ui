using Noa.PocketUi.Main.ViewModels;

namespace Noa.PocketUi.Main.Views;

public partial class Login : ContentPage
{
	public Login(LoginViewModel loginViewModel)
	{
		InitializeComponent();
        BindingContext = loginViewModel;
    }
}