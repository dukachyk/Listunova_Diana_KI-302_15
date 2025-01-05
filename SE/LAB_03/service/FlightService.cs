using lab3_15.DTO;
using lab3_15.model;
using Microsoft.EntityFrameworkCore;

namespace lab3_15.service;

public class FlightService
{
    private readonly AppDbContext _context;

    public FlightService(AppDbContext context)
    {
        _context = context;
    }

    // Method to create a new flight
    public async Task<(bool success, string message)> CreateFlight(
        string departure,
        string arrival,
        DateTime date,
        int flightTime)
    {
        // Перевірка на заповненість і мінімальну довжину даних
        if (string.IsNullOrWhiteSpace(departure))
            return (false, "Departure location is required.");
        if (departure.Length < 3)
            return (false, "Departure location must be at least 3 characters long.");

        if (string.IsNullOrWhiteSpace(arrival))
            return (false, "Arrival location is required.");
        if (arrival.Length < 3)
            return (false, "Arrival location must be at least 3 characters long.");

        if (departure.Equals(arrival, StringComparison.OrdinalIgnoreCase))
            return (false, "Departure and arrival locations cannot be the same.");

        // Перевірка на дату рейсу
        if (date <= DateTime.UtcNow)
            return (false, "Flight date must be in the future.");
        if (date.Date > DateTime.UtcNow.AddYears(1).Date)
            return (false, "Flight date cannot be more than a year from now.");

        // Перевірка на тривалість рейсу
        if (flightTime <= 0)
            return (false, "Flight time must be a positive integer.");
        if (flightTime > 1440)
            return (false, "Flight time cannot exceed 1440 minutes (24 hours).");

        // Перевірка, чи вже існує такий рейс
        bool flightExists = await _context.Flights.AnyAsync(f =>
            f.Departure == departure &&
            f.Arrival == arrival);

        if (flightExists)
            return (false,
                "A flight with the same departure and arrival locations already exists.");

        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var flight = new Flight
            {
                Departure = departure,
                Arrival = arrival,
                Date = date,
                FlightTime = flightTime
            };

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            // Створення 10 місць для рейсу
            for (int i = 1; i <= 10; i++)
            {
                var seat = new Seat
                {
                    FlightId = flight.Id,
                    SeatNumber = i,
                    Price = i * 100, // Розрахунок ціни на основі номера місця
                    IsOccupied = false
                };
                _context.Seats.Add(seat);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return (true, "Flight and seats created successfully.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return (false, $"Error: {ex.Message}");
        }
    }

    public async Task<(bool success, string message)> UpdateFlight(string departure, string arrival, DateTime date,
        int flightTime)
    {
        // Перевірки введених даних
        if (string.IsNullOrWhiteSpace(departure))
            return (false, "Departure location is required.");
        if (string.IsNullOrWhiteSpace(arrival))
            return (false, "Arrival location is required.");
        if (departure.Equals(arrival, StringComparison.OrdinalIgnoreCase))
            return (false, "Departure and arrival locations cannot be the same.");
        if (date <= DateTime.UtcNow)
            return (false, "Flight date must be in the future.");
        if (flightTime <= 0)
            return (false, "Flight time must be a positive integer.");

        try
        {
            // Пошук рейсу
            var flight = await _context.Flights.FirstOrDefaultAsync(f =>
                f.Departure == departure &&
                f.Arrival == arrival);

            if (flight == null)
                return (false, "Flight not found.");

            // Оновлення інформації
            flight.Date = date;
            flight.FlightTime = flightTime;

            await _context.SaveChangesAsync();

            return (true, "Flight updated successfully.");
        }
        catch (Exception ex)
        {
            // Обробка можливих винятків
            return (false, $"Error: {ex.Message}");
        }
    }


    public async Task<(bool success, string message)> BookSeat(int flightId, int seatNumber)
    {
        // Перевірка вхідних параметрів
        if (flightId <= 0)
            return (false, "Invalid flight ID.");
        if (seatNumber <= 0)
            return (false, "Invalid seat number.");

        try
        {
            // Пошук місця
            var seat = await _context.Seats
                .FirstOrDefaultAsync(s => s.FlightId == flightId && s.SeatNumber == seatNumber);

            if (seat == null)
            {
                return (false, "Seat not found.");
            }

            if (seat.IsOccupied)
            {
                return (false, $"Seat {seatNumber} is already occupied.");
            }

            // Захист від конкурентних змін
            seat.IsOccupied = true;

            _context.Seats.Update(seat); // Явно позначаємо зміни
            await _context.SaveChangesAsync();

            return (true, $"Seat {seatNumber} booked successfully.");
        }
        catch (DbUpdateConcurrencyException)
        {
            return (false, "The seat was already booked by another user. Please try again.");
        }
        catch (Exception ex)
        {
            return (false, $"Error booking seat: {ex.Message}");
        }
    }


    public async Task<List<SeatDto>> GetAvailableSeats(int flightId)
    {
        return await _context.Seats
            .Where(s => s.FlightId == flightId && !s.IsOccupied)
            .Select(s => new SeatDto
            {
                Id = s.Id,
                FlightId = s.FlightId,
                SeatNumber = s.SeatNumber,
                Price = s.Price,
                IsOccupied = s.IsOccupied
            })
            .OrderBy(s => s.SeatNumber)
            .ToListAsync();
    }

    public async Task<List<List<Flight>>> FindRoutes(string departure, string arrival)
    {
        // Перевірка на порожнє або некоректне значення departure
        if (string.IsNullOrWhiteSpace(departure))
            throw new ArgumentException("Початкове місто не може бути порожнім або містити лише пробіли.");

        // Перевірка на порожнє або некоректне значення arrival
        if (string.IsNullOrWhiteSpace(arrival))
            throw new ArgumentException("Місто призначення не може бути порожнім або містити лише пробіли.");

        // Перевірка, чи відрізняються departure і arrival
        if (departure == arrival)
            throw new ArgumentException("Початкове місто не може збігатися з містом призначення.");

        // Завантажуємо всі рейси з бази даних
        var allFlights = await _context.Flights.ToListAsync();

        // Перевірка, чи є в базі даних хоч один рейс
        if (allFlights == null || !allFlights.Any())
            throw new InvalidOperationException("У базі даних відсутні рейси для пошуку маршрутів.");

        // Перевірка, чи існують рейси з початкового міста
        if (!allFlights.Any(f => f.Departure == departure))
            throw new InvalidOperationException($"Не знайдено рейсів із міста {departure}.");

        // Перевірка, чи існують рейси до міста призначення
        if (!allFlights.Any(f => f.Arrival == arrival))
            throw new InvalidOperationException($"Не знайдено рейсів до міста {arrival}.");

        var routes = new List<List<Flight>>();
        var visited = new HashSet<string>();
        var currentPath = new List<Flight>();

        void FindRoutesRecursive(string currentCity)
        {
            // Якщо досягнуто пункту призначення
            if (currentCity == arrival)
            {
                routes.Add(new List<Flight>(currentPath));
                return;
            }

            // Знаходимо всі можливі рейси з поточного міста
            var possibleFlights = allFlights.Where(f => f.Departure == currentCity).ToList();

            foreach (var flight in possibleFlights)
            {
                // Перевіряємо, чи не створюємо цикл
                if (visited.Contains(flight.Arrival))
                    continue;

                // Додаємо місто до відвіданих
                visited.Add(flight.Arrival);
                currentPath.Add(flight);

                // Рекурсивно шукаємо шлях з нового міста
                FindRoutesRecursive(flight.Arrival);

                // Прибираємо місто з відвіданих для інших можливих шляхів
                visited.Remove(flight.Arrival);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }

        // Додаємо початкове місто до відвіданих
        visited.Add(departure);
        FindRoutesRecursive(departure);

        return routes;
    }

    public async Task<List<FlightDto>> GetAllFlightsAsync()
    {
        try
        {
            var flights = await _context.Flights
                .Include(f => f.Seats)
                .Select(f => new FlightDto
                {
                    Id = f.Id,
                    Departure = f.Departure,
                    Arrival = f.Arrival,
                    Date = f.Date,
                    FlightTime = f.FlightTime
                })
                .ToListAsync();
            return flights;
        }
        catch (Exception ex)
        {
            return new List<FlightDto>();
        }
    }
}