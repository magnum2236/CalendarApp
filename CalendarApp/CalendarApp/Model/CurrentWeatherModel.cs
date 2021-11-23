using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CalendarApp.Model
{
    public class CurrentWeatherModel : INotifyPropertyChanged
    {
        public string Cloud { get; set; }
        public string Description { get; set; }
        public string Temperature { get; set; }
        public string Feels_like { get; set; }
        
        [JsonProperty("icon")]
        public string Thumb { get; set; }
        public string Temperature_Min { get; set; }
        public string Temperature_Max { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Visibilty { get; set; }
        public string Wind_Speed { get; set; }
        public string Wind_Degree { get; set; }
        public string SunRise { get; set; }
        public string SunSet { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    

}
