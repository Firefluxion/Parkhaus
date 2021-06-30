using DataLibary.BusinessLogic;
using DataLibary.DataAccess;
using DataLibary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Parkhaus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITicketMachine ticketMachine;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITicketMachine ticketMachine)
        {
            _logger = logger;
            this.ticketMachine = ticketMachine;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var before = ticketMachine.FreeParkingSpaces;
            for (int i = 0; i < 150; i++)
            {
                var between = ticketMachine.FreeParkingSpaces;
                IParkTicket parkTicketI = ticketMachine.CheckInShortTerm("ST" + i);
            }

            for (int i = 0; i < 50; i++)
            {
                var between = ticketMachine.FreeParkingSpaces;
                ticketMachine.CheckInLongTerm("LT" + i);
            }

            ticketMachine.CheckInLongTerm("LT1");
            IParkTicket preview = ticketMachine.GetParkTicketPreview("LT1");
            ticketMachine.CheckOutLongTerm(preview);

            IParkTicket parkTicket = ticketMachine.GetParkTicketPreview("ST1");
            ticketMachine.ConfirmBilling(parkTicket);
            var after = ticketMachine.FreeParkingSpaces;

            ticketMachine.CheckInLongTerm("LT1");
            preview = ticketMachine.GetParkTicketPreview("LT1");
            ticketMachine.CheckOutLongTerm(preview);




            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult Test(int id)
        {
            return Ok();
        }
    }
}