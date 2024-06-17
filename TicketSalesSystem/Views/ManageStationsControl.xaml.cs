using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Views
{
    public partial class ManageStationsControl : UserControl
    {
        public ManageStationsControl()
        {
            InitializeComponent();
            LoadStations();
        }

        private void LoadStations()
        {
            using (var context = new ApplicationDbContext())
            {
                dgStations.ItemsSource = context.Stations.ToList();
            }
        }

        private void SaveStation_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var station = button.DataContext as Station;
                if (station != null)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        if (station.Id == 0)
                        {
                            context.Stations.Add(station);
                        }
                        else
                        {
                            var existingStation = context.Stations.Find(station.Id);
                            if (existingStation != null)
                            {
                                existingStation.Name = station.Name;
                            }
                            else
                            {
                                MessageBox.Show($"Station with ID {station.Id} not found in database.");
                            }
                        }

                        context.SaveChanges();
                        MessageBox.Show("Station saved successfully!");
                        LoadStations();
                    }
                }
            }
        }

        private void AddStation_Click(object sender, RoutedEventArgs e)
        {
            var newStation = new Station();
            using (var context = new ApplicationDbContext())
            {
                context.Stations.Add(newStation);
                context.SaveChanges();
            }

            LoadStations();
        }

        private void DeleteStation_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Tag is int stationId)
            {
                using (var context = new ApplicationDbContext())
                {
                    var stationToDelete = context.Stations.Find(stationId);
                    if (stationToDelete != null)
                    {
                        context.Stations.Remove(stationToDelete);
                        context.SaveChanges();
                        MessageBox.Show("Station deleted successfully!");
                        LoadStations();
                    }
                    else
                    {
                        MessageBox.Show($"Station with ID {stationId} not found in database.");
                    }
                }
            }
        }
    }
}
