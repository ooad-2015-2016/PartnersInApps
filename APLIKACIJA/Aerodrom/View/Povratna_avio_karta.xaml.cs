using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using Aerodrom.View_models;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using Aerodrom.View_Models.GPSViewModel;
using Windows.UI.Popups;
using Aerodrom;

namespace Aerodrom
{
    public sealed partial class Povratna_avio_karta : Page
    {
        OdabirDestinacije Od;
        Pocetna P;
        public Povratna_avio_karta()
        {
            this.InitializeComponent();

           

            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            mapa.Style = MapStyle.Aerial3DWithRoads;
            mapa.ZoomLevel = 6;
            P = (Pocetna)e.Parameter;
            Od = new OdabirDestinacije(P, mapa);
            this.DataContext = Od;
        }
        private async void click(object sender, RoutedEventArgs e)
        {
            var d = new MessageDialog(File.ReadAllText("Help.txt"));
            d.Title = "Help za korištenje aplikacije";
            await d.ShowAsync();
        }
        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

    }
}
