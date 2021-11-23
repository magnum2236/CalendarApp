using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CalendarApp.Model
{
    public class WeatherSummaryModel : INotifyPropertyChanged
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Temp { get; set; }
        public string Feels_like { get; set; }
        public string Temp_min { get; set; }
        public string Temp_max { get; set; }
        public string Pressure { get; set; }
        public int Sea_level { get; set; }
        public int Grnd_level { get; set; }
        public int Humidity { get; set; }
        public double Temp_kf { get; set; }
        public string Speed { get; set; }
        public string Deg { get; set; }
        public string Gust { get; set; }
        public string All { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class RootObj
    {
        public string objectType { get; set; }
        public List<WeatherSummaryModel> weatherSummaries { get; set; }
    }
}
