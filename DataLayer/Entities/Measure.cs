using DataLayer.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Measure : BaseEntity
    {
        [Key]
        public string CityName { get; set; }

        [ForeignKey("CityName")]
        public City City { get; set; }
        [Key]
        public DateTime Time { get; set; }

        public double Tempereture { get; set; }

        public bool ArchiveStatus { get; set; }
        
    }
}
