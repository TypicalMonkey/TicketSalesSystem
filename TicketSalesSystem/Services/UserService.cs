using System;
using System.Linq;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Services
{
    internal class UserService
    {
        private ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Login(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public bool Register(User newUser)
        {
            try
            {
                if (string.IsNullOrEmpty(newUser.Username) || string.IsNullOrEmpty(newUser.Password) || string.IsNullOrEmpty(newUser.Email))
                {
                    return false; // Można dodać dodatkową logikę sprawdzania poprawności danych
                }

                if (_context.Users.Any(u => u.Username == newUser.Username))
                {
                    return false; // Użytkownik już istnieje
                }

                newUser.UserRole = UserRole.User;// Ustawienie domyślnej roli użytkownika
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during registration: {ex.Message}");
                return false;
            }
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
