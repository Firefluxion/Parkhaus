using DataLibary.BusinessLogic;
using DataLibary.Models;
using System;

namespace Parkhaus
{
    public class DefaultTicketMachine : ITicketMachine
    {
        private readonly GarageModel defaultGarage;
        private readonly IParkTicketProcessor parkTicketProcessor;

        public DefaultTicketMachine(IGarageProcessor garageProcessor, IParkTicketProcessor parkTicketProcessor)
        {
            defaultGarage = garageProcessor.LoadGarageByName("DefaultGarage");
            this.parkTicketProcessor = parkTicketProcessor;
        }

        public int? FreeParkingSpaces 
        {
            get
            {
                int freeSpaces = defaultGarage.SpacesForShortTerm - parkTicketProcessor.OccupiedParkingSpaces(false);

                int occupiedLongTermSpaces = parkTicketProcessor.OccupiedParkingSpaces(true);
                if (occupiedLongTermSpaces > defaultGarage.ReservedForLongTerm)
                {
                    freeSpaces -= (occupiedLongTermSpaces - defaultGarage.ReservedForLongTerm);
                }

                if ( freeSpaces < defaultGarage.ShortTermAccessMinThreshold)
                {
                    return null;
                }

                return freeSpaces;
            }
        }

        public IParkTicket CheckInLongTerm(string licensePlate)
        {
            int freeSpaces = defaultGarage.Capacity - parkTicketProcessor.OccupiedParkingSpaces(null);

            if (freeSpaces <= 0)
            {
                return null;
            }

            parkTicketProcessor.CheckInLongTerm(defaultGarage, licensePlate);
            
            return new ParkTicket {
                LicensePlate = licensePlate,
                ArrivalTime = parkTicketProcessor.GetRecentLongTermTermArrivalTime(licensePlate),
                PricePerHour = parkTicketProcessor.GetLongTermPricePerHour(),
            };
        }

        public IParkTicket CheckInShortTerm(string licensePlate)
        {
            int freeSpaces = defaultGarage.SpacesForShortTerm - parkTicketProcessor.OccupiedParkingSpaces(false);

            int occupiedLongTermSpaces = parkTicketProcessor.OccupiedParkingSpaces(true);
            if (occupiedLongTermSpaces > defaultGarage.ReservedForLongTerm)
            {
                freeSpaces -= (occupiedLongTermSpaces - defaultGarage.ReservedForLongTerm);
            }

            if (freeSpaces <= defaultGarage.ShortTermAccessMinThreshold)
            {
                return null;
            }

            parkTicketProcessor.CheckInShortTerm(defaultGarage, licensePlate);

            return new ParkTicket {
                LicensePlate = licensePlate,
                ArrivalTime = parkTicketProcessor.GetShortTermArrivalTime(licensePlate),
                PricePerHour = parkTicketProcessor.GetShortTermPricePerHour(),
            };
        }

        public void CheckOutLongTerm(IParkTicket ticket)
        {
            parkTicketProcessor.CheckOut(defaultGarage, ticket.LicensePlate, ticket.CheckoutTime);
        }

        public void ConfirmBilling(IParkTicket ticket)
        {
            parkTicketProcessor.CheckOut(defaultGarage, ticket.LicensePlate, ticket.CheckoutTime);
            parkTicketProcessor.DeleteParkTicket(ticket.LicensePlate);
        }

        public IParkTicket GetParkTicketPreview(string licensePlate)
        {
            bool longTerm = parkTicketProcessor.ParkTicketIsLongTerm(licensePlate);
            DateTime arrival = longTerm ? parkTicketProcessor.GetRecentLongTermTermArrivalTime(licensePlate) : parkTicketProcessor.GetShortTermArrivalTime(licensePlate);
            DateTime checkout = DateTime.Now;

            return new ParkTicket() {
                LicensePlate = licensePlate,
                LongTerm = longTerm,
                ArrivalTime = arrival,
                CheckoutTime = checkout,
                DeductedTime = parkTicketProcessor.CalculateDeductedTime(arrival, checkout),
                PricePerHour = longTerm ? parkTicketProcessor.GetLongTermPricePerHour() : parkTicketProcessor.GetShortTermPricePerHour(),
                Price = longTerm? parkTicketProcessor.CalculateLongTermTicketPrice(licensePlate, checkout) : parkTicketProcessor.CalculateShortTermTicketPrice(licensePlate, checkout),
            };
        }
    }
}
