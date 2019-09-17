using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMM.PublicTransportation;
using UWPMM.Extensions;

namespace UWPMM.ViewModels
{
    public class ResRobotViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public async void GetTransportation()
        {
            try
            {
                ResRobotModel resRobot = new ResRobotModel();
                var traficInfo = await resRobot.GetPublicTransportInfo();

                this.BusNumber = traficInfo.Trip[0].LegList.Leg[0].Product.Name;
                this.OriginDest = traficInfo.Trip[0].LegList.Leg[0].Origin.Name;
                this.Destination = traficInfo.Trip[0].LegList.Leg[0].Destination.Name;

                for (int i = 0; i < traficInfo.Trip.Length; i++)
                {
                    _departures[i] = traficInfo.Trip[i].LegList.Leg[0].Origin.Time.Substring(0, traficInfo.Trip[i].LegList.Leg[0].Origin.Time.Length - 3);
                    _arrivals[i] = traficInfo.Trip[i].LegList.Leg[0].Destination.Time.Substring(0, traficInfo.Trip[i].LegList.Leg[0].Destination.Time.Length - 3); ;
                }

                this.TheDepartures = ExtensionMethods.GetString(Departures);
                this.TheArrivals = ExtensionMethods.GetString(Arrivals);

            }
            catch (Exception)
            {

                this.BusNumber = "Kan inte hämta busstider.";
            }
        }

        private string _busNumber;
        public string BusNumber
        {
            get
            {
                return _busNumber;
            }
            set
            {
                _busNumber = value;
                OnPropertyChanged();
            }
        }

        private string _originDest;
        public string OriginDest
        {
            get
            {
                return _originDest;
            }
            set
            {
                _originDest = value;
                OnPropertyChanged();
            }
        }

        private string _destination;
        public string Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                _destination = value;
                OnPropertyChanged();
            }
        }

        private string[] _arrivals = new string[7];
        public string[] Arrivals
        {
            get
            {
                return _arrivals;
            }
            set
            {
                _arrivals = value;
                OnPropertyChanged();
            }
        }

        private string _theArrivals;
        public string TheArrivals
        {
            get
            {
                return _theArrivals;
            }
            set
            {
                _theArrivals = value;
                OnPropertyChanged();
            }
        }

        private string[] _departures = new string[7];
        public string[] Departures
        {
            get
            {
                return _departures;
            }
            set
            {
                _departures = value;
                OnPropertyChanged();
            }
        }

        private string _theDepartures;
        public string TheDepartures
        {
            get
            {
                return _theDepartures;
            }
            set
            {
                _theDepartures = value;
                OnPropertyChanged();
            }
        }
    }
}
