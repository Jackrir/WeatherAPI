using DataLayer.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Measure : BaseEntity
    {
        [Key]
        [Required]
        public string CityName { get; set; }

        [ForeignKey("CityName")]
        public City City { get; set; }
        [Key]
        [Required]
        public DateTime Time { get; set; }
        [Required]

        public double Temperature { get; set; }
        [Required]

        public bool ArchiveStatus { get; set; }
        
    }
}
