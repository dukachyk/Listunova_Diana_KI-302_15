using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using lab2_15.Pages;
using lab2_15.Requests;

namespace lab2_15.Entity
{
    public class FlightSearchViewModel : INotifyPropertyChanged
    {
        private string? _departure;
        private string? _arrival;
        private string? _date;
        private string? _flightTime;
        private string? _statusMessage;

        public ICommand SearchFlightsCommand { get; }
        public ICommand ShowFlightNameCommand { get; }

        public string? Departure
        {
            get => _departure;
            set
            {
                _departure = value;
                OnPropertyChanged(nameof(Departure));
            }
        }

        public string? Arrival
        {
            get => _arrival;
            set
            {
                _arrival = value;
                OnPropertyChanged(nameof(Arrival));
            }
        }

        public string? Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string? FlightTime
        {
            get => _flightTime;
            set
            {
                _flightTime = value;
                OnPropertyChanged(nameof(FlightTime));
            }
        }

        public string? StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        public ObservableCollection<Flight> FlightsList { get; set; } = new ObservableCollection<Flight>();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SearchFlights()
        {
            FlightsList.Clear();

            if (string.IsNullOrWhiteSpace(Departure) || string.IsNullOrWhiteSpace(Arrival) ||
                string.IsNullOrWhiteSpace(Date) || string.IsNullOrWhiteSpace(FlightTime))
            {
                StatusMessage = "Будь ласка, заповніть всі поля.";
                return;
            }

            // Симуляція пошуку рейсів
            var response = new SearchService().FetchService(Departure, Arrival, Date, FlightTime);

            foreach (var flight in response)
            {
                FlightsList.Add(flight);
            }
            
            StatusMessage = "Пошук завершено.";
        }

        public void ShowFlightName(object flight)
        {
            if (flight is Flight selectedFlight && selectedFlight._name != null)
            {
                var flightPage = new FlightDetails(selectedFlight);
                flightPage.Show();
            }
        }


        public FlightSearchViewModel()
        {
            SearchFlightsCommand = new RelayCommand(SearchFlights);
            ShowFlightNameCommand = new RelayCommand<object>(ShowFlightName);
        }
    }
}