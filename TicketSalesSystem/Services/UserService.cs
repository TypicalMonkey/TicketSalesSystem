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

        public User Login(string login, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == login && u.Password == password);
        }

        public void Register(string login, string password, string email, UserRole role)
        {
            var newUser = new User
            {
                Username = login,
                Password = password,
                Email = email,
                UserRole = role
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
