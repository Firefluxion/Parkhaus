namespace Parkhaus
{
    public interface ITicketMachine
    {
        /// <summary>
        /// null == besetzt
        /// </summary>
        public int? FreeParkingSpaces { get; }

        IParkTicket CheckInShortTerm(string licensePlate);

        IParkTicket CheckInLongTerm(string licensePlate);

        void CheckOutLongTerm(IParkTicket ticket);

        IParkTicket GetParkTicketPreview(string licensePlate);

        void ConfirmBilling(IParkTicket ticket);
    }
}
