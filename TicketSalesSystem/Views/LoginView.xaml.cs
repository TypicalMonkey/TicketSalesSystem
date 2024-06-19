using System.Windows;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;
using TicketSalesSystem.Services;

namespace TicketSalesSystem.Views
{
    public partial class LoginView : Window
    {
        private UserService _userService;

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
                        AdministratorView adminView = new AdministratorView();
                        adminView.Show();
                        break;
                    case UserRole.User:
                        UserView userView = new UserView(user);
                        userView.Show();
                        break;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid login or password.");
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterView registerView = new RegisterView();
            registerView.ShowDialog();
        }
    }
}
