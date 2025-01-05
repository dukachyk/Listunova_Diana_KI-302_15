namespace lab3_15.model;

public class Flight
{
    public int Id { get; set; }
    public string Departure { get; set; }
    public string Arrival { get; set; }
    public DateTime Date { get; set; }
    public int FlightTime { get; set; }
    public ICollection<Seat> Seats { get; set; }
}