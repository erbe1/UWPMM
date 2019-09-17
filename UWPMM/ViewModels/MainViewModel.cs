using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMM.ViewModels;
using UWPMM.Weather;

namespace UWPMM.ViewModels
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public void GetAllViews()
        {
            ResRobot.GetTransportation();
            Weather.TemperatureInit();
            Weather.ForecastInit();
            Vma.GetVmaMessage();
            Day.GetDay();
            News.GetTextTvNews();
        }
        public WeatherViewModel Weather { get; } = new WeatherViewModel();

        public ResRobotViewModel ResRobot { get; } = new ResRobotViewModel();

        public VMAViewModel Vma { get; } = new VMAViewModel();

        public DayViewModel Day { get; } = new DayViewModel();

        public TextTvViewModel News { get; } = new TextTvViewModel();

    }
}
