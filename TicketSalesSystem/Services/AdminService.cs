using System.Linq;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;

        internal AdminService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<Route> GetAllRoutes()
        {
            return _context.Routes.ToList();
        }
        public void AddNewTrain(string brand, string model, int seats, int year, bool hasWifi, string additionalInfo)
        {
            var newTrain = new Train
            {
                Brand = brand,
                Model = model,
                Seats = seats,
                Year = year,
                HasWifi = hasWifi,
                AdditionalInfo = additionalInfo
            };

            _context.Trains.Add(newTrain);
            _context.SaveChanges();
        }

        public void EditTrain(int trainId, string brand, string model, int seats, int year, bool hasWifi, string additionalInfo)
        {
            var train = _context.Trains.Find(trainId);
            if (train != null)
            {
                train.Brand = brand;
                train.Model = model;
                train.Seats = seats;
                train.Year = year;
                train.HasWifi = hasWifi;
                train.AdditionalInfo = additionalInfo;

                _context.SaveChanges();
            }
        }

        public void DeleteTrain(int trainId)
        {
            var train = _context.Trains.Find(trainId);
            if (train != null)
            {
                _context.Trains.Remove(train);
                _context.SaveChanges();
            }
        }

        public void AddNewRoute(string departureStation, string arrivalStation, DateTime departureTime)
        {
            var newRoute = new Route
            {
                DepartureTime = departureTime
            };

            _context.Routes.Add(newRoute);
            _context.SaveChanges();
        }

        public void EditRoute(int routeId, string departureStation, string arrivalStation, DateTime departureTime)
        {
            var route = _context.Routes.Find(routeId);
            if (route != null)
            {
                route.DepartureTime = departureTime;

                _context.SaveChanges();
            }
        }

        public void DeleteRoute(int routeId)
        {
            var route = _context.Routes.Find(routeId);
            if (route != null)
            {
                _context.Routes.Remove(route);
                _context.SaveChanges();
            }
        }

        public void AssignTrainToRoute(int trainId, int routeId)
        {
            var route = _context.Routes.Find(routeId);
            var train = _context.Trains.Find(trainId);

            if (route != null && train != null)
            {   
                route.TrainId = trainId;

                _context.SaveChanges();
            }
        }

    }
}
