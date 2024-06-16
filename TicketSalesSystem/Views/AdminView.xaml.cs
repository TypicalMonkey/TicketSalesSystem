using System.Windows;
using TicketSalesSystem.Data;
using TicketSalesSystem.Services;

namespace TicketSalesSystem.Views
{
    public partial class AdminView : Window
    {
        private readonly AdminService _adminService;

        public AdminView()
        {
            InitializeComponent();
            _adminService = new AdminService(new ApplicationDbContext());
            LoadUsers();
        }

        private void LoadUsers()
        {
            dgUsers.ItemsSource = _adminService.GetAllUsers();
        }
    }
}
