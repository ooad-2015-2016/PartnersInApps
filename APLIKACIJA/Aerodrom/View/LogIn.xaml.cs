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
using Windows.UI.Popups;
using Aerodrom;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Aerodrom.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogIn : Page
    {
        public LogIn()
        {
            this.InitializeComponent();

            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
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

        private async void click1(object sender, RoutedEventArgs e)
        {

            var d = new MessageDialog("Ne postoji baza podataka!");
            d.Title = "Greška!";
            await d.ShowAsync();
        }
    }
}
