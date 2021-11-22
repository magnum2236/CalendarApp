using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Utils
{
    public class ApiService
    {
        public string GetCityData()
        {
            var URL = "https://pro.openweathermap.org/data/2.5/forecast/climate?q=London,uk&APPID=12c85f36e6495266648068b2ff1fbde3";
            return URL;
        }
    }
}
