using DataLayer.Entities;
using System.Collections.Generic;

namespace Domain_Layer.Interfaces
{
    public interface IWeather
    {
        City CurrentConditions(string name);

        IEnumerable<Measure> History(string name);
    }
}
