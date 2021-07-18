using DataLayer.Entities;
using Domain_Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        private readonly IMeasureManager measureManager;

        public MeasureController(IMeasureManager measureManager)
        {
            this.measureManager = measureManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Measure> cities = measureManager.Get();
            return Ok(cities.ToArray());
        }

        [HttpGet("{name}/{time}")]
        public IActionResult GetId(string name, DateTime time)
        {
            Measure measure = measureManager.GetById(name, time);
            if (measure != null)
                return Ok(measure);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Measure measure)
        {
            if (await measureManager.Add(measure))
                return StatusCode(201);
            else
                return NoContent();

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Measure measure)
        {
            if (await measureManager.Update(measure))
                return Ok();
            else
                return NoContent();

        }

        [HttpDelete("{name}/{time}")]
        public async Task<IActionResult> Delete(string name, DateTime time)
        {
            if (await measureManager.Delete(name, time))
                return StatusCode(204);
            else
                return NotFound();
        }

    }
}
