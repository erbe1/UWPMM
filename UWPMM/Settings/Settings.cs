using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace UWPMM.Settings
{
    public class Settings
    {
        const string Config = nameof(Config);
        static readonly Lazy<Settings> _settings = new Lazy<Settings>(() => new Settings());

        public static Settings Instance { get; } = _settings.Value;
        public string ResRobotApiKey { get; private set; }
        public string ResRobotOriginId { get; private set; }
        public string ResRobotDestId { get; private set; }
        public string OpenWeatherApiKey { get; private set; }

        Settings()
        {
            var resourceLoader = ResourceLoader.GetForViewIndependentUse(Config);
            ResRobotApiKey = resourceLoader.GetString(nameof(ResRobotApiKey));
            ResRobotOriginId = resourceLoader.GetString(nameof(ResRobotOriginId));
            ResRobotDestId = resourceLoader.GetString(nameof(ResRobotDestId));
            OpenWeatherApiKey = resourceLoader.GetString(nameof(OpenWeatherApiKey));
        } 
    }
}
