using System.Collections.Generic;

namespace DataLibary.Models
{
    public class GarageModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int ReservedForLongTerm { get; set; }
        public int ShortTermAccessMinThreshold { get; set; }
        public int DisplayOccupiedThreshold { get; set; }
    }
}