using System;
using Prism.Windows.Validation;
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
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using Aerodrom.View_models;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;


namespace Aerodrom.View_models
{
    class OdabirDestinacije : INotifyPropertyChanged
    {
        public ICommand Dalje { get; set; }
        public Pocetna Parent { get; set; }
        public PodaciODestinaciji destinacija { get; set; }
        public DateTime DL { get; set; }
        public DateTime DP { get; set; }
        public DateTime datumLeta;
        public DateTime DatumLeta { get { return datumLeta; } set { datumLeta = value; postavi(value); provjera(); OnNotifyPropertyChanged("DatumLeta");} }
        public DateTime datumPovratka;
        public DateTime DatumPovratka { get { return datumPovratka; } set {datumPovratka= value; postavi1(value); provjera(); OnNotifyPropertyChanged("DatumPovratka");  } }
        private ObservableCollection<string> error;
        public ObservableCollection<string> Error { get { return error; } set { error = value; OnNotifyPropertyChanged("Error"); } }
        private int br;
        public int Br
        {
            get { return br; }
            set { br = value; OnNotifyPropertyChanged("Br"); }
        }
        MapControl Mapa;
        private Geopoint trenutnaLokacija;
        public Geopoint TrenutnaLokacija { get { return trenutnaLokacija; } set { trenutnaLokacija = value; OnNotifyPropertyChanged("TrenutnaLokacija"); } }
        public OdabirDestinacije(Pocetna parent, MapControl mapa)
        {
            this.Parent = parent;
            Error = new ObservableCollection<string>();
            Br = 0;
            DatumLeta = DateTime.Now;
            destinacija = new PodaciODestinaciji();
            destinacija.dodajLetove();
            if (Parent.Zahtjev.TipKarte == true)
            {
                DatumPovratka = DateTime.Now;
                
                DatumPovratka = DatumPovratka.AddYears(2);
            }
            DatumLeta = DatumLeta.AddYears(1);
            Parent.Zahtjev.LetDestinacija = destinacija.Destinacije[0];
            Mapa = mapa;
            dajLokaciju();
            Dalje = new RelayCommand<object>(podaci, mozeLiSeNastaviti);
        }
        public bool mozeLiSeNastaviti(object parametar)
        {
            bool us = Uslov();
            return us;
        }
        public bool Uslov()
        {
            var compare = DateTime.Now.CompareTo(DatumPovratka);
            var compare1 = DateTime.Now.CompareTo(DatumLeta);

            if (Parent.Zahtjev.TipKarte==true && (compare >= 0 || compare1 >= 0))
            {
                return false;
            }
            else if (Parent.Zahtjev.TipKarte == false && compare1 >= 0)
            {
                return false;
            }
            else {
                if (Parent.Zahtjev.TipKarte == true)
                {
                    if (DatumLeta.CompareTo(DatumPovratka) >= 0)
                    { return false; }
                    else
                    {
                        Parent.Zahtjev.DatumLeta = DatumLeta;
                        Parent.Zahtjev.DatumPovratka = DatumPovratka;
                        return true;
                    }
                }
                else
                {
                    Parent.Zahtjev.DatumLeta = DatumLeta;
                    return true;
                }
                
            }
        }
        public void postavi(DateTime o)
        {
            Br++;
            DL = o;
            var compare = DateTime.Now.CompareTo(o);
            if (compare >=0)
            {
                if (Error.Contains("Datum mora biti u budućnosti!") == false )
                    Error.Add("Datum mora biti u budućnosti!");
            }
            else {
                if (Error.Contains("Datum mora biti u budućnosti!"))
                    Error.Remove("Datum mora biti u budućnosti!"); }
        }
        public void postavi1(DateTime o)
        {
            Br++;
            DP = o;
            var compare = DateTime.Now.CompareTo(o);
            if (compare >= 0)
            {
                if (Error.Contains("Datum mora biti u budućnosti! ") == false)
                    Error.Add("Datum mora biti u budućnosti! ");
            }
            else {
                if (Error.Contains("Datum mora biti u budućnosti! "))
                    Error.Remove("Datum mora biti u budućnosti! ");
            }
        }
        public void provjera()
        {
            
            if (Br>=2 && Parent.Zahtjev.TipKarte==true)
            {
                if (DL.CompareTo(DP) >= 0)
                {
                    if (Error.Contains("Datum povratka mora biti poslje datuma leta!") == false)
                        Error.Add("Datum povratka mora biti poslje datuma leta!");
                }
                else {
                    if (Error.Contains("Datum povratka mora biti poslje datuma leta!"))
                    Error.Remove("Datum povratka mora biti poslje datuma leta!"); }
            }
        }
        public void podaci(object parametar)
        {
            Parent.NavigationService.Navigate(typeof(PrevoznoSredstvoView), new PrevoznoSredstvoViewModel(this));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
        public async void dajLokaciju()
        {  
            double centerLatitude1 = Parent.Zahtjev.LetDestinacija.KoordinatePolaska1; 
            double centerLongitude1 = Parent.Zahtjev.LetDestinacija.KoordinatePolaska2; 
            MapPolyline mapPolyline = new MapPolyline();
            mapPolyline.Path = new Geopath(new List<BasicGeoposition>() {
                     new BasicGeoposition() {Latitude=centerLatitude1-0.5, Longitude=centerLongitude1-0.5 },
                     new BasicGeoposition() {Latitude=centerLatitude1+0.5, Longitude=centerLongitude1-0.5 },
                     new BasicGeoposition() {Latitude=centerLatitude1+0.5, Longitude=centerLongitude1+0.5 },
                     new BasicGeoposition() {Latitude=centerLatitude1-0.5, Longitude=centerLongitude1+0.5 },
                     new BasicGeoposition() {Latitude=centerLatitude1-0.5, Longitude=centerLongitude1-0.5 }
               });
            mapPolyline.StrokeColor = Colors.Black;
            mapPolyline.StrokeThickness = 10;
            mapPolyline.StrokeDashed = true;
            Mapa.MapElements.Add(mapPolyline);
            double centerLatitude = Parent.Zahtjev.LetDestinacija.KoordinateDestinacije1; 
            double centerLongitude = Parent.Zahtjev.LetDestinacija.KoordinateDestinacije2; 
            MapPolyline mapPolyline1 = new MapPolyline();
            mapPolyline1.Path = new Geopath(new List<BasicGeoposition>() {
                     new BasicGeoposition() {Latitude=centerLatitude-0.5, Longitude=centerLongitude-0.5 },
                     new BasicGeoposition() {Latitude=centerLatitude+0.5, Longitude=centerLongitude-0.5 },
                     new BasicGeoposition() {Latitude=centerLatitude+0.5, Longitude=centerLongitude+0.5 },
                     new BasicGeoposition() {Latitude=centerLatitude-0.5, Longitude=centerLongitude+0.5 },
                     new BasicGeoposition() {Latitude=centerLatitude-0.5, Longitude=centerLongitude-0.5 }
               });
            mapPolyline1.StrokeColor = Colors.Black;
            mapPolyline1.StrokeThickness = 10;
            mapPolyline1.StrokeDashed = true;
            Mapa.MapElements.Add(mapPolyline1);

            MapPolyline mapPolyline2 = new MapPolyline();
            mapPolyline2.Path = new Geopath(new List<BasicGeoposition>() {
                     new BasicGeoposition() {Latitude=centerLatitude, Longitude=centerLongitude},
                     new BasicGeoposition() {Latitude=centerLatitude1, Longitude=centerLongitude1}
               });
            mapPolyline2.StrokeColor = Colors.Black;
            mapPolyline2.StrokeThickness = 10;
            mapPolyline2.StrokeDashed = true;
            Mapa.MapElements.Add(mapPolyline2);
            BasicGeoposition pozicija = new BasicGeoposition() { Latitude = (centerLatitude + centerLatitude1) / 2, Longitude = (centerLongitude + centerLongitude1) / 2 };
            TrenutnaLokacija = new Geopoint(pozicija);
        }
    }
}
