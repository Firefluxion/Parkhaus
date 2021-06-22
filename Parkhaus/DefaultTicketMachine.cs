using DataLibary.BusinessLogic;
using DataLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public int? CalculatedParkingSpaces => throw new NotImplementedException();

        public bool CheckInLongTerm(string licensePlate)
        {
            if (parkTicketProcessor.OccupiedParkingSpaces(null) <= defaultGarage.Capacity)
            {
                return false;
            }

            parkTicketProcessor.CheckIn(defaultGarage, licensePlate);
            
            return true;
        }

        public bool CheckInShortTerm(string licensePlate)
        {
            if (parkTicketProcessor.OccupiedParkingSpaces(null) <= defaultGarage.ShortTermAccessMinThreshold)
            {
                return false;
            }

            parkTicketProcessor.CheckIn(defaultGarage, licensePlate);

            return true;
        }

        public void CheckOutLongTerm(string licensePlate)
        {
            throw new NotImplementedException();
        }

        public IParkTicket CheckOutShortTerm(string licensePlate)
        {
            throw new NotImplementedException();
        }
    }
}
