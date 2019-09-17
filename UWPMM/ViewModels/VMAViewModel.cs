using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMM.Models;

namespace UWPMM.ViewModels
{
    public class VMAViewModel : ViewModelBase, INotifyPropertyChanged
    {
        VMAModel vMA;
        public VMAViewModel()
        {
            vMA = new VMAModel();
        }

        public async void GetVmaMessage()
        {
            try
            {
                var theMessage = await vMA.GetVMA();

                for (int i = 0; i < theMessage.Entries.Length; i++)
                {
                    if (theMessage.Entries[i].CapEvent == "Alert")
                    {
                        this.AlertMsgTitle = theMessage.Entries[i].Title;
                        this.AlertMsgSummary = theMessage.Entries[i].Summary;
                    }
                    else
                    {
                        this.AlertMsgSummary = "Inget VMA för närvarande.";
                    }
                }
            }
            catch (Exception)
            {

                this.AlertMsgTitle = "Kan inte hämta VMA.";
            }
        }

        private string _alertMsgTitle;
        public string AlertMsgTitle
        {
            get
            {
                return _alertMsgTitle;
            }
            set
            {
                _alertMsgTitle = value;
                OnPropertyChanged();

            }
        }

        private string _alertMsgSummary;
        public string AlertMsgSummary
        {
            get
            {
                return _alertMsgSummary;
            }
            set
            {
                _alertMsgSummary = value;
                OnPropertyChanged();
            }
        }
    }
}
