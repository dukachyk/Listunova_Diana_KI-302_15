using System.Windows;
using lab2_15.Entity;

namespace lab2_15.Pages;

public partial class SearchConnectingFlights : Window
{
    public SearchConnectingFlightstViewModel ViewModel { get; set; }

    public SearchConnectingFlights()
    {
        InitializeComponent();
        ViewModel = new SearchConnectingFlightstViewModel();
        DataContext = ViewModel;
    }
}