namespace lab3_15.model;

public class Seat
{
    public int Id { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public bool IsOccupied { get; set; }
}