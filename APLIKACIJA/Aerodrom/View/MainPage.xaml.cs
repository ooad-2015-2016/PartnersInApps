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
using Windows.UI.Popups;
using Aerodrom.View_Models.GPSViewModel;
using System.Text;

namespace Aerodrom
{
    public sealed partial class MainPage : Page
    {
        private int br;
        public int Br { get { return br; } set { br = value; } }
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new Pocetna();
            NavigationCacheMode = NavigationCacheMode.Required;
            // Br = Convert.ToInt32(File.ReadAllText("TextFile1.txt"));
            Br = 0;
        }
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Aerodrom.View.LogIn));
        }
        private async void click(object sender, RoutedEventArgs e)
        {
            var d = new MessageDialog(File.ReadAllText("Help.txt"));
            d.Title = "Help za korištenje aplikacije";
            await d.ShowAsync();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private async void click1(object sender, RoutedEventArgs e)
        {
            if (Br==0)
            {
                Br = 0;
                var d = new MessageDialog("Niste kupili kartu da bi vršili izmjene!");
                d.Title = "Greška!";
                await d.ShowAsync();
            }
            else if(Br==1)
            {
                Br = 0;
                var d = new MessageDialog("Uspješno ste poništili prethodno kupljenu kartu!");
                d.Title = "Obaviještenje!";
                await d.ShowAsync();
            }
           // else { Br = 0; File.WriteAllText("TextFile1.txt", "0"); }
        }

        private void click2(object sender, RoutedEventArgs e)
        {
           
          //   File.AppendAllText("TextFile1.txt", "0");
        
        }
    }
}
