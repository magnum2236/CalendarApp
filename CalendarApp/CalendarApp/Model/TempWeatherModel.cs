using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Model
{
    public class TempWeatherModel
    {
        public string DayDate { get; set; }
        public string Description { get; set; }
        public string Temp { get; set; }
        public string Temp_Min { get; set; }
        public string Temp_Max { get; set; }
        public string Feels_Like { get; set; }
        public string Icon { get; set; }
    }
}
