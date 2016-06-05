using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Aerodrom.View_Models.GPSViewModel;
 using Aerodrom.View_models;
using Windows.UI.Popups;
using Windows.UI.Core;
using Aerodrom;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Aerodrom.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GpsView : Page
    {
        PopunjavanjeLicnihPodatakaViewModel p;
        public GpsView()
        {
            this.InitializeComponent();
           
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mapa.Style = MapStyle.Aerial3DWithRoads;
            mapa.ZoomLevel = 20;
            p = (PopunjavanjeLicnihPodatakaViewModel)e.Parameter;
            this.DataContext = new GpsViewModel(mapa,p);
        }
        private async void button_Click_1(object sender, RoutedEventArgs e)
        {
            textBlock15.Text = "1";
            if (textblock.Text == "" || textblock1.Text == "" )
            {
                textBlock15.Text = "1";
                var d = new MessageDialog("Niste locirani!  \r\n(iz sigurnosnih razloga)");
                d.Title = "Greška!";
                await d.ShowAsync();
            }
            else { textBlock15.Text = "0"; //File.WriteAllText("TextFile1.txt", "1"); 
            }
        }
        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
        private async void click(object sender, RoutedEventArgs e)
        {
            var d = new MessageDialog(File.ReadAllText("Help.txt"));
            d.Title = "Help za korištenje aplikacije";
            await d.ShowAsync();
        }
    }
}
