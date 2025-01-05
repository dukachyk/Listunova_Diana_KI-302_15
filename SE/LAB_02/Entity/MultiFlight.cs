using System.Collections.ObjectModel;
using System.ComponentModel;

namespace lab2_15.Entity;

public class MultiFlight : INotifyPropertyChanged
{
    // Список міст для пересадок
    public ObservableCollection<string>? _stops { get; set; }
    public string? _flightTime { get; set; }
    public string? _date { get; set; }
    public string? _name { get; set; }

    public MultiFlight(ObservableCollection<string> stops, string? flightTime, string? date)
    {
        _stops = stops;
        _flightTime = flightTime;
        _date = date;
        _name = string.Join(" -> ", stops);
    }

    public MultiFlight()
    {
        _name = string.Join(" -> ", _stops);
    }

    public ObservableCollection<string>? Stops
    {
        get { return _stops; }
        set
        {
            _stops = value;
            OnPropertyChanged(nameof(Stops));
            _name = string.Join(" -> ", _stops); // Оновлення назви при зміні пересадок
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

    public string? Name
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    // Подія для інформування про зміну властивостей
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}