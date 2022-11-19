using KingsEventMAUI.ViewModels.Startup;

namespace KingsEventMAUI.Views.Startup;

public partial class PhoneSignInPage : ContentPage
{
	public PhoneSignInPage(PhoneSignInPageViewModel phoneSignInPageViewModel)
	{
		InitializeComponent();
		BindingContext = phoneSignInPageViewModel;
	}
}