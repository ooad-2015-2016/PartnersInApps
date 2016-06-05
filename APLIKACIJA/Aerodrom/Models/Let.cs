using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Aerodrom.Models
{
   public class Let : INotifyPropertyChanged
    {
        public int brojLeta;
        public DateTime datumIVrijemeLeta;
        public string destinacijaLeta;
        public string polazakLeta;
        public string polazakIOdrediste;
        public double koordinatePolaska1;
        public double koordinatePolaska2;
        public double koordinateDestinacije1;
        public double koordinateDestinacije2;
        #region Properties
        public double KoordinatePolaska1
        {
            get { return koordinatePolaska1; }
            set { koordinatePolaska1 = value; OnPropertyChanged("KoordinatePolaska1"); }
        }
        public double KoordinatePolaska2
        {
            get { return koordinatePolaska2; }
            set { koordinatePolaska2 = value; OnPropertyChanged("KoordinatePolaska2"); }
        }
        public double KoordinateDestinacije1
        {
            get { return koordinateDestinacije1; }
            set { koordinateDestinacije1 = value; OnPropertyChanged("KoordinateDestinacije1"); }
        }
        public double KoordinateDestinacije2
        {
            get { return koordinateDestinacije2; }
            set { koordinateDestinacije2 = value; OnPropertyChanged("KoordinateDestinacije2"); }
        }
        public int BrojLeta
        {
            get { return brojLeta; }
            set { brojLeta = value; OnPropertyChanged("brojLeta"); }
        }
        public DateTime DatumIVrijemeLeta
        {
            get { return datumIVrijemeLeta; }
            set { datumIVrijemeLeta = value; OnPropertyChanged("datumIVrijemeLeta"); }
        }
        public string DestinacijaLeta
        {
            get { return destinacijaLeta; }
            set { destinacijaLeta = value; OnPropertyChanged("destinacijaLeta"); }
        }
        public string PolazakLeta
        {
            get { return polazakLeta; }
            set { polazakLeta = value; OnPropertyChanged("destinacijaLeta"); }
        }
        public string PolazakIOdrediste
        {
            get { return PolazakLeta + "->" + DestinacijaLeta; }
            set {polazakIOdrediste = PolazakLeta + "->" + DestinacijaLeta; OnPropertyChanged("polazakIOdrediste"); }
        }
        #endregion
        public Let() { }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
}
}
