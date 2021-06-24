using DataLibary.DataAccess;
using DataLibary.Models;
using System;

namespace DataLibary.BusinessLogic
{
    public class ParkTicketProcessor : IParkTicketProcessor
    {
        private readonly ISqlDataAccess sqlDataAccess;

        public ParkTicketProcessor(ISqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }

        public bool CreateLongTermParkTicket(string licensePlate)
        {
            if (ParkTicketExists(licensePlate))
            {
                throw new Exception("Duplicate");
            }

            return CreateParkTicket(licensePlate, true);
        }

        public bool DeleteParkTicket(string licensePlate)
        {
            if (!ParkTicketExists(licensePlate))
            {
                throw new Exception("TicketMissing");
            }

            return DeleteParkTicket(new ParkTicketModel { LicensePlate = licensePlate });
        }

        public void CheckInShortTerm(GarageModel garage, string licensePlate)
        {
            if (!ParkTicketExists(licensePlate))
            {
                CreateParkTicket(licensePlate);
            }
            else if (!ParkTicketIsLongTerm(licensePlate))
            {
                throw new Exception("Duplicate");
            }

            AddArrivalTimeToTicket(garage.ID, licensePlate, DateTime.Now);
            SetInParkhaus(licensePlate, true);
        }

        public void CheckInLongTerm(GarageModel garage, string licensePlate)
        {
            if (!ParkTicketExists(licensePlate))
            {
                CreateParkTicket(licensePlate, true);
            }
            else if (!ParkTicketIsLongTerm(licensePlate))
            {
                throw new Exception("Duplicate");
            }

            AddArrivalTimeToTicket(garage.ID, licensePlate, DateTime.Now);
            SetInParkhaus(licensePlate, true);
        }

        public void CheckOut(GarageModel garage, string licensePlate, DateTime checkout)
        {
            if (!ParkTicketExists(licensePlate))
            {
                throw new Exception("ParkTicket missing");
            }

            AddCheckoutTimeToTicket(garage.ID, licensePlate, checkout);
            SetInParkhaus(licensePlate, false);
        }

        public decimal CalculateShortTermTicketPrice(string licensePlate, DateTime checkout)
        {
            if (!ParkTicketExists(licensePlate))
            {
                throw new Exception("TicketMissing");
            }

            if (ParkTicketIsLongTerm(licensePlate))
            {
                throw new Exception("This Parkticket for long term use");
            }

            DateTime arrival = GetShortTermArrivalTime(licensePlate);
            TimeSpan deductedTime = CalculateDeductedTime(arrival, checkout);
            decimal pricePerHour = GetShortTermPricePerHour();

            return Math.Round(pricePerHour * (decimal)deductedTime.TotalHours, 2);
        }

        public decimal CalculateLongTermTicketPrice(string licensePlate, DateTime checkout)
        {
            if (!ParkTicketExists(licensePlate))
            {
                throw new Exception("TicketMissing");
            }

            if (!ParkTicketIsLongTerm(licensePlate))
            {
                throw new Exception("This Parkticket for short term use");
            }

            DateTime arrival = GetRecentLongTermTermArrivalTime(licensePlate);
            TimeSpan deductedTime = CalculateDeductedTime(arrival, checkout);
            decimal pricePerHour = GetLongTermPricePerHour();

            return Math.Round(pricePerHour * (decimal)deductedTime.TotalHours, 2);
        }

        public DateTime GetShortTermArrivalTime(string licensePlate)
        {
            if (!ParkTicketExists(licensePlate))
            {
                throw new Exception("TicketMissing");
            }

            string sql = @"Select Time
                           From Arrivals
                           Where LicensePlate = @LicensePlate";

            return sqlDataAccess.LoadData<DateTime>(sql, new { LicensePlate = licensePlate });
        }

        public DateTime GetRecentLongTermTermArrivalTime(string licensePlate)
        {
            if (!ParkTicketExists(licensePlate))
            {
                throw new Exception("TicketMissing");
            }

            string sql = @"Select Time
                           From Arrivals
                           Where LicensePlate = @LicensePlate
                           Order By Time desc
                           Limit 1;";

            return sqlDataAccess.LoadData<DateTime>(sql, new { LicensePlate = licensePlate });
        }

        public DateTime GetShortTermCheckoutTime(string licensePlate)
        {
            if (!ParkTicketExists(licensePlate))
            {
                throw new Exception("TicketMissing");
            }

            string sql = @"Select Time
                           From Checkouts
                           Where LicensePlate = @LicensePlate";

            return sqlDataAccess.LoadData<DateTime>(sql, new { LicensePlate = licensePlate });
        }

