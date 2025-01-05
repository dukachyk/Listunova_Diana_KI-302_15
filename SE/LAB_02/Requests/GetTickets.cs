using System.Collections.ObjectModel;
using lab2_15.Pages;

namespace lab2_15.Requests;

public class GetTickets
{
    public ObservableCollection<FlightDetails.Ticket> GetTicketsRequest()
    {
        var Tickets = new ObservableCollection<FlightDetails.Ticket>();

        Tickets.Add(new FlightDetails.Ticket { Price = "1200 грн" });
        Tickets.Add(new FlightDetails.Ticket { Price = "1500 грн" });
        Tickets.Add(new FlightDetails.Ticket { Price = "1700 грн" });
        Tickets.Add(new FlightDetails.Ticket { Price = "1700 грн" });
        Tickets.Add(new FlightDetails.Ticket { Price = "1900 грн" });
        Tickets.Add(new FlightDetails.Ticket { Price = "2200 грн" });
        Tickets.Add(new FlightDetails.Ticket { Price = "2500 грн" });
        return Tickets;
    }
}