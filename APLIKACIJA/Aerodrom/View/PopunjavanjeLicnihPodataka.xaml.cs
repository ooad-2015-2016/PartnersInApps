using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Aerodrom.View_models;
using Windows.UI.Popups;
using Aerodrom;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Aerodrom.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PopunjavanjeLicnihPodataka : Page
    {
        PopunjavanjeLicnihPodatakaViewModel popunjavanjeLicnihPodatakaViewModel;
        PrevoznoSredstvoViewModel PS;
        private int br;
        public int Br { get { return br; } set { br = value; } }
        public PopunjavanjeLicnihPodataka()
        {
            this.InitializeComponent();
            Br = 0;
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;

           
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PS = (PrevoznoSredstvoViewModel)e.Parameter;
            popunjavanjeLicnihPodatakaViewModel = new PopunjavanjeLicnihPodatakaViewModel(PS, PreviewControl);
            this.DataContext = popunjavanjeLicnihPodatakaViewModel;
        }
        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
        private async void click1(object sender, RoutedEventArgs e)
        {
            var d = new MessageDialog(File.ReadAllText("Help.txt"));
            d.Title = "Help za korištenje aplikacije";
            await d.ShowAsync();
        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            checkBox.Content = "Imam";
            textBox6.IsReadOnly = false;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            checkBox.Content = "Nemam";
            textBox6.IsReadOnly = true;
        }

        private async void click(object sender, RoutedEventArgs e)
        {
            textBlock15.Text = "1";
            if (textBox.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                textBlock15.Text = "1";
                var d = new MessageDialog("Nisu popunjena prazna polja! \r\n(ime, prezime, datum rodjenja, broj telefona i email) ");
                d.Title = "Greška!";
                await d.ShowAsync();
            }
            else if (Br==0)
            {
                textBlock15.Text = "1";
                var d = new MessageDialog("Niste se uslikali!");
                d.Title = "Greška!";
                await d.ShowAsync();
            }
            else { textBlock15.Text = "0"; }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Br = 1;
        }
    }
}
