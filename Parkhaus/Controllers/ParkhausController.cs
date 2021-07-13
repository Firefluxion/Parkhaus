using Microsoft.AspNetCore.Mvc;

namespace Parkhaus.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ParkhausController : ControllerBase
    {
        private readonly ITicketMachine ticketMachine;

        public ParkhausController(ITicketMachine ticketMachine)
        {
            this.ticketMachine = ticketMachine;
        }

        [HttpGet]
        public IActionResult GetFreeParkingSpaces()
        {
            return Ok(ticketMachine.FreeParkingSpaces);
        }

        [HttpGet]
        public IActionResult CheckInShortTerm(string licensePlate)
        {
            return Ok(ticketMachine.CheckInShortTerm(licensePlate));
        }

        [HttpGet]
        public IActionResult CheckInLongTerm(string licensePlate)
        {
            return Ok(ticketMachine.CheckInLongTerm(licensePlate));
        }

        [HttpGet]
        public IActionResult GetParkTicketPreview(string licensePlate)
        {
            return Ok(ticketMachine.GetParkTicketPreview(licensePlate));
        }

        [HttpGet]
        public IActionResult ConfirmBilling(IParkTicket parkTicket)
        {
            ticketMachine.ConfirmBilling(parkTicket);
            return Ok();
        }

        [HttpGet]
        public IActionResult CheckOutLongTerm(IParkTicket parkTicket)
        {
            ticketMachine.CheckOutLongTerm(parkTicket);
            return Ok();
        }
    }
}
