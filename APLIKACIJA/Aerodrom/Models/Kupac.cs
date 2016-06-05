using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using Prism.Windows.Validation;
using System.ComponentModel.DataAnnotations;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;


using System.Runtime.CompilerServices;

using System.Windows.Input;
using Aerodrom.View;
using Aerodrom.Models;
using Aerodrom.Converter;
using Aerodrom.View_Models.GPSViewModel;
using Windows.UI.Xaml.Controls;


namespace Aerodrom.Models
{
    public class Kupac : ValidatableBindableBase, INotifyPropertyChanged
    {
        private string ime;
        private string prezime;
        private string brojTelefona;
        private string datumRodjenja;
        private string email;
        private bool membershipCard;
        private string brojMembershipCard;
        private DateTime datumKupovine;
        private string brojKarteLeta;
        private Let let;
        private DateTime datumLeta;
        private DateTime datumPovratka;
        private int sjediste;
        private string prevoznoSredstvo;
        private bool tipKarte;
        public SoftwareBitmapSource slika;
        #region Properties
        public bool TipKarte
        {
            get { return tipKarte; }
            set { tipKarte = value; OnPropertyChanged("tipKarte"); }
        }
        [Required(ErrorMessage = "Niste unijeli broj membership kartice"), RegularExpression(@"\d{4}", ErrorMessage = "Broj membership kartice je 4 cifre!")]
        public string BrojMembershipCard
        {
            get { return brojMembershipCard; }
            set { brojMembershipCard = value; OnPropertyChanged("BrojMembershipCard"); }
        }
        public string PrevoznoSredstvo
        {
            get { return prevoznoSredstvo; }
            set { prevoznoSredstvo = value; OnPropertyChanged("prevoznoSredtstvo"); }
        }
        public int Sjediste
        {
            get { return sjediste; }
            set { sjediste = value; OnPropertyChanged("Sjediste"); }
        }
        public DateTime DatumPovratka
        {
            get { return datumPovratka; }
            set { datumPovratka = value; OnPropertyChanged("DatumPovratka"); }
        }
        public DateTime DatumLeta
        {
            get { return datumLeta; }
            set { datumLeta = value; OnPropertyChanged("DatumLeta"); }
        }
        public Let Let
        {
            get { return let; }
            set { let = value; OnPropertyChanged("let"); }
        }
        [Required(ErrorMessage = "Niste unijeli ime!")]
        public string Ime
        {
            get { return ime; }
            set { SetProperty(ref ime, value); OnPropertyChanged("Ime"); }
        }
        [Required(ErrorMessage = "Niste unijeli prezime!")]
        public string Prezime
        {
            get { return prezime; }
            set { SetProperty(ref prezime, value); OnPropertyChanged("Prezime"); }
        }
        [Required(ErrorMessage = "Niste unijeli datum rodjenja"), RegularExpression(@"\d{2}" + "/" + @"\d{2}" + "/" + @"\d{2}", ErrorMessage = "Pogrešan format!")]
        public string DatumRodjenja
        {
            get { return datumRodjenja; }
            set { SetProperty(ref datumRodjenja, value); OnPropertyChanged("datumRodjenja"); }
        }
        [Required(ErrorMessage = "Niste unijeli broj telefona"), RegularExpression(@"\d{3}" + "/" + @"\d{3}" + "-" + @"\d{3}", ErrorMessage = "Pogrešan format!")]
        public string BrojTelefona
        {
            get { return brojTelefona; }
            set { SetProperty(ref brojTelefona, value); OnPropertyChanged("brojTelefona"); }
        }
        [Required(ErrorMessage = "Niste unijeli e-mail!")]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); OnPropertyChanged("email"); }
        }
        public bool MembershipCard
        {
            get { return membershipCard; }
            set { membershipCard = value; OnPropertyChanged("membershipCard"); }
        }
        public DateTime DatumKupovine
        {
            get { return datumKupovine; }
            set { datumKupovine = value; OnPropertyChanged("datumKupovine"); }
        }
        public string BrojKarteLeta
        {
            get { return brojKarteLeta; }
            set { brojKarteLeta = value; OnPropertyChanged("brojKarteLeta"); }
        }
        public SoftwareBitmapSource Slika { get { return slika; } set { slika = value; } }
        #endregion
        public Kupac() { }
      //  public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged(string p)
        //{
          //  if (PropertyChanged != null)
           //     PropertyChanged(this, new PropertyChangedEventArgs(p));
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}