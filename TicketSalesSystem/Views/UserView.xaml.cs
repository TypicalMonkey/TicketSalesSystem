using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Views
{
    public partial class UserView : Window
    {
        private readonly ApplicationDbContext _context;
        private readonly User _currentUser;

        public UserView(User currentUser)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _currentUser = currentUser;
        }

        private void BtnPurchaseTicket_Click(object sender, RoutedEventArgs e)
        {
            var ticketSaleView = new TicketSaleView(_currentUser);
            ticketSaleView.Show();
            this.Close();
        }

        private void BtnShowTickets_Click(object sender, RoutedEventArgs e)
        {
            var ticketsView = new TicketsView(_currentUser);
            ticketsView.Show();
            this.Close();
            //TicketsView.Visibility = Visibility.Visible;
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

        private void LoadUserTickets()
        {
            var userTickets = _context.Tickets
                .Where(t => t.UserId == _currentUser.Id)
                .ToList();

            foreach (var ticket in userTickets)
            {
                Console.WriteLine($"ID: {ticket.Id}, Trasa: {ticket.Route.Name}, Cena: {ticket.Price}");
            }
        }
    }
}
