using System;

namespace TicketSalesSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }

        public int StartStationId { get; set; }
        public Station StartStation { get; set; }

        public int EndStationId { get; set; }
        public Station EndStation { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}