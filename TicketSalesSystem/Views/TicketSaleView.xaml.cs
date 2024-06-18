using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Views
{
    public partial class TicketSaleView : Window
    {
        private readonly ApplicationDbContext _context;
        private readonly User _currentUser;
        private Route _selectedRoute;
        private Station _startStation;
        private Station _endStation;

        public TicketSaleView(User currentUser)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _currentUser = currentUser;
            LoadRoutes();
        }

        private void LoadRoutes()
        {
            cbRoutes.ItemsSource = _context.Routes.ToList();
            cbRoutes.SelectedIndex = 0;
        }

        private void CbRoutes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbRoutes.SelectedItem is Route selectedRoute)
            {
                _selectedRoute = selectedRoute;
                cbStartStation.ItemsSource = selectedRoute.OrderedStations.Select(os => os.Station).ToList();
                cbEndStation.ItemsSource = selectedRoute.OrderedStations.Select(os => os.Station).ToList();
            }
        }

        private void LoadStations(int routeId)
        {
            using (var context = new ApplicationDbContext())
            {
                var stations = context.OrderedStations
                    .Where(os => os.RouteId == routeId)
                    .OrderBy(os => os.Order)
                    .Select(os => os.Station)
                    .ToList();

                cbStartStation.ItemsSource = stations;
                cbStartStation.SelectedIndex = 0;

                cbEndStation.ItemsSource = stations;
                cbEndStation.SelectedIndex = stations.Count - 1;
            }
        }

        private void CbStartStation_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbStartStation.SelectedItem is Station startStation)
            {
                _startStation = startStation;
                UpdateTotalPrice();
            }
        }

        private void CbEndStation_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbEndStation.SelectedItem is Station endStation)
            {
                _endStation = endStation;
                UpdateTotalPrice();
            }
        }

        private void UpdateTotalPrice()
        {
            if (_startStation != null && _endStation != null && _startStation != _endStation)
            {
                var price = CalculatePrice(_startStation, _endStation);
                txtTotalPrice.Text = $"${price}";
            }
            else
            {
                txtTotalPrice.Text = string.Empty;
            }
        }

        private decimal CalculatePrice(Station startStation, Station endStation)
        {
            return 10 * Math.Abs(startStation.Id - endStation.Id);
        }

        private void BtnPurchaseTicket_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedRoute != null && _startStation != null && _endStation != null)
            {
                if (_startStation.Id == _endStation.Id)
                {
                    MessageBox.Show("Start and End stations cannot be the same.");
                    return;
                }

                var newTicket = new Ticket
                {
                    PurchaseDate = DateTime.Now,
                    Price = CalculatePrice(_startStation, _endStation),
                    RouteId = _selectedRoute.Id,
                    StartStationId = _startStation.Id,
                    EndStationId = _endStation.Id,
                    UserId = _currentUser.Id
                };

                _context.Tickets.Add(newTicket);
                _context.SaveChanges();

                MessageBox.Show("Bilet został zakupiony pomyślnie.");

                cbRoutes.SelectedIndex = -1;
                cbStartStation.ItemsSource = null;
                cbEndStation.ItemsSource = null;
                txtTotalPrice.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Proszę wybrać wszystkie pola.");
            }
        }

    }
}
