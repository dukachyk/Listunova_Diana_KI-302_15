using System.ComponentModel;

namespace lab2_15.Entity;

public class Flight : INotifyPropertyChanged
{
    // Позначено як nullable, оскільки значення може бути null
    public string? _departure { get; set; }
    public string? _arrival { get; set; }
    public string? _flightTime { get; set; }
    public string? _date { get; set; }
    public string? _name { get; set; }

    public Flight(string? departure, string? arrival, string? flightTime, string? date)
    {
        _departure = departure;
        _arrival = arrival;
        _flightTime = flightTime;
        _date = date;
        _name = departure + " -- " + arrival;
    }

    public Flight()
    {
        _name = _departure + " -- " + _arrival;
    }

    public string? Departure
    {
        get { return _departure; }
        set
        {
            _departure = value;
            OnPropertyChanged(nameof(Departure));
        }
    }

    public string? Arrival
    {
        get { return _arrival; }
        set
        {
            _arrival = value;
            OnPropertyChanged(nameof(Arrival));
        }
    }

    public string? Date
    {
        get { return _date; }
        set
        {
            _date = value;
            OnPropertyChanged(nameof(Date));
        }
    }

    public string? FlightTime
    {
        get { return _flightTime; }
        set
        {
            _flightTime = value;
            OnPropertyChanged(nameof(FlightTime));
        }
    }

    // Позначено як nullable, оскільки подія може бути null
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}