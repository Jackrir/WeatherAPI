using DataLayer.Entities;
using Domain_Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityManager cityManager;
        private IMemoryCache cache;

        public CityController(ICityManager cityManager, IMemoryCache cache)
        {
            this.cityManager = cityManager;
            this.cache = cache;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<City> cities = cityManager.Get();
            if (cities.Count() > 0)
                return Ok(cities.ToArray());
            else
                return NotFound();
        }

        [HttpGet("{name}")]
        public IActionResult GetId(string name)
        {
            City city;
            if (!cache.TryGetValue(name, out city))
            {
                city = cityManager.GetById(name);
                if (city != null)
                {
                    cache.Set(name, city, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                    });
                    return Ok(city);
                } 
                else
                    return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] City city)
        {
            if (await cityManager.Add(city))
                return StatusCode(201);
            else
                return NoContent();

        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            if(await cityManager.Delete(name))
                return StatusCode(204);
            else
                return NotFound();
        }
    }
}
