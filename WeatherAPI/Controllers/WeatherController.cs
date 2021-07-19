using DataLayer.Entities;
using Domain_Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PresentationLayer.API.Requests;
using PresentationLayer.API.Responses;
using System;
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
        private IMemoryCache cache;

        public WeatherController(IWeather weather, IMemoryCache cache)
        {
            this.weather = weather;
            this.cache = cache;
        }

        [HttpGet("{name}")]
        public IActionResult GetCurrentWeatherConditions(string name)
        {
            City city;
            if (!cache.TryGetValue(name, out city))
            {
                city = weather.CurrentConditions(name);
                if (city != null)
                {
                    cache.Set(name, city, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                    });
                    return Ok(new CurrentWeatherConditions
                    {
                        AverageTemperature = city.AverageTemperature,
                        CurrentTemperature = city.CurrentTemperature,
                        MaxTemperature = city.MaxTemperature,
                        MinTemperature = city.MinTemperature
                    });
                }
                else
                    return NotFound();
            }
            return Ok(new CurrentWeatherConditions
            {
                AverageTemperature = city.AverageTemperature,
                CurrentTemperature = city.CurrentTemperature,
                MaxTemperature = city.MaxTemperature,
                MinTemperature = city.MinTemperature
            });
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
        public async Task<IActionResult> Archiving([FromBody] ArchiveRequest archiveRequest)
        {
            if(archiveRequest.StartTime < archiveRequest.FinishTime)
            {
                await weather.Archiving(archiveRequest.CityName, archiveRequest.StartTime, archiveRequest.FinishTime);
                return Ok();
            }
            return Conflict();
        }

        [HttpPut]
        public async Task<IActionResult> Unarchiving([FromBody] ArchiveRequest archiveRequest)
        {
            if (archiveRequest.StartTime < archiveRequest.FinishTime)
            {
                await weather.Unarchiving(archiveRequest.CityName, archiveRequest.StartTime, archiveRequest.FinishTime);
                return Ok();
            }
            return Conflict();
        }
    }
}
