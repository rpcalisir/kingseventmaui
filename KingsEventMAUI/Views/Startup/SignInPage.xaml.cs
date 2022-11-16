using KingsEventMAUI.ViewModels.Startup;

namespace KingsEventMAUI.Views.Startup;

public partial class SignInPage : ContentPage
{
	public SignInPage(SignInPageViewModel signInPageViewModel)
	{
		InitializeComponent();
		BindingContext = signInPageViewModel;
	}
}