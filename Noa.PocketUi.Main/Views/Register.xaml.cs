using Noa.PocketUi.Main.ViewModels;

namespace Noa.PocketUi.Main.Views;

public partial class Register : ContentPage
{
	public Register(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
        BindingContext = registerViewModel;
    }
}