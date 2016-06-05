using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Aerodrom.Converter;
using Aerodrom.Models;
using Aerodrom.View;

namespace Aerodrom.View_models
{

    class PutovanjeViewModel : INotifyPropertyChanged
    {
        public Pocetna Parent { get; set; }
        public ICommand Dalje { get; set; }
        private int br;
        public int Br { get { return br; } set { br = value; OnNotifyPropertyChanged("Br"); } }
        public string rfidKartica;
        public string RfidKartica
        {
            get { return rfidKartica; }
            set { rfidKartica = Regex.Replace(value, "[^0-9a-zA-Z]+", ""); OnNotifyPropertyChanged("RfidKartica"); }
        }
        Rfid rfid;

        public PutovanjeViewModel(Pocetna p)
        {
            Br = 0;
            this.Parent = p;
            rfid = new Rfid();
            rfid.InitializeReader(RfidReadSomething);
            Dalje = new RelayCommand<object>(podaci, mozeLiSeNastaviti);
        }

        public void RfidReadSomething(string rfidKod)
        {
            RfidKartica = rfidKod;
        }
        public bool mozeLiSeNastaviti(object parametar)
        {
            if (RfidKartica == Parent.parent.Kupac.BrojKarteLeta && Br==0)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public void podaci(object parametar)
        {
            
            Parent.NavigationService.Navigate(typeof(SretanLetView));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}