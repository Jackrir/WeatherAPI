using DataLayer.Entities;
using DataLayer.Interfaces;
using Domain_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain_Layer.Services
{
    public class MeasureManager : IMeasureManager
    {
        private readonly IRepository repository;
        private readonly ICityManager cityManager;

        public MeasureManager(IRepository repository, ICityManager cityManager)
        {
            this.repository = repository;
            this.cityManager = cityManager;
        }
        public async Task<bool> Add(Measure newMeasure)
        {
            City city = repository.Get<City>(x => x.Name.Equals(newMeasure.CityName));
            if (city != null)
            {
                Measure measure = repository.Get<Measure>(x => x.CityName.Equals(newMeasure.CityName) && x.Time == newMeasure.Time);
                if(measure == null)
                {
                    await repository.AddAsync<Measure>(newMeasure);
                    if (await cityManager.Update(city))
                        return true;
                    else
                        return false;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> Delete(string name, DateTime dateTime)
        {
            Measure measure = repository.Get<Measure>(x => x.CityName.Equals(name) && x.Time == dateTime);
            if (measure != null)
            {
                await repository.DeleteAsync<Measure>(measure);
                if (await cityManager.Update(repository.Get<City>(x => x.Name.Equals(name))))
                    return true;
                else
                    return false;
            }
            return false;
        }

        public IEnumerable<Measure> Get()
        {
            return repository.GetRange<Measure>(x => true);
        }

        public IEnumerable<Measure> GetByCity(string name)
        {
            return repository.GetRange<Measure>(x => x.CityName.Equals(name));
        }

        public Measure GetById(string name, DateTime dateTime)
        {
            return repository.Get<Measure>(x => x.CityName.Equals(name) && x.Time == dateTime);
        }

        public async Task<bool> Update(Measure updateMeasure)
        {
            Measure measure = repository.Get<Measure>(x => x.CityName.Equals(updateMeasure.CityName) && x.Time == updateMeasure.Time);
            if (measure != null)
            {
                await repository.UpdateAsync<Measure>(updateMeasure);
                if (await cityManager.Update(repository.Get<City>(x => x.Name.Equals(updateMeasure.CityName))))
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
