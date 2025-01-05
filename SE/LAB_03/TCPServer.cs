using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using lab3_15.service;

namespace lab3_15;

public class TCPServer
{
    private readonly FlightService _flightService;

    private readonly ILogger _logger;

    public TCPServer(
        FlightService flightService,
        ILogger<TCPServer> logger)
    {
        _flightService = flightService;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 5000);
        listener.Start();
        _logger.LogInformation("TCP Server started on port 5000.");

        while (!cancellationToken.IsCancellationRequested)
        {
            var client = await listener.AcceptTcpClientAsync();
            _ = HandleClientAsync(client);
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        _logger.LogInformation("Client connected.");
        using (var stream = client.GetStream())
        {
            var buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine(request);

            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(request);
            var command = data["command"];

            try
            {
                if (command == "create_flight")
                {
                    var departure = data["departure"];
                    var arrival = data["arrival"];
                    var date = DateTime.ParseExact(data["date"], "yyyy-MM-dd", CultureInfo.InvariantCulture); // Формат дати без часу
                    var flightTime = int.Parse(data["flight_time"]);
                    
                    var (success, message) = await _flightService.CreateFlight(departure, arrival, date, flightTime);
                    var response = new
                    {
                        success = success,
                        message = message
                    };

                    var jsonResponse = JsonSerializer.Serialize(response);
                    await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonResponse));
                }
                else if (command == "update_flight")
                {
                    var departure = data["departure"];
                    var arrival = data["arrival"];
                    var date = DateTime.ParseExact(data["date"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    var flightTime = int.Parse(data["flight_time"]);

                    var (success, message) = await _flightService.UpdateFlight(departure, arrival, date, flightTime);
                    var response = new
                    {
                        success = success,
                        message = message
                    };

                    var jsonResponse = JsonSerializer.Serialize(response);
                    await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonResponse));
                }
                else if (command == "get_all_flights")
                {
                    var flights = await _flightService.GetAllFlightsAsync();
                    var response = new
                    {
                        success = true,
                        message = "Flights",
                        flights = flights
                    };

                    var jsonResponse = JsonSerializer.Serialize(response);
                    await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonResponse));
                }
                else if (command == "book_seat")
                {
                    var flightId = int.Parse(data["flight_id"]);
                    var seatNumber = int.Parse(data["seat_number"]);
    
                    var (success, message) = await _flightService.BookSeat(flightId, seatNumber);
                    var response = new
                    {
                        success = success,
                        message = message
                    };

                    var jsonResponse = JsonSerializer.Serialize(response);
                    await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonResponse));
                }
                else if (command == "get_available_seats")
                {
                    var flightId = int.Parse(data["flight_id"]);
                    var availableSeats = await _flightService.GetAvailableSeats(flightId);
                    var response = new
                    {
                        success = true,
                        message = "Available seats retrieved successfully",
                        seats = availableSeats  // Using SeatDto which can be safely serialized
                    };

                    var jsonResponse = JsonSerializer.Serialize(response);
                    await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonResponse));
                }
                else if (command == "find_routes")
                {
                    var departure = data["departure"];
                    var arrival = data["arrival"];
    
                    var routes = await _flightService.FindRoutes(departure, arrival);
                    var formattedRoutes = routes.Select(route => 
                    {
                        var pathDescription = string.Join(" -> ", route.Select(f => f.Departure));
                        if (route.Any())
                        {
                            pathDescription += " -> " + route.Last().Arrival;
                        }
                        return pathDescription;
                    }).ToList();

                    var response = new
                    {
                        success = true,
                        message = "Routes found successfully",
                        routes = formattedRoutes
                    };

                    var jsonResponse = JsonSerializer.Serialize(response);
                    await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonResponse));
                }
                else
                {
                    var response = new
                    {
                        success = false,
                        message = "Invalid command"
                    };

                    var jsonResponse = JsonSerializer.Serialize(response);
                    await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonResponse));
                }
            }
            catch (Exception ex)
            {
                var response = new
                {
                    success = false,
                    message = $"Error: {ex.Message}"
                };

                var jsonResponse = JsonSerializer.Serialize(response);
                await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonResponse));
            }
        }

        client.Close();
    }
}
