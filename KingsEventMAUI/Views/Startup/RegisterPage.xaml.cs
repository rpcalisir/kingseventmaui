using KingsEventMAUI.ViewModels.Startup;

namespace KingsEventMAUI.Views.Startup;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel registerPageViewModel)
	{
		InitializeComponent();
		BindingContext = registerPageViewModel;
	}
}