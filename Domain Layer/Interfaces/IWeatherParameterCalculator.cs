using DataLayer.Entities;
using System.Threading.Tasks;

namespace Domain_Layer.Interfaces
{
    public interface IWeatherParameterCalculator
    {
        Task Calculate(City city); 
    }
}
