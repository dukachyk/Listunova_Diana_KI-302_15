using System.Collections.ObjectModel;
using lab2_15.Entity;

namespace lab2_15.Requests
{
    public class SearchConnectingService
    {
        public ObservableCollection<MultiFlight> FetchService(string stops, string flightTime, string date)
        {
            // Імітація запиту до сервера
            var multiFlight = new ObservableCollection<MultiFlight>
            {
                new MultiFlight(new ObservableCollection<string> { "Київ", "Львів", "Берлін" }, "5:30", "2024-10-21"),
                new MultiFlight(new ObservableCollection<string> { "Одеса", "Будапешт", "Париж" }, "7:15", "2024-10-22")
            };
            
            return multiFlight;
        }
    }
}