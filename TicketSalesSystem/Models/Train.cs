﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.Models
{
    public class Train
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int Seats { get; set; }
        public int Year { get; set; }
        public bool HasWifi { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
