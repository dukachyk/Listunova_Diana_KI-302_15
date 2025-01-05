using System.Windows;
using System.Windows.Input;
using lab2_15.Entity;

namespace lab2_15.Pages
{
    public partial class SearchFlights : Window
    {
        public FlightSearchViewModel ViewModel { get; set; }

        public SearchFlights()
        {
            InitializeComponent();
            ViewModel = new FlightSearchViewModel();
            DataContext = ViewModel;
        }
    }
}