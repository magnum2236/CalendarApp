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
            var min_temp = jsn["main"]["temp_min"];
            var max_temp = jsn["main"]["temp_max"];
            var pressure = jsn["main"]["pressure"];
            var humidity = jsn["main"]["humidity"];
            var visibility = jsn["visibility"];
            var wind_speed = jsn["wind"]["speed"];
            var wind_deg = jsn["wind"]["deg"];
            var wind_gust = jsn["wind"]["gust"];
            var cloud = jsn["clouds"]["all"];
            var sunrise = jsn["sys"]["sunrise"];
            var sunset = jsn["sys"]["sunset"];
            TimeSpan time_sunrise = TimeSpan.FromSeconds((double)sunrise);
            TimeSpan time_sunset = TimeSpan.FromSeconds((double)sunset);
            string sunrise_time = time_sunrise.ToString(@"hh\:mm\:ss");
            string sunset_time = time_sunset.ToString(@"hh\:mm\:ss");
        }

        public string GetForecastData()
        {
            var forecastURL = "https://api.openweathermap.org/data/2.5/forecast?q=New%20York&appid=12c85f36e6495266648068b2ff1fbde3&cnt=30";
            return forecastURL;
        }
    }
}