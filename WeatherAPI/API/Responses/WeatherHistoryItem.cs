using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.API.Responses
{
    public class WeatherHistoryItem
    {
        public DateTime Time { get; set; }

        public double Temperature { get; set; }

        public bool ArchiveStatus { get; set; }

    }
}
