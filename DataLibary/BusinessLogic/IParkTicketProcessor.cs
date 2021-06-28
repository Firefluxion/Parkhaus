using DataLibary.Models;
using System;

namespace DataLibary.BusinessLogic
{
    public interface IParkTicketProcessor
    {
        void CheckInShortTerm(GarageModel garage, string licensePlate);
        void CheckOut(GarageModel garage, string licensePlate, DateTime checkout);
        bool CreateLongTermParkTicket(string licensePlate);
        bool DeleteParkTicket(string licensePlate);
        int OccupiedParkingSpaces(bool? longTerm);
        DateTime GetShortTermArrivalTime(string licensePlate);
        DateTime GetRecentLongTermTermArrivalTime(string licensePlate);
        DateTime GetShortTermCheckoutTime(string licensePlate);
        TimeSpan CalculateDeductedTime(DateTime arrival, DateTime checkout);
        decimal CalculateShortTermTicketPrice(string licensePlate, DateTime checkout);
        decimal GetShortTermPricePerHour();
        decimal GetLongTermPricePerHour();
        void CheckInLongTerm(GarageModel defaultGarage, string licensePlate);
        bool ParkTicketIsLongTerm(string licensePlate);
        decimal CalculateLongTermTicketPrice(string licensePlate, DateTime checkout);
    }
}