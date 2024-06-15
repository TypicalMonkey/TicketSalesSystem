using System;
using TicketSalesSystem.Data;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Services
{
    internal class CashierService
    {
        private readonly ApplicationDbContext _context;

        public CashierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SellTicket(int userId, int routeId, decimal price)
        {
            var newTicket = new Ticket
            {
                Id = userId,
                RouteId = routeId,
                PurchaseDate = DateTime.Now,
                Price = price
            };

            _context.Tickets.Add(newTicket);
            _context.SaveChanges();
        }

        public void RecordTicketSale(int routeId)
        {
            //TODO
        }
    }
}
