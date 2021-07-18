using DataLayer.Entities;
using DataLayer.Interfaces;
using Domain_Layer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain_Layer.Services
{
    public class WeatherParameterCalculator : IWeatherParameterCalculator
    {
        private readonly IRepository repository;

        public WeatherParameterCalculator(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task Calculate(City city)
        {
            IEnumerable<Measure> measures = repository.GetRange<Measure>(x => x.CityName.Equals(city.Name) && x.ArchiveStatus == false); 
            UpdateTemperatureParametrs(measures, ref city);
            await repository.UpdateAsync<City>(city);
        }

        public void UpdateTemperatureParametrs(IEnumerable<Measure> measures, ref City city)
        {
            city.AverageTemperature = measures.Average(x => x.Temperature);
            city.MaxTemperature = measures.Max(x => x.Temperature);
            city.MinTemperature = measures.Min(x => x.Temperature);
            city.CurrentTemperature = measures.OrderByDescending(x => x.Time).First().Temperature;
        }
    }
}
