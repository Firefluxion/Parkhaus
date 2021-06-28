using System;

namespace Parkhaus
{
    public class ParkTicket : IParkTicket
    {
        public string LicensePlate { get; set; }

        public bool LongTerm { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime CheckoutTime { get; set; }

        public TimeSpan DeductedTime { get; set; }

        public decimal PricePerHour { get; set; }

        public decimal Price { get; set; }
    }
}
