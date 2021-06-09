using DataLibary.DataAccess;
using DataLibary.Models;

namespace DataLibary.BusinessLogic
{
    public class GarageProcessor
    {
        private readonly MySqlDataAccess sqlDataAccess;

        public GarageProcessor(MySqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }

        public int CreateGarage(int id, string name, int capacity, int reservedForLongTerm, int shortTermAccessMinThreshold, int displayOccupiedThreshold)
        {
            GarageModel garage = new GarageModel {
                ID = id,
                Name = name,
                Capacity = capacity,
                ReservedForLongTerm = reservedForLongTerm,
                ShortTermAccessMinThreshold = shortTermAccessMinThreshold,
                DisplayOccupiedThreshold = displayOccupiedThreshold
            };

            string sql = @"insert into Garages (ID, Name, Capacity, ReservedForLongTerm, ShortTermAccessMinThreshold, DisplayOccupiedThreshold)
                           values (@ID, @Name, @Capacity, @ReservedForLongTerm, @ShortTermAccessMinThreshold, @DisplayOccupiedThreshold)";

            return sqlDataAccess.SaveData(sql, garage);
        }

        public GarageModel LoadGarageByName(string name)
        {
            GarageModel garage = new GarageModel { Name = name }
            ;
            string sql = @"select ID, Name, Capacity, ReservedForLongTerm, ShortTermAccessMinThreshold, DisplayOccupiedThreshold
                           from Garages
                           where Name = @Name;";

            return sqlDataAccess.LoadData(sql, garage);
        }
    }
}
