using DataLibary.Models;

namespace DataLibary.BusinessLogic
{
    public interface IGarageProcessor
    {
        int CreateGarage(int id, string name, int capacity, int reservedForLongTerm, int shortTermAccessMinThreshold, int displayOccupiedThreshold);
        GarageModel LoadGarageByName(string name);
    }
}