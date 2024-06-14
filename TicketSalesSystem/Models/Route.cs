using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.Models
{
    internal class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Station> Stations { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
