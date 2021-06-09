using DataLibary.BusinessLogic;
using DataLibary.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly DatabaseSettings databaseSettings;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DatabaseSettings databaseSettings)
        {
            _logger = logger;
            this.databaseSettings = databaseSettings;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            DataLibary.Models.GarageModel x = new GarageProcessor(new MySqlDataAccess(databaseSettings)).LoadGarageByName("DefaultGarage");

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