using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Aerodrom.Models
{
    public class PodaciODestinaciji : INotifyPropertyChanged
    {
        public List<Let> destinacije;
        #region Properties
        public List<Let> Destinacije
        {
            get { return destinacije; }
            set { destinacije = value; OnPropertyChanged("destinacija"); }
        }
        #endregion
        public void dodajLetove()
        {
            destinacije = new List<Let>();
            destinacije.Add(
                new Let()
                {
                    BrojLeta = 1,
                    DestinacijaLeta = "London",
                    PolazakLeta = "Sarajevo",
                    DatumIVrijemeLeta = new DateTime(2017, 5, 1, 8, 30, 52),
                    KoordinatePolaska1= 43.8620,
                    KoordinatePolaska2= 18.3936,
                    KoordinateDestinacije1 = 51.5,
                    KoordinateDestinacije2=-0.129
                }
                    );
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
