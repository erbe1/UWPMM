using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using UWPMM.Models;
//using UWPMM.ServicesHandler;
using UWPMM.Weather;
using UWPMM.Extensions;

namespace UWPMM.ViewModels
{
    public class WeatherViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public async void TemperatureInit()
        {
            try
            {
                CurrentWeatherForecastModel currentWeatherForecast = new CurrentWeatherForecastModel();

                var position = await LocationManager.GetPosition();
                string lat = position.Coordinate.Latitude.ToString();
                string lon = position.Coordinate.Longitude.ToString();
                var tempData = await currentWeatherForecast.GetCurrentWeather(lat, lon);

                this.Temp = tempData.Main.Temp;
                this.Description = tempData.Weather[0].Description.ToString();
                this.Icon = tempData.Weather[0].Icon.ToString();

                string sunrise = ExtensionMethods.UnixTimeToDateTime(tempData.Sys.Sunrise);
                this.Sunrise = sunrise;

                string sunset = ExtensionMethods.UnixTimeToDateTime(tempData.Sys.Sunset);
                this.Sunset = sunset;
            }
            catch (Exception)
            {

                this.Description = "Kan inte hämta nuvarande väderdata.";
            }
        }



        private double _temp;
        public double Temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = Math.Round(value, 1);
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string _icon;
        public string Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = $"ms-appx:///Assets/OpenWeather/{value}.png";
                OnPropertyChanged();
            }
        }

        private string _sunrise;
        public string Sunrise
        {
            get
            {
                return _sunrise;
            }
            set
            {
                _sunrise = value;
                OnPropertyChanged();
            }
        }

        private string _sunset;
        public string Sunset
        {
            get
            {
                return _sunset;
            }
            set
            {
                _sunset = value;
                OnPropertyChanged();
            }
        }

        public async void ForecastInit()
        {
            try
            {
                ForecastWeatherModel forecastWeather = new ForecastWeatherModel();

                var position = await LocationManager.GetPosition();
                string lat = position.Coordinate.Latitude.ToString();
                string lon = position.Coordinate.Longitude.ToString();
                var forecast = await forecastWeather.GetForecast(lat, lon);

                for (int i = 0; i < 5; i++)
                {
                    _forecastTimeArray[i] = ExtensionMethods.UnixTimeToDateTime(forecast.List[i].Dt);
                    _forecastDescriptionArray[i] = forecast.List[i].Weather[0].Description;
                    _forecastTempArray[i] = forecast.List[i].Main.Temp;
                }
                this.ForecastTime = ExtensionMethods.GetString(_forecastTimeArray);
                this.ForecastDescription = ExtensionMethods.GetString(_forecastDescriptionArray);
                this.ForecastTemp = ExtensionMethods.GetDouble(_forecastTempArray);
            }
            catch (Exception)
            {

                this.ForecastTime = "Kan inte hämta väderprognos.";
            }
        }


        private string[] _forecastTimeArray = new string[5];
        public string[] ForecastTimeArray
        {
            get
            {
                return _forecastTimeArray;
            }
            set
            {
                _forecastTimeArray = value;
                OnPropertyChanged();
            }
        }

        private string _forecastTime;
        public string ForecastTime
        {
            get
            {
                return _forecastTime;
            }
            set
            {
                _forecastTime = value;
                OnPropertyChanged();
            }
        }

        private string[] _forecastDescriptionArray = new string[5];
        public string[] ForecastDescriptionArray
        {
            get
            {
                return _forecastDescriptionArray;
            }
            set
            {
                _forecastDescriptionArray = value;
                OnPropertyChanged();
            }
        }

        private string _forecastDescription;
        public string ForecastDescription
        {
            get
            {
                return _forecastDescription;
            }
            set
            {
                _forecastDescription = value;
                OnPropertyChanged();
            }
        }

        private double[] _forecastTempArray = new double[5];
        public double[] ForecastTempArray
        {
            get
            {
                return _forecastTempArray;
            }
            set
            {
                _forecastTempArray = value;
                OnPropertyChanged();
            }
        }

        private string _forecastTemp;
        public string ForecastTemp
        {
            get
            {
                return _forecastTemp;
            }
            set
            {
                _forecastTemp = value;
                OnPropertyChanged();
            }
        }

        private string _city = "Borås"; //Since OpenWeatherMap dosent return åäö...
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
    }

}