        public TimeSpan CalculateDeductedTime(DateTime arrival, DateTime checkout)
        {
            if (!(arrival.CompareTo(checkout) < 0))
            {
                throw new Exception("The time of arrival has to be earlier that the checkout time!");
            }

            return checkout.Subtract(arrival);
        }

        public decimal GetShortTermPricePerHour()
        {
            string sql = @"Select EuroPerHour
                           From Costs
                           Where Name = @Name";

            return sqlDataAccess.LoadData<decimal>(sql, new { Name = "ShortTerm" });
        }

        public decimal GetLongTermPricePerHour()
        {
            string sql = @"Select EuroPerHour
                           From Costs
                           Where Name = @Name";

            return sqlDataAccess.LoadData<decimal>(sql, new { Name = "LongTerm" });
        }
        public bool ParkTicketIsLongTerm(string licensePlate)
        {
            string sql = @"select LicensePlate, LongTerm from ParkTickets
                            where LicensePlate = @LicensePlate";

            var parkTicket = sqlDataAccess.LoadData<ParkTicketModel>(sql, new ParkTicketModel { LicensePlate = licensePlate });
            return parkTicket.LongTerm;
        }

        private int SetInParkhaus(string licensePlate, bool inParkhaus)
        {
            string sql = @" UPDATE ParkTickets
                            SET InParkhaus = @InParkhaus
                            WHERE LicensePlate = @LicensePlate;";

            return sqlDataAccess.SaveData(sql, new {
                LicensePlate = licensePlate,
                InParkhaus = inParkhaus
            });
        }

        private int AddCheckoutTimeToTicket(int garageID, string licensePlate, DateTime time)
        {
            string sql = @"insert into Checkouts (GarageID, LicensePlate, Time)
                           values (@GarageID, @LicensePlate, @Time);";

            return sqlDataAccess.SaveData(sql, new {
                GarageID = garageID,
                LicensePlate = licensePlate,
                Time = time
            }
            );
        }

        private bool CreateParkTicket(string licensePlate, bool longTerm = false)
        {
            ParkTicketModel parkTicket = new ParkTicketModel() {
                LicensePlate = licensePlate,
                LongTerm = longTerm,
            };

            string sql = @"insert into ParkTickets (LicensePlate, LongTerm)
                           values (@LicensePlate, @LongTerm);";

            return sqlDataAccess.SaveData(sql, parkTicket) == 1;
        }

        private bool ParkTicketExists(string licensePlate)
        {
            string sql = @"select Count(LicensePlate) from ParkTickets
                            where LicensePlate = @LicensePlate";

            var count = sqlDataAccess.CheckData(sql, new ParkTicketModel { LicensePlate = licensePlate });
            return count > 0;
        }

        private ParkTicketModel GetParkTicketByLicense(string licensePlate)
        {
            //join Arrivals Slapper.Automapper for mapping?

            ParkTicketModel parkTicket = new ParkTicketModel() {
                LicensePlate = licensePlate,
            };

            string sql = @"select * from ParkTickets
                            where LicensePlate = @LicensePlate";

            return sqlDataAccess.LoadData<ParkTicketModel>(sql, parkTicket);
        }

        private int AddArrivalTimeToTicket(int garageID, string licensePlate, DateTime time)
        {
            string sql = @"insert into Arrivals (GarageID, LicensePlate, Time)
                           values (@GarageID, @LicensePlate, @Time);";

            return sqlDataAccess.SaveData(sql, new {
                GarageID = garageID,
                LicensePlate = licensePlate,
                Time = time
            }
            );
        }

        private bool DeleteParkTicket(ParkTicketModel parkTicket)
        {
            string sql = @"DELETE FROM ParkTickets
                           WHERE (LicensePlate = @LicensePlate);";

            bool deleted = sqlDataAccess.SaveData(sql, parkTicket) == 1;

            sql = @"DELETE FROM Arrivals
                    WHERE (LicensePlate = @LicensePlate);";

            deleted = sqlDataAccess.SaveData(sql, parkTicket) == 1;

            sql = @"DELETE FROM Checkouts
                    WHERE (LicensePlate = @LicensePlate);";

            deleted = sqlDataAccess.SaveData(sql, parkTicket) == 1;

            return deleted;
        }

        public int OccupiedParkingSpaces(bool? longTerm)
        {
            if (longTerm is null)
            {
                string sql = @"Select Count(*) 
                               From ParkTickets
                               Where InParkhaus = true";

                return sqlDataAccess.CheckData(sql, new { });
            }
            else
            {

                string sql = @"Select Count(*) 
                           From ParkTickets
                           Where LongTerm = @LongTerm AND InParkhaus = true";

                return sqlDataAccess.CheckData(sql, new { LongTerm = longTerm });
            }
        }
    }

}
