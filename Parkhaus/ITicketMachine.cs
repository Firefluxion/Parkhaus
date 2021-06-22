namespace Parkhaus
{
    interface ITicketMachine
    {
        /// <summary>
        /// null == besetzt
        /// </summary>
        public int? CalculatedParkingSpaces { get; }

        bool CheckInShortTerm(string licensePlate);

        bool CheckInLongTerm(string licensePlate);

        void CheckOutLongTerm(string licensePlate);

        IParkTicket CheckOutShortTerm(string licensePlate);
    }
}
