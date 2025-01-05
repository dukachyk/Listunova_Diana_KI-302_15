namespace lab3_15.DTO;

public class SeatDto
{
    public int Id { get; set; }
    public int FlightId { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
    public bool IsOccupied { get; set; }
}