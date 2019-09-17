using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UWPMM.Models
{
    public class DayModel
    {
        private const string DayUrl = "https://api.dryg.net/dagar/v2.1/";

        public async Task<RootDay> GetCurrentDayInfo()
        {
            var http = new HttpClient();
            var uri = String.Format(DayUrl);
            var response = await http.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<RootDay>(result);

            return data;
        }
    }

    public class RootDay
    {
        public string Cachetid { get; set; }
        public string Version { get; set; }
        public string uUri { get; set; }
        public string Startdatum { get; set; }
        public string Slutdatum { get; set; }
        public Dagar[] Dagar { get; set; }
    }

    public class Dagar
    {
        public string Datum { get; set; }
        public string Veckodag { get; set; }
        public string Arbetsfridag { get; set; }
        public string Röddag { get; set; }
        public string Vecka { get; set; }
        public string Dagivecka { get; set; }
        public string Helgdag { get; set; }
        public string[] Namnsdag { get; set; }
        public string Flaggdag { get; set; }
    }
}
