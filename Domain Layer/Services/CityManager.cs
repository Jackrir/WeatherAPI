using DataLayer.Entities;
using DataLayer.Interfaces;
using Domain_Layer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain_Layer.Services
{
    public class CityManager : ICityManager
    {
        private readonly IRepository repository;
        private readonly IWeatherParameterCalculator weatherParameterCalculator;

        public CityManager(IRepository repository, IWeatherParameterCalculator weatherParameterCalculator)
        {
            this.repository = repository;
            this.weatherParameterCalculator = weatherParameterCalculator;
        }
        public async Task<bool> Add(City newCity)
        {
            City city = repository.Get<City>(x => x.Name.Equals(newCity.Name));
            if(city == null)
            {
                await repository.AddAsync<City>(newCity);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(string name)
        {
            City currentCity = repository.Get<City>(x => x.Name.Equals(name));
            if (currentCity != null)
            {
                await repository.DeleteAsync<City>(currentCity);
                return true;
            }
            return false;
        }

        public IEnumerable<City> Get()
        {
            return repository.GetRange<City>(x => true);
        }

        public City GetById(string name)
        {
            return repository.Get<City>(x => x.Name.Equals(name));
        }

        public async Task<bool> Update(City updateCity)
        {
            City currentCity = repository.Get<City>(x => x.Name.Equals(updateCity.Name));
            if (currentCity != null)
            {
                await weatherParameterCalculator.Calculate(currentCity);
                return true;
            }
            return false;
        }
    }
}
