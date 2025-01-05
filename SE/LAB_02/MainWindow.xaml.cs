using System.Windows;
using lab2_15.Entity;
using lab2_15.Pages;

namespace lab2_15;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Flight _flight;

    public MainWindow()
    {
        InitializeComponent();
        _flight = new Flight(); // Створюємо новий об'єкт Flight для передачі даних між вікнами
    }

    private void SearchFlightsButton_Click(object sender, RoutedEventArgs e)
    {
        SearchFlights searchFlights = new SearchFlights();
        searchFlights.Show();
    }

    private void AddFlightButton_Click(object sender, RoutedEventArgs e)
    {
        AddFlight addFlight = new AddFlight();
        addFlight.ShowDialog(); // Після закриття вікна можна перевірити введені дані
        _flight = addFlight.NewFlight; // Зберігаємо введені дані
    }

    private void OpenFlightDetails_Click(object sender, RoutedEventArgs e)
    {
        FlightDetails flightDetailsWindow = new FlightDetails(_flight); // Передаємо об'єкт Flight у нове вікно
        flightDetailsWindow.Show();
    }

    private void OpenUpdateFlight_Click(object sender, RoutedEventArgs e)
    {
        UpdateFlight updateFlightWindow = new UpdateFlight();
        updateFlightWindow.Show();
    }

    private void OpenSearchConnectingFlights_Click(object sender, RoutedEventArgs e)
    {
        SearchConnectingFlights searchFlightsWindow = new SearchConnectingFlights();
        searchFlightsWindow.Show();
    }
}