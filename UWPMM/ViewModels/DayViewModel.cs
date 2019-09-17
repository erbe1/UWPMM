using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMM.Extensions;
using UWPMM.Models;

namespace UWPMM.ViewModels
{
    public class DayViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public async void GetDay()
        {
            try
            {
                DayModel dayModel = new DayModel();

                var dayInfo = await dayModel.GetCurrentDayInfo();

                this.WeekNr = dayInfo.Dagar[0].Vecka;
                this.NameDay = ExtensionMethods.GetString(dayInfo.Dagar[0].Namnsdag);
                this.HolidayToday = dayInfo.Dagar[0].Helgdag;
                this.NameDayHeader = "Namnsdag";
            }
            catch (Exception)
            {

                this.NameDay = "Kan inte hämta namnsdag.";
            }
        }

        private string _weekNr;
        public string WeekNr
        {
            get
            {
                return _weekNr;
            }
            set
            {
                _weekNr = value;
                OnPropertyChanged();

            }
        }

        private string _nameDay;
        public string NameDay
        {
            get
            {
                return _nameDay;
            }
            set
            {
                _nameDay = value;
                OnPropertyChanged();
            }
        }

        private string _nameDayHeader;
        public string NameDayHeader
        {
            get { return _nameDayHeader; }
            set { _nameDayHeader = value; OnPropertyChanged(); }
        }

        private string _holidayToday;
        public string HolidayToday
        {
            get
            {
                return _holidayToday;
            }
            set
            {
                _holidayToday = value;
                OnPropertyChanged();
            }
        }
    }
}
