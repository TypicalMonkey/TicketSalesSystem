using System;
using System.Collections.Generic;
using TicketSalesSystem.Models;

public class Route
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int TrainId { get; set; }
    public Train Train { get; set; }
    public List<OrderedStation> OrderedStations { get; set; }
}
