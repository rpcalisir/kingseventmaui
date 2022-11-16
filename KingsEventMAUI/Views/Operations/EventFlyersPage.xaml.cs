using KingsEventMAUI.ViewModels.Operations;

namespace KingsEventMAUI.Views.Operations;

public partial class EventFlyersPage : ContentPage
{
	public EventFlyersPage(EventFlyersPageViewModel eventFlyersPageViewModel)
	{
		InitializeComponent();
		BindingContext = eventFlyersPageViewModel;
	}
}