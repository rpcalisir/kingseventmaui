using KingsEventMAUI.ViewModels.Startup;

namespace KingsEventMAUI.Views.Startup;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpPageViewModel signUpPageViewModel)
	{
		InitializeComponent();
		BindingContext= signUpPageViewModel;
	}
}