using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Model
{
    public class CurrentWeatherModel
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Temperature { get; set; }
        public string Feels_like { get; set; }
        public string Temperature_Min { get; set; }
        public string Temperature_Max { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Visibilty { get; set; }
    }
}
