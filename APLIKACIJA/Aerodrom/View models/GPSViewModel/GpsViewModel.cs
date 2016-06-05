using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls;
using System.Windows.Input;
using Aerodrom.View_models;
using Aerodrom.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Aerodrom.View;
using Aerodrom.Converter;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Aerodrom.View_Models.GPSViewModel
{
    class GpsViewModel : INotifyPropertyChanged
    {
        public Kupac Kupac { get; set; }
        public ICommand Dalje { get; set; }
        public PopunjavanjeLicnihPodatakaViewModel parent { get; set; }
        //trenutna lokacija koja ce se naci sa geolocation
        private Geopoint trenutnaLokacija;
        public Geopoint TrenutnaLokacija { get { return trenutnaLokacija; } set { trenutnaLokacija = value; OnNotifyPropertyChanged("TrenutnaLokacija"); } }
        //string lokacije za ispis u textBlock/adresa isto
        private string lokacija;
        public string Lokacija { get { return lokacija; } set { lokacija = value; OnNotifyPropertyChanged("Lokacija"); } }
        private string adresa;
        public string Adresa { get { return adresa; } set { adresa = value; OnNotifyPropertyChanged("Adresa"); } }
        //krsenje mvvm za mapu .. neophodno
        MapControl Mapa;
        private int br;
        public int Br { get { return br; } set { br = value; OnNotifyPropertyChanged("Br"); } }

        public GpsViewModel(MapControl mapa, PopunjavanjeLicnihPodatakaViewModel p)
        {
            Br = 0;
            this.parent = p;
            Kupac = p.Kupac;
            Mapa = mapa;
            dajLokaciju();
            Dalje = new RelayCommand<object>(podaci,moze);
        }
        public bool moze(object parametar)
        {
            bool a = Br == 0;
            return a;
        }
        public void podaci(object parametar)
        {
            parent.parent.parent.Parent.NavigationService.Navigate(typeof(MainPage), new Pocetna(this));
        }
      
        public async void dajLokaciju()
        {
            Geoposition pos = null;
            //da li se smije uzeti lokacija, trazi se odobrenje od korisnika (takodjer treba i capability)
            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                //uzimanje pozicije ako smije
                Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 10 };
                pos = await geolocator.GetGeopositionAsync();
            }
            //tacka iz pozicije
            TrenutnaLokacija = pos.Coordinate.Point;
            Lokacija = "Geolokacija Lat: " + TrenutnaLokacija.Position.Latitude + " Lng: " + TrenutnaLokacija.Position.Longitude;
            //uzeti adresu na osnovu GeoTacke
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pos.Coordinate.Point);
            //Nadje li adresu ispisi je 
            if (result.Status == MapLocationFinderStatus.Success)
            {
                Adresa = "Adresa je " + result.Locations[0].Address.Street;
            }
            //nacrtati pravougaonik na mapi za oblast gdje bi korisnik mogao biti
            double centerLatitude = Mapa.Center.Position.Latitude;
            double centerLongitude = Mapa.Center.Position.Longitude;
            MapPolyline mapPolyline = new MapPolyline();
            mapPolyline.Path = new Geopath(new List<BasicGeoposition>() {
                     new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 },
                     new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude-0.001 },
                     new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude+0.001 },
                     new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude+0.001 },
                     new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 }
               });
            mapPolyline.StrokeColor = Colors.Black;
            mapPolyline.StrokeThickness = 3;
            mapPolyline.StrokeDashed = true;
            Mapa.MapElements.Add(mapPolyline);
            BasicGeoposition pozicija = new BasicGeoposition() { Latitude = centerLatitude , Longitude = centerLongitude };
            TrenutnaLokacija = new Geopoint(pozicija);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
