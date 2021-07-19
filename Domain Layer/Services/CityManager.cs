using DataLayer.Entities;
using DataLayer.Interfaces;
using Domain_Layer.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain_Layer.Services
{
    public class CityManager : ICityManager
    {
        private readonly IRepository repository;
        private readonly IWeatherParameterCalculator weatherParameterCalculator;
        private IMemoryCache cache;

        public CityManager(IRepository repository, IWeatherParameterCalculator weatherParameterCalculator, IMemoryCache cache)
        {
            this.repository = repository;
            this.weatherParameterCalculator = weatherParameterCalculator;
            this.cache = cache;
        }
        public async Task<bool> Add(City newCity)
        {
            City city = repository.Get<City>(x => x.Name.Equals(newCity.Name));
            if(city == null)
            {
                await repository.AddAsync<City>(newCity);
                cache.Set(city.Name, city, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                });
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
                cache.Remove(currentCity.Name);
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
