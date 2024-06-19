using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Views
{
    public partial class TicketsView : Window
    {
        private readonly ApplicationDbContext _context;
        private readonly User _currentUser;

        public TicketsView(User currentUser)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _currentUser = currentUser;
            LoadTickets();
        }

        private void LoadTickets()
        {
            var tickets = _context.Tickets
                .Where(t => t.UserId == _currentUser.Id)
                .Select(t => new
                {
                    t.Id,
                    t.PurchaseDate,
                    t.Price,
                    Route = t.Route.Name,
                    StartStation = t.StartStation.Name,
                    EndStation = t.EndStation.Name
                })
                .ToList();

            dataGridTickets.ItemsSource = tickets;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            UserView userView = new UserView(_currentUser);
            userView.Show();
            Close();
        }
    }
}
