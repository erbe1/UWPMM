using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UWPMM.Models
{
    public class VMAModel
    {

        private const string VMAUrl = "http://api.krisinformation.se/v1/feed?format=json";

        public async Task<VMARoot> GetVMA()
        {
            var http = new HttpClient();
            var uri = String.Format(VMAUrl);
            var response = await http.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<VMARoot>(result);

            return data;
        }
    }


    public class VMARoot
    {
        [JsonProperty("Entries")]
        public Entry[] Entries { get; set; }
    }

    public class Entry
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("Updated")]
        public DateTime Updated { get; set; }
        [JsonProperty("Published")]
        public DateTime Published { get; set; }
        [JsonProperty("CapEvent")]
        public string CapEvent { get; set; }
        [JsonProperty("Author")]
        public Author Author { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Link")]
        public Link Link { get; set; }
        [JsonProperty("Summary")]
        public string Summary { get; set; }
        [JsonProperty("CapArea")]
        public Caparea[] CapArea { get; set; }
    }

    public class Author
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public class Link
    {
        [JsonProperty("Id")]
        public object Id { get; set; }
        [JsonProperty("LinkName")]
        public object LinkName { get; set; }
        [JsonProperty("LinkUrl")]
        public string LinkUrl { get; set; }
    }

    public class Caparea
    {
        [JsonProperty("CapAreaDesc")]
        public string CapAreaDesc { get; set; }
        [JsonProperty("Coordinate")]
        public string Coordinate { get; set; }
    }

}
