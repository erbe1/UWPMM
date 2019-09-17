using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using static UWPMM.Models.WeatherModel;

namespace UWPMM.Weather
{
    public class CurrentWeatherForecastModel
    {

        private const string OpenWeatherUrl = "http://api.openweathermap.org/data/2.5/";
        private string OpenWeatherApiKey = Settings.Settings.Instance.OpenWeatherApiKey;

        public async Task<RootObject> GetCurrentWeather(string lat, string lon)
        {
            var http = new HttpClient();
            var uri = String.Format(OpenWeatherUrl + "weather?lat=" + lat + "&lon=" + lon + "&units=metric&appid=" + OpenWeatherApiKey + "&mode=json&lang=se");
            var response = await http.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<RootObject>(result);

            return data;
        }
    }
    public class RootObject
    {
        [JsonProperty("Coord")]
        public Coord Coord { get; set; }
        [JsonProperty("Weather")]
        public Weather[] Weather { get; set; }
        [JsonProperty("Base")]
        public string Base { get; set; }
        [JsonProperty("Main")]
        public Main Main { get; set; }
        [JsonProperty("Visibility")]
        public int Visibility { get; set; }
        [JsonProperty("Clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty("Dt")]
        public int Dt { get; set; }
        [JsonProperty("Sys")]
        public Sys Sys { get; set; }
        [JsonProperty("Timezone")]
        public int Timezone { get; set; }
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Cod")]
        public int Cod { get; set; }
    }

    public class Coord
    {
        [JsonProperty("Lon")]
        public float Lon { get; set; }
        [JsonProperty("Lat")]
        public float Lat { get; set; }
    }

    public class Main
    {
        [JsonProperty("Temp")]
        public float Temp { get; set; }
        [JsonProperty("Humidity")]
        public int Humidity { get; set; }
        [JsonProperty("Temp_min")]
        public float Temp_min { get; set; }
        [JsonProperty("Temp_max")]
        public float Temp_max { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("All")]
        public int All { get; set; }
    }

    public class Sys
    {
        [JsonProperty("Type")]
        public int Type { get; set; }
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Message")]
        public float Message { get; set; }
        [JsonProperty("Country")]
        public string Country { get; set; }
        [JsonProperty("Sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty("Sunset")]
        public int Sunset { get; set; }
    }

    public class Weather
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Main")]
        public string Main { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Icon")]
        public string Icon { get; set; }
    }
}