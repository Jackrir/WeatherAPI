using DataLayer.Entities;
using DataLayer.Interfaces;
using Domain_Layer.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain_Layer.Services
{
    public class WeatherParameterCalculator : IWeatherParameterCalculator
    {
        private readonly IRepository repository;
        private IMemoryCache cache;

        public WeatherParameterCalculator(IRepository repository, IMemoryCache cache)
        {
            this.repository = repository;
            this.cache = cache;
        }

        public async Task Calculate(City city)
        {
            IEnumerable<Measure> measures = repository.GetRange<Measure>(x => x.CityName.Equals(city.Name) && x.ArchiveStatus == false); 
            UpdateTemperatureParametrs(measures, ref city);
            await repository.UpdateAsync<City>(city);
            cache.Set(city.Name, city, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
            });
        }

        public void UpdateTemperatureParametrs(IEnumerable<Measure> measures, ref City city)
        {
            if(measures.Count() > 0)
            {
                city.AverageTemperature = measures.Average(x => x.Temperature);
                city.MaxTemperature = measures.Max(x => x.Temperature);
                city.MinTemperature = measures.Min(x => x.Temperature);
                city.CurrentTemperature = measures.OrderByDescending(x => x.Time).First().Temperature;
            }
            else
            {
                city.AverageTemperature = 0;
                city.MaxTemperature = 0;
                city.MinTemperature = 0;
                city.CurrentTemperature = 0;
            }
        }
    }
}
