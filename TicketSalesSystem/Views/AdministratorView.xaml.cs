using System.Windows;

namespace TicketSalesSystem.Views
{
    public partial class AdministratorView : Window
    {
        public AdministratorView()
        {
                    InitializeComponent();
        }

        private void BtnManageTrains_Click(object sender, RoutedEventArgs e)
        {
            manageTrainsControl.Visibility = Visibility.Visible;
            manageRoutesControl.Visibility = Visibility.Collapsed;
            manageUsersControl.Visibility = Visibility.Collapsed;
            manageStationsControl.Visibility = Visibility.Collapsed;
        }

        private void BtnManageRoutes_Click(object sender, RoutedEventArgs e)
        {
            manageTrainsControl.Visibility = Visibility.Collapsed;
            manageRoutesControl.Visibility = Visibility.Visible;
            manageUsersControl.Visibility = Visibility.Collapsed;
            manageStationsControl.Visibility = Visibility.Collapsed;
        }

        private void BtnManageUsers_Click(object sender, RoutedEventArgs e)
        {
            manageTrainsControl.Visibility = Visibility.Collapsed;
            manageRoutesControl.Visibility = Visibility.Collapsed;
            manageUsersControl.Visibility = Visibility.Visible;
            manageStationsControl.Visibility = Visibility.Collapsed;
        }

        private void BtnManageStations_Click(object sender, RoutedEventArgs e)
        {
            manageTrainsControl.Visibility = Visibility.Collapsed;
            manageRoutesControl.Visibility = Visibility.Collapsed;
            manageUsersControl.Visibility = Visibility.Collapsed;
            manageStationsControl.Visibility = Visibility.Visible;
        }


        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
