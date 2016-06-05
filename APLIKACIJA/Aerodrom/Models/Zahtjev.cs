using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Aerodrom.Converter;

namespace Aerodrom.Models
{
    class Zahtjev : INotifyPropertyChanged
    {
        private int id;
        private Let letDestinacija;
        private bool tipKarte;
        private DateTime datumLeta;
        private DateTime datumPovratka;
        public string sjediste;
        public string prevoznoSredstvo;
        #region
        public string PrevoznoSredstvo
        {
            get { return prevoznoSredstvo; }
            set { prevoznoSredstvo = value; OnPropertyChanged("prevoznoSredstvo"); }
        }
        public string Sjediste
        {
            get { return sjediste; }
            set { sjediste = value; OnPropertyChanged("sjediste"); }
        }
        private int Id
        {
            get { return id; }
            set {id = value; OnPropertyChanged("id"); }
        }
        public Let LetDestinacija
        {
            get { return letDestinacija; }
            set { letDestinacija = value; OnPropertyChanged("letDestinacija"); }
        }
        public bool TipKarte
        {
            get { return tipKarte; }
            set { tipKarte = value; OnPropertyChanged("tipkarte"); }
        }
        public DateTime DatumPovratka
        {

            get { return datumPovratka; }
            set {datumPovratka=value; OnPropertyChanged("datumLeta"); }
        }
        public DateTime DatumLeta
        {
            get { return datumLeta; }
            set { datumLeta=value; OnPropertyChanged("datumLeta"); }
        }
        #endregion
        public Zahtjev() { Sjediste = "1"; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
