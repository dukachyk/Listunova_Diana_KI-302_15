using System.Collections.ObjectModel;
using lab2_15.Entity;

namespace lab2_15.Requests
{
    public class SearchService
    {
        public ObservableCollection<Flight> FetchService(string departure, string arrival, string date,
            string flightTime)
        {
            // Імітація запиту до сервера
            var result = new ObservableCollection<Flight>
            {
                new Flight("Київ", "Лондон", "2024-10-20", "10:30"),
                new Flight("Львів", "Берлін", "2024-10-21", "14:45"),
                new Flight("Одеса", "Париж", "2024-10-22", "16:00"),
                new Flight("Харків", "Рим", "2024-10-23", "18:15"),
                new Flight("Дніпро", "Мадрид", "2024-10-24", "12:20"),
                new Flight("Київ", "Варшава", "2024-10-25", "09:00"),
                new Flight("Львів", "Прага", "2024-10-26", "11:45"),
                new Flight("Одеса", "Стамбул", "2024-10-27", "17:30"),
                new Flight("Харків", "Амстердам", "2024-10-28", "13:00"),
                new Flight("Дніпро", "Лісабон", "2024-10-29", "08:30")
            };

            return result;
        }
    }
}