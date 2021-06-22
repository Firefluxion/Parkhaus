using System;
using System.Collections.Generic;

namespace DataLibary.Models
{
    public class ParkTicketModel
    {
        public string LicensePlate { get; set; }
        public bool LongTerm { get; set; }
        public List<DateTime> Arrivals { get; set; }
        public List<DateTime> Exits { get; set; }
    }
}
