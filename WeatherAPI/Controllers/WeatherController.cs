using DataLayer.Entities;
using Domain_Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.API.Requests;
using PresentationLayer.API.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeather weather;

        public WeatherController(IWeather weather)
        {
            this.weather = weather;
        }

        [HttpGet("{name}")]
        public IActionResult GetCurrentWeatherConditions(string name)
        {
            City city = weather.CurrentConditions(name);
            if (city != null)
                return Ok(new CurrentWeatherConditions 
                { 
                    AverageTemperature = city.AverageTemperature, 
                    CurrentTemperature = city.CurrentTemperature,
                    MaxTemperature = city.MaxTemperature,
                    MinTemperature = city.MinTemperature
                });
            else
                return NotFound();
        }

        [HttpGet("{name}")]
        public IActionResult GetWeatherHistory(string name)
        {
            IEnumerable<Measure> measures = weather.History(name);
            if (measures.Count() > 0)
                return Ok(
                    from item in measures
                    select new WeatherHistoryItem 
                    { 
                        Time = item.Time, 
                        Temperature = item.Temperature, 
                        ArchiveStatus = item.ArchiveStatus
                    });
            else
                return NotFound();
        }

        [HttpPut]
        [HttpPut]
        public async Task<IActionResult> Archiving([FromBody] ArchiveRequest archiveRequest)
        {
            await weather.Archiving(archiveRequest.CityName,archiveRequest.StartTime, archiveRequest.FinishTime);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Unarchiving([FromBody] ArchiveRequest archiveRequest)
        {
            await weather.Unarchiving(archiveRequest.CityName, archiveRequest.StartTime, archiveRequest.FinishTime);
            return Ok();
        }
    }
}
