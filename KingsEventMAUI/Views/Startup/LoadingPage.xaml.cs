using KingsEventMAUI.ViewModels.Startup;

namespace KingsEventMAUI.Views.Startup;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel loadingPageViewModel)
	{
		InitializeComponent();
		BindingContext= loadingPageViewModel;
	}
}