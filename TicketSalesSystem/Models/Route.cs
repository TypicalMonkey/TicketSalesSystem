using System;
using System.Collections.Generic;

namespace TicketSalesSystem.Models
{
    internal class Route
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string DepartureStation { get; set; } 
        public string ArrivalStation { get; set; } 
        public DateTime DepartureTime { get; set; } 
        public int TrainId { get; set; } 
        public Train Train { get; set; } 

        public List<Station> Stations { get; set; }
    }
}
