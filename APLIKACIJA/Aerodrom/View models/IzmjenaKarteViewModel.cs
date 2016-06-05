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
using Aerodrom.View_Models.GPSViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Aerodrom.View_models
{
    class IzmjenaKarteViewModel
    {
        public ICommand dalje;
        public ICommand Dalje { get { return dalje; } set { dalje = value; OnNotifyPropertyChanged("Dalje"); } }
        public Pocetna parent { get; set; }
        public Kupac Kupac { get; set; }
        public CameraHelper Camera { get; set; }
        public ICommand Uslikaj { get; set; }
        private SoftwareBitmapSource slika;
        public SoftwareBitmapSource Slika { get { return slika; } set { slika = value; OnNotifyPropertyChanged("Slika"); } }
        CaptureElement previewControl;
        private int br;
        public int Br { get { return br; } set { br = value; OnNotifyPropertyChanged("Br"); } }
        public IzmjenaKarteViewModel(Pocetna p)
        {
            Br = 0;
            this.parent = p;
            Kupac = new Kupac();
            Kupac = p.parent.Kupac;
            Camera = new CameraHelper(previewControl);
            Camera.InitializeCameraAsync();
            Erori = new ObservableCollection<string>();
            Kupac.ErrorsChanged += Vm_ErrorsChanged;
            Uslikaj = new RelayCommand<object>(uslikaj, (object parametar) => true);
            Dalje = new RelayCommand<object>(podaci, mozeLiSeNastaviti);

        }
        public bool mozeLiSeNastaviti(object parametar)
        {
            bool a = provjera();
            return a;
        }
        public bool provjera()
        {
            if (Erori.Count() == 0 && br == 0) 
                return true;
            else return false;
        }
        public void podaci(object parametar)
        {
            parent.NavigationService.Navigate(typeof(MainPage));
        }
        public async void uslikaj(object parametar)
        {
            await Camera.TakePhotoAsync(SlikanjeGotovo);
        }
        public void SlikanjeGotovo(SoftwareBitmapSource slikica)
        {
            Slika = slikica;
            Kupac.Slika = Slika;
        }
        private void Vm_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            //event koji ce se pozvati kad dodje do neispravne validacije
            //daj sve greske i pretvori ih u listu stringova da se mogu ispisati
            Erori = new ObservableCollection<string>(Kupac.Errors.Errors.Values.SelectMany(x => x).ToList());
        }

        //mora biti observableCollection i pozvati OnNotifyPropertyChanged da bi se primjetila promjena liste da bi view skontao da se mora izmjeniti
        private ObservableCollection<string> erori;
        public ObservableCollection<string> Erori { get { return erori; } set { erori = value; OnNotifyPropertyChanged("Erori"); } }

        //implementacija INotifyPropertyChanged interfejsa koji ova klasa implementira
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
