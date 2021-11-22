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
            var jsn = JObject.Parse(response);
            var description = jsn["weather"][0]["description"];
            var imageIcon = jsn["weather"][0]["icon"].ToString();
            var imageparsed = imageIcon + ".png";
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

            //Time Conversion
            TimeSpan time_sunrise = TimeSpan.FromSeconds((double)sunrise);
            TimeSpan time_sunset = TimeSpan.FromSeconds((double)sunset);
            string sunrise_time = time_sunrise.ToString(@"hh\:mm\:ss");
            string sunset_time = time_sunset.ToString(@"hh\:mm\:ss");


            //Computation From Kelvin to Farenheit
            double faren;
            double constVal = 273;
            int tempVal = (int)temperature;
            faren = (tempVal - constVal) * 1.8 + 32;

            //Computation From Farenheit to Celsius(For Temperature Value in API)
            double cels;
            cels = (faren - 32) * 0.55556;
            var formatedVal = String.Format("{0:0.##}", cels);

            WeatherDesc.Text = description.ToString();
            ImgThumbNail.Source = imageparsed;
            TempDesc.Text = formatedVal.ToString() + "°C";

            //Computation for Feels Like (Kelvin to Frenheit)
            double feelsLike_Faren;
            double feelsLike_constVal = 273;
            int actFeel = (int)actual_feel;
            feelsLike_Faren = (actFeel - feelsLike_constVal) * 1.8 + 32;

            //Computation From Farenheit to Celsius(Feels Like)
            double FeelsLike_cels;
            FeelsLike_cels = (feelsLike_Faren - 32) * 0.55556;
            var formatedVal_FeelsLike = String.Format("{0:0.##}", FeelsLike_cels);
            FeelsLikeContainer.Text = formatedVal_FeelsLike.ToString() + "°C";

            //Computation From Kelvin to Frenheit(Temp Min)
            double TempMin_Faren;
            double TempMin_constVal = 273;
            int tempmin = (int)min_temp;
            TempMin_Faren = (tempmin - TempMin_constVal) * 1.8 + 32;

            //Computation From Farenheit to Celsius(Temp Min)
            double TempMin_cels;
            TempMin_cels = (TempMin_Faren - 32) * 0.55556;
            var formatedVal_TempMin = String.Format("{0:0.##}", FeelsLike_cels);
            MinTempContainer.Text = formatedVal_TempMin.ToString() + "°C";

            //Computation From Kelvin to Frenheit(Temp Max)
            double TempMax_Faren;
            double TempMax_constVal = 273;
            int tempmax = (int)max_temp;
            TempMax_Faren = (tempmax - TempMax_constVal) * 1.8 + 32;

            //Computation From Farenheit to Celsius(Temp Max)
            double TempMax_cels;
            TempMax_cels = (TempMax_Faren - 32) * 0.55556;
            var formatedVal_TempMax = String.Format("{0:0.##}", FeelsLike_cels);
            MaxTempContainer.Text = formatedVal_TempMax.ToString() + "°C";
        }

        public string GetForecastData()
        {
            var forecastURL = "https://api.openweathermap.org/data/2.5/forecast?q=New%20York&appid=12c85f36e6495266648068b2ff1fbde3&cnt=30";
            return forecastURL;
        }
    }
}