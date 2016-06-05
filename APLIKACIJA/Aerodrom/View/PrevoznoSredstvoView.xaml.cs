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
using Aerodrom;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Aerodrom.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PrevoznoSredstvoView : Page
    {
        public PrevoznoSredstvoView()
        {
            this.InitializeComponent();
            checkBox.IsChecked = true;
            textBlock3.Text = "1";
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (PrevoznoSredstvoViewModel)e.Parameter;
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
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            textBlock3.Text = "1";
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox3.IsChecked = false;
            checkBox4.IsChecked = false;
            checkBox5.IsChecked = false;
            checkBox6.IsChecked = false;
            checkBox7.IsChecked = false;
            checkBox8.IsChecked = false;
        }
        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            textBlock3.Text = "2";
            checkBox.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox3.IsChecked = false;
            checkBox4.IsChecked = false;
            checkBox5.IsChecked = false;
            checkBox6.IsChecked = false;
            checkBox7.IsChecked = false;
            checkBox8.IsChecked = false;

        }
        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            textBlock3.Text = "3";
            checkBox1.IsChecked = false;
            checkBox.IsChecked = false;
            checkBox3.IsChecked = false;
            checkBox4.IsChecked = false;
            checkBox5.IsChecked = false;
            checkBox6.IsChecked = false;
            checkBox7.IsChecked = false;
            checkBox8.IsChecked = false;

        }
        private void checkBox3_Checked(object sender, RoutedEventArgs e)
        {
            textBlock3.Text = "4";
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox.IsChecked = false;
            checkBox4.IsChecked = false;
            checkBox5.IsChecked = false;
            checkBox6.IsChecked = false;
            checkBox7.IsChecked = false;
            checkBox8.IsChecked = false;

        }
        private void checkBox4_Checked(object sender, RoutedEventArgs e)
        {
            textBlock3.Text = "5";
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox3.IsChecked = false;
            checkBox.IsChecked = false;
            checkBox5.IsChecked = false;
            checkBox6.IsChecked = false;
            checkBox7.IsChecked = false;
            checkBox8.IsChecked = false;

        }
        private void checkBox5_Checked(object sender, RoutedEventArgs e)
        {
            textBlock3.Text = "6";
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox3.IsChecked = false;
            checkBox4.IsChecked = false;
            checkBox.IsChecked = false;
            checkBox6.IsChecked = false;
            checkBox7.IsChecked = false;
            checkBox8.IsChecked = false;

        }
        private void checkBox6_Checked(object sender, RoutedEventArgs e)
        {
            textBlock3.Text = "7";
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox3.IsChecked = false;
            checkBox4.IsChecked = false;
            checkBox5.IsChecked = false;
            checkBox.IsChecked = false;
            checkBox7.IsChecked = false;
            checkBox8.IsChecked = false;

        }
        private void checkBox7_Checked(object sender, RoutedEventArgs e)
        {
            textBlock3.Text = "8";
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox3.IsChecked = false;
            checkBox4.IsChecked = false;
            checkBox5.IsChecked = false;
            checkBox6.IsChecked = false;
            checkBox.IsChecked = false;
            checkBox8.IsChecked = false;

        }
        private void checkBox8_Checked(object sender, RoutedEventArgs e)
        {
            textBlock3.Text = "9";
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox3.IsChecked = false;
            checkBox4.IsChecked = false;
            checkBox5.IsChecked = false;
            checkBox6.IsChecked = false;
            checkBox7.IsChecked = false;
            checkBox.IsChecked = false;

        }
    }
}
