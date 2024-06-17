using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Views
{
    public partial class ManageTrainsControl : UserControl
    {
        public List<Train> Trains { get; private set; }
        public ManageTrainsControl()
        {
            InitializeComponent();
            LoadTrains();
        }

        public void LoadTrains()
        {
            using (var context = new ApplicationDbContext())
            {
                Trains = context.Trains.ToList();
                dgTrains.ItemsSource = Trains;
            }
        }

        private void SaveTrain_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var train = button.DataContext as Train;
                if (train != null)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        if (train.Id == 0)
                        {
                            // New train, add it to database
                            context.Trains.Add(train);
                        }
                        else
                        {
                            var existingTrain = context.Trains.Find(train.Id);
                            if (existingTrain != null)
                            {
                                // Update existing train
                                existingTrain.Brand = train.Brand;
                                existingTrain.Model = train.Model;
                                existingTrain.Seats = train.Seats;
                                existingTrain.Year = train.Year;
                                existingTrain.HasWifi = train.HasWifi;
                                existingTrain.AdditionalInfo = train.AdditionalInfo;
                            }
                            else
                            {
                                MessageBox.Show($"Train with ID {train.Id} not found in database.");
                            }
                        }

                        context.SaveChanges();
                        MessageBox.Show("Train saved successfully!");

                        // Refresh the DataGrid after saving changes
                        LoadTrains();
                    }
                }
            }
        }

        private void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            var newTrain = new Train();
            // Optionally initialize default values for new train here
            using (var context = new ApplicationDbContext())
            {
                context.Trains.Add(newTrain);
                context.SaveChanges();
            }

            LoadTrains();
        }

        private void DeleteTrain_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Tag is int trainId)
            {
                using (var context = new ApplicationDbContext())
                {
                    var trainToDelete = context.Trains.Find(trainId);
                    if (trainToDelete != null)
                    {
                        context.Trains.Remove(trainToDelete);
                        context.SaveChanges();
                        MessageBox.Show("Train deleted successfully!");
                        LoadTrains(); // Refresh the DataGrid
                    }
                    else
                    {
                        MessageBox.Show($"Train with ID {trainId} not found in database.");
                    }
                }
            }
        }

        private void dgTrains_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Handle cell edit ending if needed
            // Example provided in previous messages
        }
    }
}
