using DataLayer.Entities;
using Domain_Layer.Interfaces;
using System;
using System.Collections.Generic;

namespace Domain_Layer.Services
{
    public class Weather : IWeather
    {
        private readonly ICityManager cityManager;
        private readonly IMeasureManager measureManager;

        public Weather(ICityManager cityManager, IMeasureManager measureManager)
        {
            this.cityManager = cityManager;
            this.measureManager = measureManager;
        }

        public City CurrentConditions(string name)
        {
            return cityManager.GetById(name);
        }

        public IEnumerable<Measure> History(string name)
        {
            return measureManager.GetByCity(name);
        }
    }
}
