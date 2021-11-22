using CalendarApp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalendarApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetCityCurrentWeatherData();
        }

        public async void GetCityCurrentWeatherData()
        {
            var currentWeather = "https://api.openweathermap.org/data/2.5/weather?q=Manila&APPID=12c85f36e6495266648068b2ff1fbde3";
            var client = new HttpClient();
            var response = await client.GetStringAsync(currentWeather);
            CurrentWeatherModel currentWeather1 = new CurrentWeatherModel();
            currentWeather1 = JsonConvert.DeserializeObject<CurrentWeatherModel>(response);
            var jsn = JObject.Parse(response);
            var description = jsn["weather"][0]["description"];
            var imageIcon = jsn["weather"][0]["icon"];
            var temperature = jsn["main"]["temp"];
            var actual_feel = jsn["main"]["feels_like"];
        }

        public string GetForecastData()
        {
            var forecastURL = "https://api.openweathermap.org/data/2.5/forecast?q=New%20York&appid=12c85f36e6495266648068b2ff1fbde3&cnt=30";
            return forecastURL;
        }
    }
}