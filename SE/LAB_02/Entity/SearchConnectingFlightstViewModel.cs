using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using lab2_15.Pages;
using lab2_15.Requests;

namespace lab2_15.Entity
{
    public class SearchConnectingFlightstViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MultiFlight> _flightsList;
        private string _stopsInput;
        private string _date;
        private string _flightTime;
        private string _statusMessage;
        
        public ICommand ShowFlightNameCommand { get; }


        public SearchConnectingFlightstViewModel()
        {
            FlightsList = new ObservableCollection<MultiFlight>();
            SearchFlightsCommand = new RelayCommand(SearchFlights);
            ShowFlightNameCommand = new RelayCommand<MultiFlight>(ShowFlightName);
        }
        
        private void ShowFlightName(MultiFlight flight)
        {
            if (flight != null)
            {
                StatusMessage = $"Заброньовано: {flight.Name}";
            }
        }

        // Властивість для введення пересадок (міст через кому)
        public string StopsInput
        {
            get { return _stopsInput; }
            set
            {
                _stopsInput = value;
                OnPropertyChanged(nameof(StopsInput));
            }
        }

        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string FlightTime
        {
            get { return _flightTime; }
            set
            {
                _flightTime = value;
                OnPropertyChanged(nameof(FlightTime));
            }
        }

        public ObservableCollection<MultiFlight> FlightsList
        {
            get { return _flightsList; }
            set
            {
                _flightsList = value;
                OnPropertyChanged(nameof(FlightsList));
            }
        }

        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        // Команда для пошуку рейсів
        public ICommand SearchFlightsCommand { get; }

        // Метод пошуку рейсів
        private void SearchFlights()
        {
            try
            {
                // // Розділяємо введені міста на список
                // var stops = new ObservableCollection<string>(_stopsInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                //
                // // Створюємо новий рейс з пересадками
                // var newFlight = new MultiFlight(stops, FlightTime, Date);
                // FlightsList.Add(newFlight);
                //
                // StatusMessage = "Рейс успішно знайдено!";
                
                // Симуляція пошуку рейсів
                var response = new SearchConnectingService().FetchService(_stopsInput,FlightTime, Date);
                FlightsList.Clear();
                foreach (var flight in response)
                {
                    FlightsList.Add(flight);
                }
            
                StatusMessage = "Пошук завершено.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Помилка: {ex.Message}";
            }
        }

        // Реалізація INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}