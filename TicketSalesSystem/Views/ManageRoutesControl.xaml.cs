using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketSalesSystem.Views
{
    public partial class ManageRoutesControl : UserControl
    {
        public List<Route> Routes { get; private set; }
        public List<Train> Trains { get; private set; }

        public ManageRoutesControl()
        {
            InitializeComponent();
            LoadData();
            DataContext = this;
        }

        public void LoadData()
        {
            using (var context = new ApplicationDbContext())
            {
                Routes = context.Routes.Include(r => r.OrderedStations).ThenInclude(os => os.Station).ToList();
                Trains = context.Trains.ToList();
                dgRoutes.ItemsSource = Routes;
            }
        }

        private void SaveRoute_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var flag = 1;
            if (button != null)
            {
                var route = button.DataContext as Route;
                if (route != null)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        if (route.Id == 0)
                        {
                            context.Routes.Add(route);
                            flag = 0;
                        }
                        else
                        {
                            var existingRoute = context.Routes.Find(route.Id);
                            if (existingRoute != null)
                            {
                                existingRoute.Name = route.Name;
                                existingRoute.DepartureTime = route.DepartureTime;
                                existingRoute.ArrivalTime = route.ArrivalTime;
                                existingRoute.TrainId = route.TrainId;
                            }
                            else
                            {
                                MessageBox.Show($"Route with ID {route.Id} not found in database.");
                            }
                        }

                        context.SaveChanges();
                        if(flag == 1) MessageBox.Show("Route saved successfully!");
                        LoadData();
                    }
                }
            }
        }

        private void DeleteRoute_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Tag is int routeId)
            {
                using (var context = new ApplicationDbContext())
                {
                    var routeToDelete = context.Routes.Find(routeId);
                    if (routeToDelete != null)
                    {
                        context.Routes.Remove(routeToDelete);
                        context.SaveChanges();
                        MessageBox.Show("Route deleted successfully!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show($"Route with ID {routeId} not found in database.");
                    }
                }
            }
        }

        private void EditStations_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;



            if (button != null)
            {
                var route = button.DataContext as Route;
                if (route.Id == 0)
                {
                    SaveRoute_Click(sender, e);
                }
                if (route != null)
                {
                    if (route.OrderedStations == null)
                    {
                        route.OrderedStations = new List<OrderedStation>();
                    }

                    var editStationsWindow = new EditStationsWindow(route.OrderedStations, route.Id);
                    if (editStationsWindow.ShowDialog() == true)
                    {
                        route.OrderedStations = editStationsWindow.UpdatedOrderedStations.ToList();
                        MessageBox.Show("Stations updated successfully!");
                    }
                }
            }
        }

        private void dgRoutes_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Handle cell edit ending if needed
        }
    }
}
