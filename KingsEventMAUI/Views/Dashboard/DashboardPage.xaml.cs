using KingsEventMAUI.ViewModels.Dashboard;

namespace KingsEventMAUI.Views.Dashboard;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardPageViewModel dashboardPageViewModel)
	{
		InitializeComponent();
		BindingContext= dashboardPageViewModel;
	}
}