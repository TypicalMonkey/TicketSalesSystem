using System.ComponentModel.DataAnnotations;

namespace TicketSalesSystem.Models
{
    public class OrderedStation
    {
        [Key]
        public int Id { get; set; }
        public int Order { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public int StationId { get; set; }
        public Station Station { get; set; }
    }
}
