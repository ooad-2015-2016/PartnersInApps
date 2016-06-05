using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Aerodrom.Models
{
    class PrevoznoSredstvo : INotifyPropertyChanged 
    {
        private int brojSjedista;
        private int brojZauzetihSjedista;
        private bool popunjenost;
        private List<Kupac> listaPutnika;
        private List<int> zauzetaMjesta;
        private List<string> prevoznaSredstva;
        #region
        public List<string> PrevoznaSredstva
        {
            get { return prevoznaSredstva; }
            set { prevoznaSredstva = value; OnPropertyChanged("prevoznaSredstva"); }
        }
        public List<int> ZauzetaMjesta
        {
            get { return zauzetaMjesta; }
            set {zauzetaMjesta = value; OnPropertyChanged("brojZauzetihSjedista"); }
        }
        public int BrojZauzetihSjedista
        {
            get { return brojZauzetihSjedista; }
            set { brojZauzetihSjedista = value; OnPropertyChanged("brojZauzetihSjedista"); }
        }
        public List<Kupac> ListaPutnika
        {
            get { return listaPutnika; }
            set { listaPutnika = value; OnPropertyChanged("listaPutnika"); }
        }
        public bool Popunjenost
        {
            get { return BrojZauzetihSjedista>=BrojSjedista; }
            set { popunjenost = value; OnPropertyChanged("popunjenost"); }
        }
        public int BrojSjedista
        {
            get { return brojSjedista; }
            set { brojSjedista = value; OnPropertyChanged("brojSjedista"); }
        }
        #endregion
        public void dodajKupce()
        {
            ListaPutnika = new List<Kupac>();
            ListaPutnika.Add(
                new Kupac()
                {
                    Ime = "Elvis",
                    Prezime = "Kundo",
                    BrojTelefona = "062-124-343",
                    DatumRodjenja = "12.04.1996",
                    MembershipCard = true,
                    DatumKupovine = DateTime.Now,
                    BrojKarteLeta = "12j1j3nk1onn31pokw",
                    Let = new Let()
                    {
                        BrojLeta = 1,
                        DestinacijaLeta = "London",
                        PolazakLeta = "Sarajevo",
                        DatumIVrijemeLeta = new DateTime(2017, 5, 1, 8, 30, 52)
                    }
                     ,
                    DatumLeta = DateTime.Now,
        Sjediste=2
    }
                    );
            ListaPutnika.Add(
                new Kupac()
                {
                    Ime = "Azemina",
                    Prezime = "Ahmedhodzic",
                    BrojTelefona = "062-211-222",
                    DatumRodjenja = "14.08.1995",
                    MembershipCard = false,
                    DatumKupovine = DateTime.Now,
                    BrojKarteLeta = "12j1j3nkasan31pokw",
                    Let = new Let()
                    {
                        BrojLeta = 1,
                        DestinacijaLeta = "London",
                        PolazakLeta = "Sarajevo",
                        DatumIVrijemeLeta = new DateTime(2017, 5, 1, 8, 30, 52)
                    } ,
                    DatumLeta = DateTime.Now,
                    Sjediste = 4
                }
                    );
            BrojZauzetihSjedista = listaPutnika.Count();
            ZauzetaMjesta = new List<int>();
            ZauzetaMjesta.Add(listaPutnika[0].Sjediste);
            ZauzetaMjesta.Add(listaPutnika[1].Sjediste);
        }
        public PrevoznoSredstvo() {
            BrojSjedista = 9;
            Popunjenost = false;
            BrojZauzetihSjedista = 0;
            PrevoznaSredstva = new List<string>();
            PrevoznaSredstva.Add("Avion");
            PrevoznaSredstva.Add("Helikopter");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }

}

