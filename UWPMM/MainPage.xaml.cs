using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Globalization;
using UWPMM.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPMM
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as MainViewModel;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            //Update the views every minute with new data. Must be a better way...
            DispatcherTimer viewsTimer = new DispatcherTimer();
            viewsTimer.Interval = TimeSpan.FromMinutes(1);
            viewsTimer.Tick += GetAllViews;
            viewsTimer.Start();

            //vm.GetAllViews();

        }

        public void GetAllViews(object sender, object e)
        {
            var vm = this.DataContext as MainViewModel;
            vm.GetAllViews();
        }

        public void Timer_Tick(object sender, object e)
        {
            timeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
            dateTextBlock.Text = DateTimeFormatInfo.CurrentInfo.GetDayName(DateTime.Now.DayOfWeek) + " " + DateTime.Now.ToString("dd") + " " + DateTime.Now.ToString("MMM");
        }
    }
}
