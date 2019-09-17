using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMM.Models;

namespace UWPMM.ViewModels
{
    public class TextTvViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public async void GetTextTvNews()
        {
            try
            {
                TextTvModel textTvModel = new TextTvModel();

                var textTvNews = await textTvModel.GetCurrentTextNews();
                string theNewsString;
                foreach (var news in textTvNews)
                {
                    theNewsString = news.Title;
                    this.NewsFlash = Extensions.ExtensionMethods.TrimNewsString(theNewsString);
                }
                this.NewsFlashHeader = "Nyheter";
            }
            catch (Exception)
            {

                this.NewsFlash = "Kan inte hämta nyheter.";
            }
        }

        private string _newsFlash;
        public string NewsFlash
        {
            get
            {
                return _newsFlash;
            }
            set
            {
                _newsFlash = value;
                OnPropertyChanged();
            }
        }

        private string _newsFlashHeader;
        public string NewsFlashHeader
        {
            get { return _newsFlashHeader; }
            set { _newsFlashHeader = value; OnPropertyChanged(); }
        }
    }
}
