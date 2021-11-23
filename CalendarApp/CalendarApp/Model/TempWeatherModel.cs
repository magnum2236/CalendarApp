using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Model
{
    public class TempWeatherModel
    {   
        public string Temp { get; set; }
        public string Feels_like { get; set; }
        public string Temp_min { get; set; }
        public string Temp_max { get; set; }
        public string Pressure { get; set; }
        public int Sea_level { get; set; }
        public int Grnd_level { get; set; }
        public int Humidity { get; set; }
        public double Temp_kf { get; set; }
        
    }

    public class WeatherTempModel
    {
        public List<TempWeatherModel> tempWeathers { get; set; }
    }
}
