using System.ComponentModel;
using System.Windows;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;
using TicketSalesSystem.Services;

namespace TicketSalesSystem.Views
{
    public partial class RegisterView : Window, INotifyPropertyChanged
    {
        private readonly UserService _userService;
        private User _user;

        public RegisterView()
        {
            InitializeComponent();
            _userService = new UserService(new ApplicationDbContext());
            User = new User();
            DataContext = this;
        }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(User.Username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(User.Email))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            User.Password = password;

            bool success = _userService.Register(User);

            if (success)
            {
                MessageBox.Show("User registered successfully.");
                User user = _userService.Login(User.Username, password);

                if (user != null)
                {
                    UserView userView = new UserView(user);
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
