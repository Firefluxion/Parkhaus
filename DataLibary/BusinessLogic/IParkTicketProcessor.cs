using DataLibary.Models;

namespace DataLibary.BusinessLogic
{
    public interface IParkTicketProcessor
    {
        void CheckIn(GarageModel garage, string licensePlate);
        void CheckOut(GarageModel garage, string licensePlate);
        bool CreateLongTermParkTicket(string licensePlate);
        bool DeleteLongTermParkTicket(string licensePlate);
        int OccupiedParkingSpaces(bool? longTerm);
    }
}