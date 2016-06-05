using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Aerodrom.View;
using Aerodrom.Models;
using Aerodrom.Converter;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace Aerodrom.View_models
{
    class PrevoznoSredstvoViewModel: INotifyPropertyChanged
    {
        public ICommand Dalje { get; set; }
        public OdabirDestinacije parent { get; set; }
        public PrevoznoSredstvo PS { get; set; }
        public Zahtjev zahtjev { get; set; }
        private int sjediste;
        public int Sjediste { get { return sjediste; } set { sjediste = value; postavi(value); OnNotifyPropertyChanged("Sjediste"); } }
        private ObservableCollection<string> error;
        public ObservableCollection<string> Error { get { return error; } set { error = value;  OnNotifyPropertyChanged("Error"); } }
        public PrevoznoSredstvoViewModel(OdabirDestinacije p)
        {
            Error = new ObservableCollection<string>();
            this.parent = p;
            PS = new PrevoznoSredstvo();
            PS.dodajKupce();
            Sjediste = 1;
            zahtjev = parent.Parent.Zahtjev;
            zahtjev.PrevoznoSredstvo = PS.PrevoznaSredstva[0];
            Dalje = new RelayCommand<object>(podaci, mozeLiSeNastaviti);
        }
        public bool mozeLiSeNastaviti(object parametar)
        {
            if (PS.ZauzetaMjesta.Contains(Sjediste))
            {
                return false;
            }
            else {
                zahtjev.Sjediste = Convert.ToString(Sjediste);
                return true;
            }
        }
        public void postavi(int o)
        {
            if (PS.ZauzetaMjesta.Contains(o))
            {
                if(Error.Contains("Mjesto je zauzeto!")==false)
                Error.Add("Mjesto je zauzeto!");
            }
            else { Error.Clear(); }
        }
        public void podaci(object parametar)
        {
            parent.Parent.NavigationService.Navigate(typeof(PopunjavanjeLicnihPodataka), this);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
