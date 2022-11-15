using KingsEventMAUI.Models;
using KingsEventMAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.ViewModels.Operations
{
    public partial class EventFlyersPageViewModel : BaseViewModel
    {
        #region Private Fields
        EventFlyerService eventFlyerService;

        #endregion

        #region Properties
        public ObservableCollection<EventFlyer> EventFlyers { get; } = new();

        #endregion

        #region Commands
        #endregion

        #region Public Methods
        public EventFlyersPageViewModel(EventFlyerService eventFlyerService)
        {
            this.eventFlyerService = eventFlyerService;
            GetEventFlyersAsync();
        }
        #endregion

        #region Private Implementation
        async Task GetEventFlyersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var eventFlyers = await eventFlyerService.GetEventFlyersAsync();

                if (EventFlyers.Count != 0)
                    EventFlyers.Clear();

                foreach (var eventFlyer in eventFlyers)
                    EventFlyers.Add(eventFlyer);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Unable to get event flyers: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
