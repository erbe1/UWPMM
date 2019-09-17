using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using UWPMM.Settings;

namespace UWPMM.PublicTransportation
{
    public class ResRobotModel
    {
        private const string ResRobotUrl = "https://api.resrobot.se/v2/trip?key=";
        private string ResRobotApi = Settings.Settings.Instance.ResRobotApiKey;  
        private string OriginId = Settings.Settings.Instance.ResRobotOriginId;
        private string DestId = Settings.Settings.Instance.ResRobotDestId;

        public async Task<Transport> GetPublicTransportInfo()
        {
            var http = new HttpClient();
            var uri = String.Format(ResRobotUrl + ResRobotApi + "&originId=" + OriginId + "&destId=" +  DestId + "&format=json");
            var response = await http.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Transport>(result);

            return data;
        }
    }

    public class Transport
    {
        [JsonProperty("Trip")]
        public Trip[] Trip { get; set; }
        [JsonProperty("ScrB")]
        public string ScrB { get; set; }
        [JsonProperty("ScrF")]
        public string ScrF { get; set; }
    }

    public class Trip
    {
        [JsonProperty("ServiceDays")]
        public Serviceday[] ServiceDays { get; set; }
        [JsonProperty("LegList")]
        public Leglist LegList { get; set; }
        [JsonProperty("Idx")]
        public int Idx { get; set; }
        [JsonProperty("TripId")]
        public string TripId { get; set; }
        [JsonProperty("CtxRecon")]
        public string CtxRecon { get; set; }
        [JsonProperty("Duration")]
        public string Duration { get; set; }
    }

    public class Leglist
    {
        [JsonProperty("Leg")]
        public Leg[] Leg { get; set; }
    }

    public class Leg
    {
        [JsonProperty("Origin")]
        public Origin Origin { get; set; }
        [JsonProperty("Destination")]
        public Destination Destination { get; set; }
        [JsonProperty("Product")]
        public Product Product { get; set; }
        [JsonProperty("Stops")]
        public Stops Stops { get; set; }
        [JsonProperty("Idx")]
        public string Idx { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("TransportNumber")]
        public string TransportNumber { get; set; }
        [JsonProperty("TransportCategory")]
        public string TransportCategory { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Reachable")]
        public bool Reachable { get; set; }
        [JsonProperty("Direction")]
        public string Direction { get; set; }
    }

    public class Origin
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("ExtId")]
        public string ExtId { get; set; }
        [JsonProperty("Lon")]
        public float Lon { get; set; }
        [JsonProperty("Lat")]
        public float Lat { get; set; }
        [JsonProperty("RouteIdx")]
        public int RouteIdx { get; set; }
        [JsonProperty("Time")]
        public string Time { get; set; }
        [JsonProperty("Date")]
        public string Date { get; set; }
    }

    public class Destination
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public string ExtId { get; set; }
        public float Lon { get; set; }
        public float Lat { get; set; }
        public int RouteIdx { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Num { get; set; }
        public string CatCode { get; set; }
        public string CatOutS { get; set; }
        public string CatOutL { get; set; }
        public string OperatorCode { get; set; }
        public string _operator { get; set; }
        public string OperatorUrl { get; set; }
    }

    public class Stops
    {
        public Stop[] Stop { get; set; }
    }

    public class Stop
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string ExtId { get; set; }
        public int RouteIdx { get; set; }
        public float Lon { get; set; }
        public float Lat { get; set; }
        public string DepTime { get; set; }
        public string DepDate { get; set; }
        public string ArrTime { get; set; }
        public string ArrDate { get; set; }
    }

    public class Serviceday
    {
        public string PlanningPeriodBegin { get; set; }
        public string PlanningPeriodEnd { get; set; }
        public string SDaysR { get; set; }
        public string SDaysI { get; set; }
        public string SDaysB { get; set; }
    }

}
