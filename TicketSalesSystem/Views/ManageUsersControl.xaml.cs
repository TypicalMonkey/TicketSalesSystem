using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Views
{
    public partial class ManageUsersControl : UserControl
    {
        public ManageUsersControl()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                dgUsers.ItemsSource = context.Users.ToList();
            }
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var user = button.DataContext as User;
                if (user != null)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        if (user.Id == 0)
                        {
                            // New user, add it to database
                            context.Users.Add(user);
                        }
                        else
                        {
                            var existingUser = context.Users.Find(user.Id);
                            if (existingUser != null)
                            {
                                // Update existing user
                                existingUser.Username = user.Username;
                                existingUser.Password = user.Password;
                                existingUser.Email = user.Email;
                                existingUser.UserRole = user.UserRole;
                            }
                            else
                            {
                                MessageBox.Show($"User with ID {user.Id} not found in database.");
                            }
                        }

                        context.SaveChanges();
                        MessageBox.Show("User saved successfully!");

                        // Refresh the DataGrid after saving changes
                        LoadUsers();
                    }
                }
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User();
            // Optionally initialize default values for new user here
            using (var context = new ApplicationDbContext())
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }

            LoadUsers();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Tag is int userId)
            {
                using (var context = new ApplicationDbContext())
                {
                    var userToDelete = context.Users.Find(userId);
                    if (userToDelete != null)
                    {
                        context.Users.Remove(userToDelete);
                        context.SaveChanges();
                        MessageBox.Show("User deleted successfully!");
                        LoadUsers(); // Refresh the DataGrid
                    }
                    else
                    {
                        MessageBox.Show($"User with ID {userId} not found in database.");
                    }
                }
            }
        }

        private void dgUsers_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Handle cell edit ending if needed
            // Example provided in previous messages
        }
    }
}
