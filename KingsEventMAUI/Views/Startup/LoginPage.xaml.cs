using KingsEventMAUI.ViewModels.Startup;

namespace KingsEventMAUI.Views.Startup;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
		BindingContext= loginPageViewModel;
	}
}