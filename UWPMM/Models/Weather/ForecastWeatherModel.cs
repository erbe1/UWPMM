using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UWPMM.Weather
{
    public class ForecastWeatherModel
    {
        private const string OpenWeatherUrl = "http://api.openweathermap.org/data/2.5/";
        private string OpenWeatherApiKey = Settings.Settings.Instance.OpenWeatherApiKey;
        public async Task<Forecast> GetForecast(string lat, string lon)
        {
            var http = new HttpClient();
            var uri = String.Format(OpenWeatherUrl + "forecast?lat=" + lat + "&lon=" + lon + "&units=metric&appid=" + OpenWeatherApiKey + "&mode=json&lang=se");
            var response = await http.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Forecast>(result);

            return data;
        }
    }

    public class Forecast
    {
        [JsonProperty("Cod")]
        public string Cod { get; set; }
        [JsonProperty("Message")]
        public float Message { get; set; }
        [JsonProperty("Cnt")]
        public int Cnt { get; set; }
        [JsonProperty("List")]
        public List[] List { get; set; }
        [JsonProperty("City")]
        public City City { get; set; }
    }

    public class City
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Coord")]
        public Coord Coord { get; set; }
        [JsonProperty("Country")]
        public string Country { get; set; }
        [JsonProperty("Population")]
        public int Population { get; set; }
        [JsonProperty("Timezone")]
        public int Timezone { get; set; }
        [JsonProperty("Sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty("Sunset")]
        public int Sunset { get; set; }
    }

    public class List
    {
        [JsonProperty("Dt")]
        public int Dt { get; set; }
        [JsonProperty("Main")]
        public Main Main { get; set; }
        [JsonProperty("Weather")]
        public Weather[] Weather { get; set; }
        [JsonProperty("Clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty("Sys")]
        public Sys Sys { get; set; }
        [JsonProperty("Dt_txt")]
        public string Dt_txt { get; set; }
        [JsonProperty("Rain")]
        public Rain Rain { get; set; }
    }
    public class Rain
    {
        [JsonProperty("_3h")]
        public float _3h { get; set; }
    }
}
