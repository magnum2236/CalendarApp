using CalendarApp.Model;
using CalendarApp.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<CurrentWeatherModel> weatherModels = new ObservableCollection<CurrentWeatherModel>();
        
        public ObservableCollection<WeatherSummaryModel> summaryModels = new ObservableCollection<WeatherSummaryModel>();
        public MainPage()
        {
            InitializeComponent();
            GetCityCurrentWeatherData();
            GetForecastData();
        }

        public async void GetCityCurrentWeatherData()
        {
            var currentWeather = "https://api.openweathermap.org/data/2.5/weather?q=Manila&APPID=12c85f36e6495266648068b2ff1fbde3";
            var client = new HttpClient();
            var response = await client.GetStringAsync(currentWeather);
            var jsn = JObject.Parse(response);
            var description = jsn["weather"][0]["description"].ToString();
            var imageIcon = jsn["weather"][0]["icon"].ToString();
            var imageparsed = "http://openweathermap.org/img/w/" + imageIcon + ".png";
            var temperature = jsn["main"]["temp"];
            var actual_feel = jsn["main"]["feels_like"];
            var min_temp = jsn["main"]["temp_min"];
            var max_temp = jsn["main"]["temp_max"];
            var pressure = jsn["main"]["pressure"].ToString();
            var formattedPressure = pressure + "psi";
            var humidity = jsn["main"]["humidity"].ToString();
            var visibility = jsn["visibility"].ToString();
            var wind_speed = jsn["wind"]["speed"].ToString();
            var wind_deg = jsn["wind"]["deg"].ToString();
            var cloud = jsn["clouds"]["all"].ToString();
            var sunrise = jsn["sys"]["sunrise"];
            var sunset = jsn["sys"]["sunset"];
            var timeToday = jsn["dt"];

            //Time Conversion
            TimeSpan time_sunrise = TimeSpan.FromSeconds((double)sunrise);
            TimeSpan time_sunset = TimeSpan.FromSeconds((double)sunset);
            TimeSpan time_right_now = TimeSpan.FromSeconds((double)timeToday);
            string sunrise_time = time_sunrise.ToString(@"hh\:mm\:ss");
            string sunset_time = time_sunset.ToString(@"hh\:mm\:ss");
            string phTime = time_right_now.ToString(@"hh\:mm\:ss");


            //Computation From Kelvin to Farenheit
            double faren;
            double constVal = 273;
            int tempVal = (int)temperature;
            faren = (tempVal - constVal) * 1.8 + 32;

            //Computation From Farenheit to Celsius(For Temperature Value in API)
            double cels;
            cels = (faren - 32) * 0.55556;
            var formatedVal = String.Format("{0:0.##}", cels);
            var tempFormatedVal = formatedVal + "°C";
           

            //Computation for Feels Like (Kelvin to Frenheit)
            double feelsLike_Faren;
            double feelsLike_constVal = 273;
            int actFeel = (int)actual_feel;
            feelsLike_Faren = (actFeel - feelsLike_constVal) * 1.8 + 32;

            //Computation From Farenheit to Celsius(Feels Like)
            double FeelsLike_cels;
            FeelsLike_cels = (feelsLike_Faren - 32) * 0.55556;
            var formatedVal_FeelsLike = String.Format("{0:0.##}", FeelsLike_cels);
            var FeelsLike_Formated = formatedVal_FeelsLike + "°C";
            
            //Computation From Kelvin to Frenheit(Temp Min)
            double TempMin_Faren;
            double TempMin_constVal = 273;
            int tempmin = (int)min_temp;
            TempMin_Faren = (tempmin - TempMin_constVal) * 1.8 + 32;

            //Computation From Farenheit to Celsius(Temp Min)
            double TempMin_cels;
            TempMin_cels = (TempMin_Faren - 32) * 0.55556;
            var formatedVal_TempMin = String.Format("{0:0.##}", FeelsLike_cels);
            var formatedTempMin = formatedVal_TempMin + "°C";
            

            //Computation From Kelvin to Frenheit(Temp Max)
            double TempMax_Faren;
            double TempMax_constVal = 273;
            int tempmax = (int)max_temp;
            TempMax_Faren = (tempmax - TempMax_constVal) * 1.8 + 32;

            //Computation From Farenheit to Celsius(Temp Max)
            double TempMax_cels;
            TempMax_cels = (TempMax_Faren - 32) * 0.55556;
            var formatedVal_TempMax = String.Format("{0:0.##}", FeelsLike_cels);
            var formatedTempMax = formatedVal_TempMax + "°C";
            

            var WeatherDataToday = new CurrentWeatherModel
            {
                Cloud = cloud,
                Description = description,
                Temperature = tempFormatedVal,
                Feels_like = FeelsLike_Formated,
                Temperature_Min = formatedTempMin,
                Temperature_Max = formatedTempMax,
                Pressure = formattedPressure,
                Humidity = humidity,
                Visibilty = visibility,
                Wind_Speed = wind_speed,
                Wind_Degree = wind_deg,
                SunRise = sunrise_time,
                SunSet = sunset_time
            };

            weatherModels.Add(WeatherDataToday);

            WeatherTodayListView.ItemsSource = weatherModels;
            ActualTime.Text = phTime;
        }

        public async void GetForecastData()
        {
            var forecastURL = "https://api.openweathermap.org/data/2.5/forecast?q=Manila&appid=12c85f36e6495266648068b2ff1fbde3&cnt=30";
            var client = new HttpClient();
            var response = await client.GetStringAsync(forecastURL);
            var jsn = JObject.Parse(response);
            
            var temperature = jsn["list"][0]["main"].ToString();
            var weather = jsn["list"][0]["weather"][0].ToString();
            var clouds = jsn["list"][0]["clouds"].ToString();
            var wind = jsn["list"][0]["wind"].ToString();
            var json1 = JsonConvert.DeserializeObject<List<WeatherTempModel>>(temperature);
            var json2 = JsonConvert.DeserializeObject<WeatherModel>(weather);
            var json3 = JsonConvert.DeserializeObject<CloudModel>(clouds);
            var json4 = JsonConvert.DeserializeObject<WindModel>(wind);
        }

        private void clearListViewBackground(object sender, ItemTappedEventArgs e)
        {
            //created this to avoid the orange color background inside ListView when tapping ListView Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}