using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using lab2_15.Entity;
using lab2_15.Requests;

namespace lab2_15.Pages
{
    public partial class FlightDetails : Window
    {
        // Колекція квитків, яка буде використовуватись для прив'язки
        public ObservableCollection<Ticket> Tickets { get; set; }
        public Flight Flight { get; set; }

        public FlightDetails(Flight flight)
        {
            InitializeComponent();

            // Призначення об'єкта Flight як DataContext для прив'язки

            DataContext = flight;
            Flight = flight;

            // Ініціалізація колекції квитків
            Tickets = new ObservableCollection<Ticket>();

            // Прив'язка колекції квитків до ListBox
            TicketsInfoList.ItemsSource = Tickets;
        }

        // Функція для отримання квитків
        private void GetTickets()
        {
            var req = new GetTickets().GetTicketsRequest();

            foreach (var VARIABLE in req)
            {
                Tickets.Add(VARIABLE);
            }
        }

        private void GetTicketInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Викликаємо функцію для отримання квитків
                GetTickets();

                StatusMessage.Text = "Інформація про квитки успішно отримана.";
            }
            catch (System.Exception ex)
            {
                StatusMessage.Text = "Виникла помилка: " + ex.Message;
            }
        }

        private void BookTicket_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Отримуємо квиток, прив'язаний до кнопки
                Ticket ticket = button.DataContext as Ticket;
                if (ticket != null)
                {
                    // Тут ви можете використовувати ticket для бронювання
                    string ticketPrice = ticket.Price;
                    var req = new BookRequest().Book(Flight, ticket);
                    if (req)
                    {
                        StatusMessage.Text = $"Квиток за {ticketPrice} успішно заброньовано.";
                    }
                }
            }
        }


        // Клас квитка
        public class Ticket
        {
            public string Price { get; set; }
        }
    }
}