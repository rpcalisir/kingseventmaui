using KingsEventMAUI.Models;
using KingsEventMAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.ViewModels
{
    public class EventFlyerViewModel : BaseViewModel
    {
        EventFlyerService eventFlyerService;

        public ObservableCollection<EventFlyer> EventFlyers { get; } = new();
        public EventFlyerViewModel(EventFlyerService eventFlyerService)
        {
            Title = "EVENTS";
            this.eventFlyerService = eventFlyerService;
        }


        async Task GetEventsAsync()
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
    }
}
