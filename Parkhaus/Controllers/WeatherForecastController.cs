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
        private readonly IGarageProcessor garageProcessor;
        private readonly IParkTicketProcessor parkTicketProcessor;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IGarageProcessor garageProcessor, IParkTicketProcessor parkTicketProcessor)
        {
            _logger = logger;
            this.garageProcessor = garageProcessor;
            this.parkTicketProcessor = parkTicketProcessor;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            GarageModel garage = garageProcessor.LoadGarageByName("DefaultGarage");

            parkTicketProcessor.CreateLongTermParkTicket("LT");
            parkTicketProcessor.CheckIn(garage, "LT");
            Thread.Sleep(1000);
            parkTicketProcessor.CheckOut(garage, "LT");
            parkTicketProcessor.CheckIn(garage, "LT");

            parkTicketProcessor.CheckIn(garage, "ST1");
            //parkTicketProcessor.CheckOut(garage, "ST1");
            Thread.Sleep(1000);

            parkTicketProcessor.CheckOut(garage, "LT");
            parkTicketProcessor.CheckIn(garage, "LT");
            Thread.Sleep(1000);

            parkTicketProcessor.CheckOut(garage, "LT");
            //parkTicketProcessor.DeleteLongTermParkTicket("LT");



            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}