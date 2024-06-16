using System.Linq;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Services
{
    internal class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Login(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public bool Register(string username, string password, string email)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                return false; 
            }

            var newUser = new User
            {
                Username = username,
                Password = password,
                Email = email,
                UserRole = UserRole.User 
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
