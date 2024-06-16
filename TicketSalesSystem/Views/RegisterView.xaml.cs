using System;
using System.Windows;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;
using TicketSalesSystem.Services;

namespace TicketSalesSystem.Views
{
    public partial class RegisterView : Window
    {
        private readonly UserService _userService;

        public RegisterView()
        {
            InitializeComponent();
            _userService = new UserService(new ApplicationDbContext());
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;
            string email = txtEmail.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            User newUser = new User
            {
                Username = login,
                Password = password,
                Email = email,
                UserRole = UserRole.User
            };

            bool success = _userService.Register(newUser);

            if (success)
            {
                MessageBox.Show("User registered successfully.");
                User user = _userService.Login(login, password);

                if (user != null)
                {
                    UserView userView = new UserView();
                    userView.Show();
                    this.Close();

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window is LoginView)
                        {
                            window.Close();
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Login failed after registration.");
                }
            }
            else
            {
                MessageBox.Show("Registration failed.");
            }
        }
    }
}
