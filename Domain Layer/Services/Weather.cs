using DataLayer.Entities;
using DataLayer.Interfaces;
using Domain_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain_Layer.Services
{
    public class Weather : IWeather
    {
        private readonly ICityManager cityManager;
        private readonly IMeasureManager measureManager;
        private readonly IRepository repository;

        public Weather(ICityManager cityManager, IMeasureManager measureManager, IRepository repository)
        {
            this.cityManager = cityManager;
            this.measureManager = measureManager;
            this.repository = repository;
        }

        public async Task Archiving(string cityName, DateTime startTime, DateTime finishTime)
        {
            IEnumerable<Measure> measures = repository.GetRange<Measure>(x => x.CityName.Equals(cityName) && x.Time >= startTime && x.Time <= finishTime);
            if(measures.Count() > 0)
            {
                foreach (Measure measure in measures)
                {
                    measure.ArchiveStatus = true;
                }
                await repository.UpdateRangeAsync<Measure>(measures);
                await cityManager.Update(repository.Get<City>(x => x.Name.Equals(cityName)));
            }
            
        }

        public City CurrentConditions(string name)
        {
            return cityManager.GetById(name);
        }

        public IEnumerable<Measure> History(string name)
        {
            return measureManager.GetByCity(name);
        }

        public async Task Unarchiving(string cityName, DateTime startTime, DateTime finishTime)
        {
            IEnumerable<Measure> measures = repository.GetRange<Measure>(x => x.CityName.Equals(cityName) && x.Time >= startTime && x.Time <= finishTime);
            if (measures.Count() > 0)
            {
                foreach (Measure measure in measures)
                {
                    measure.ArchiveStatus = false;
                }
                await repository.UpdateRangeAsync<Measure>(measures);
                await cityManager.Update(repository.Get<City>(x => x.Name.Equals(cityName)));
            }
            
        }
    }
}
