using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain_Layer.Interfaces
{
    public interface IWeather
    {
        City CurrentConditions(string name);

        IEnumerable<Measure> History(string name);

        Task Archiving(string cityName, DateTime startTime, DateTime finishTime);

        Task Unarchiving(string cityName, DateTime startTime, DateTime finishTime);
    }
}
