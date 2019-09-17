using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UWPMM.Models
{
    public class TextTvModel
    {
        private const string TextTvUrl = "http://api.texttv.nu/api/get/100?app=uwpmm?json";
        public async Task<IEnumerable<RootTxtTv>> GetCurrentTextNews()
        {
            var http = new HttpClient();
            var uri = String.Format(TextTvUrl);
            var response = await http.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<RootTxtTv>>(result);

            return data;
        }
    }
    public class RootTxtTv
    {
        [JsonProperty("Num")]
        public string Num { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Content")]
        public string[] Content { get; set; }
        [JsonProperty("Next_page")]
        public string Next_page { get; set; }
        [JsonProperty("Prev_page")]
        public string Prev_page { get; set; }
        [JsonProperty("Date_updated_unix")]
        public int Date_updated_unix { get; set; }
        [JsonProperty("Permalink")]
        public string Permalink { get; set; }
        [JsonProperty("Id")]
        public string Id { get; set; }
    }
}
