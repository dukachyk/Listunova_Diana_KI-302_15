using System.Windows;
using lab2_15.Entity;
using lab2_15.Requests;

namespace lab2_15.Pages;

public partial class AddFlight : Window
{
    public Flight NewFlight { get; set; }

    public AddFlight()
    {
        InitializeComponent();
        NewFlight = new Flight();
        DataContext = NewFlight; // Встановлюємо контекст даних
    }

    private void AddFlight_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NewFlight.Departure) ||
            string.IsNullOrWhiteSpace(NewFlight.Arrival) ||
            string.IsNullOrWhiteSpace(NewFlight.Date) ||
            string.IsNullOrWhiteSpace(NewFlight.FlightTime))
        {
            StatusMessage.Text = "Будь ласка, заповніть всі поля.";
            return;
        }

        // Додаємо рейс (логіка збереження може бути тут)
        if (new AddFlightRequest().AddFlight(NewFlight))
        {
            StatusMessage.Text = "Рейс успішно додано!";
        }
    }
}