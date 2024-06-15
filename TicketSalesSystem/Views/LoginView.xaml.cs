using System.Windows;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;
using TicketSalesSystem.Services;

namespace TicketSalesSystem.Views
{
    public partial class LoginView : Window
    {
        private readonly UserService _userService;

        public LoginView()
        {
            InitializeComponent();
            _userService = new UserService(new ApplicationDbContext());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            User user = _userService.Login(login, password);

            if (user != null)
            {

                switch (user.UserRole)
                {
                    case UserRole.Admin:
                        break;
                    case UserRole.Cashier:
                        break;
                    case UserRole.User:
                        break;
                    default:
                        MessageBox.Show("Nieprawidłowa rola użytkownika.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Nieprawidłowy login lub hasło.");
            }
        }
    }
}
