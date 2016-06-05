using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Aerodrom.Models;
using Aerodrom.Converter;
using Aerodrom.View;
using Aerodrom.View_Models.GPSViewModel;

namespace Aerodrom.View_models
{
    class Pocetna
    {
        public Zahtjev Zahtjev { get; set; }
        public ICommand Putuj { get; set; }
        public ICommand KartaUJednomPravcu { get; set; }
        public ICommand PovratnaAvioKarta { get; set; }
        public ICommand Izmjeni { get; set; }
        public INavigationService NavigationService { get; set; }
        public GpsViewModel parent { get; set; }
        public Pocetna()
        {
            Zahtjev = new Zahtjev();
            NavigationService = new NavigationService();
            KartaUJednomPravcu = new RelayCommand<object>(IKartaUJednomPravcu);
            PovratnaAvioKarta = new RelayCommand<object>(IPovratnaAvioKarta);
            Putuj = new RelayCommand<object>(Idemo);
        }
        public Pocetna(GpsViewModel p)
        {
            this.parent = p;
            NavigationService = new NavigationService();
            KartaUJednomPravcu = new RelayCommand<object>(IKartaUJednomPravcu);
            PovratnaAvioKarta = new RelayCommand<object>(IPovratnaAvioKarta);
            Putuj = new RelayCommand<object>(Idemo);
            Izmjeni = new RelayCommand<object>(izmjeni);
        }
        public void izmjeni(object parametar)
        {
            NavigationService.Navigate(typeof(IzmjenaKarte), new IzmjenaKarteViewModel(this));
        }
        public void IKartaUJednomPravcu (object parametar)
        {
            Zahtjev.TipKarte = false;
            NavigationService.Navigate(typeof(Karta_u_jednom_pravcu),this);
        }
        public void IPovratnaAvioKarta(object parametar)
        {
            Zahtjev.TipKarte = true;
            NavigationService.Navigate(typeof(Povratna_avio_karta), this);
        }
        public void Idemo(object parametar)
        {
            NavigationService.Navigate(typeof(KreniNaLetView), new PutovanjeViewModel(this));
        }
    }
}
