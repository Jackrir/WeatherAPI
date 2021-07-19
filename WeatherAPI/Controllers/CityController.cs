using DataLayer.Entities;
using Domain_Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityManager cityManager;

        public CityController(ICityManager cityManager)
        {
            this.cityManager = cityManager;
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
            City city = cityManager.GetById(name);
            if (city != null)
                return Ok(city);
            else
                return NotFound();
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
