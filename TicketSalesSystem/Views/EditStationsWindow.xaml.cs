using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Views
{
    public partial class EditStationsWindow : Window
    {
        public ObservableCollection<OrderedStation> UpdatedOrderedStations { get; private set; }
        public List<Station> AllStations { get; private set; }
        private int routeId;

        public EditStationsWindow(List<OrderedStation> orderedStations, int routeId)
        {
            InitializeComponent();
            this.routeId = routeId;
            UpdatedOrderedStations = new ObservableCollection<OrderedStation>(orderedStations?.OrderBy(s => s.Order).ToList() ?? new List<OrderedStation>());
            DataContext = this; // Ensure the DataContext is set
            LoadAllStations();
            LoadOrderedStations(); 
        }



        private void LoadAllStations()
        {
            using (var context = new ApplicationDbContext())
            {
                var allStations = context.Stations.ToList();
                foreach (var station in allStations)
                {
                    Debug.WriteLine($"Loaded station: {station.Id} - {station.Name}");
                }
                cbAllStations.ItemsSource = allStations;
                cbAllStations.DisplayMemberPath = "Name"; // Display station names
                cbAllStations.SelectedValuePath = "Id"; // Use station IDs as values
            }
        }

        private void LoadOrderedStations()
        {
            using (var context = new ApplicationDbContext())
            {
                var orderedStations = context.OrderedStations
                    .Where(os => os.RouteId == routeId)
                    .Include(os => os.Station) // Include the Station details
                    .OrderBy(os => os.Order)
                    .ToList();

                UpdatedOrderedStations = new ObservableCollection<OrderedStation>(orderedStations);
                lbStations.ItemsSource = UpdatedOrderedStations; // Update the ListView with ordered stations
            }
        }





        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var route = context.Routes.FirstOrDefault(r => r.Id == routeId);
                    if (route == null)
                    {
                        route = new Route
                        {
                            // Set route properties here
                        };
                        context.Routes.Add(route);
                        context.SaveChanges();
                        routeId = route.Id; // Update routeId to the newly saved route's ID
                    }

                    Debug.WriteLine($"Route found: {route.Id} - {route.Name}");

                    var existingOrderedStations = context.OrderedStations.Where(os => os.RouteId == routeId).ToList();
                    context.OrderedStations.RemoveRange(existingOrderedStations);
                    context.SaveChanges(); // Commit removal before adding new entries

                    foreach (var orderedStation in UpdatedOrderedStations)
                    {
                        var station = context.Stations.FirstOrDefault(s => s.Id == orderedStation.StationId);
                        if (station != null)
                        {
                            orderedStation.Station = station;
                        }
                        else
                        {
                            context.Stations.Attach(orderedStation.Station);
                            Debug.WriteLine($"Attaching existing station: {orderedStation.Station.Id} - {orderedStation.Station.Name}");
                        }

                        orderedStation.Id = 0; // Reset the ID for new entries to avoid conflict
                        orderedStation.RouteId = routeId;
                        Debug.WriteLine($"Adding OrderedStation: Order = {orderedStation.Order}, RouteId = {orderedStation.RouteId}, StationId = {orderedStation.StationId}");
                        context.OrderedStations.Add(orderedStation);
                    }

                    context.SaveChanges();
                }
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}");
            }
        }












        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lbStations.SelectedIndex;
            if (selectedIndex > 0)
            {
                UpdatedOrderedStations.Move(selectedIndex, selectedIndex - 1);
                UpdateStationOrder();
            }
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lbStations.SelectedIndex;
            if (selectedIndex < UpdatedOrderedStations.Count - 1)
            {
                UpdatedOrderedStations.Move(selectedIndex, selectedIndex + 1);
                UpdateStationOrder();
            }
        }

        private void AddStation_Click(object sender, RoutedEventArgs e)
        {
            var selectedStation = cbAllStations.SelectedItem as Station;
            if (selectedStation != null)
            {
                if (!UpdatedOrderedStations.Any(s => s.StationId == selectedStation.Id))
                {
                    var newOrderedStation = new OrderedStation
                    {
                        StationId = selectedStation.Id,
                        Station = selectedStation,
                        Order = UpdatedOrderedStations.Count,
                        RouteId = routeId
                    };
                    UpdatedOrderedStations.Add(newOrderedStation);
                    UpdateStationOrder();
                }
                else
                {
                    MessageBox.Show("Station already added.");
                }
            }
            else
            {
                MessageBox.Show("No station selected.");
            }
        }




        private void UpdateStationOrder()
        {
            for (int i = 0; i < UpdatedOrderedStations.Count; i++)
            {
                UpdatedOrderedStations[i].Order = i;
            }

            lbStations.ItemsSource = null; // Refresh the ListBox to reflect changes
            lbStations.ItemsSource = UpdatedOrderedStations;
        }

    }
}
