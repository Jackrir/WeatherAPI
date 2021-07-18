using DataLayer.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class City : BaseEntity
    {
        [Key]
        public string Name { get; set; }

        public double CurrentTemperature { get; set; }

        public double AverageTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }


        public List<Measure> Measures { get; set; }
    }
}
