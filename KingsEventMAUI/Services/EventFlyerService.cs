using KingsEventMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.Services
{
    public class EventFlyerService
    {
        HttpClient httpClient;
        List<EventFlyer> eventFlyers = new();
        string eventFlyersUrl = "TBD";

        public EventFlyerService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<EventFlyer>> GetEventFlyersAsync()
        {
            if (eventFlyers.Count > 0)
                return eventFlyers;

            var response = await httpClient.GetAsync(eventFlyersUrl);

            if (response.IsSuccessStatusCode)
            {
                eventFlyers = await response.Content.ReadFromJsonAsync<List<EventFlyer>>();
            }

            return eventFlyers;
        }
    }
}
