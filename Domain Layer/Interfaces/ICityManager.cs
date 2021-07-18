using DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain_Layer.Interfaces
{
    public interface ICityManager
    {
        IEnumerable<City> Get();

        City GetById(string name);

        Task<bool> Add(City newCity);

        Task<bool> Update(City updateCity);

        Task<bool> Delete(string name);
    }
}
