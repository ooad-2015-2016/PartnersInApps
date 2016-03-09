# PartnersInApps
## Sistem za rezervaciju i kupovinu avionske karte
Članovi tima:

1.Azemina Ahmedhodžić  
2.Elvis Kundo  
3.Ahmed Ahmedić  
4.Amina Alijagić  

### Opis Teme:

Sa porastom korisnika avio prijevoza, javlja se i potreba za boljom organizacijom aerodromskih kapaciteta i osoblja kao i za naprednim mjerama predostrožnosti i kontrole putnika. Također, neophodna je i modernizacija usluge kako bi se išlo u korak sa vremenom i standardima koje su postavili najveći svjetski aerodromi. Da bi se to ostvarilo, potrebna je aplikacija koja će istovremeno biti efikasna a jednostavna za korištenje. 
Cilj je da se pronađe najbolje rješenje za proces kupovine i rezervacije mjesta u avionu (što podrazumijeva i provjeru ispravnosti pasoša/vize i prtljaga), u cilju olakšavanja komunikacije između naših putnika i osoblja, i brzog i potpunog ispunjenja zahtjeva putnika.

### Procesi:

 Pristupa se kupovini karte, lično ili putem interneta. **(Putnik -> Službenik)**  
 Bira se destinacija, tip karte (povratna ili u jednom pravcu), i datum leta (i povratka u slučaju povratne karte). 
**(Putnik -> Službenik)**  
 Procesuiranje zahtjeva, provjerava se da li ima slobodnih letova, i prikazuju se termini za slobodne letove (i termine povratka u  slučaju povratne karte). **(Službenik -> Putnik)**  
 Bira se termin leta. **(Putnik -> Službenik)**  
 Provjerava se da li je let popunjen.  **(Službenik -> Putnik)**  
 Ako jeste, bira se ponovo termin leta. **(Putnik -> Službenik)**  
 Ako nije, bira se klasa (ako je dostupna u avionu) i sjedište. Unose se lični podaci putnika (ime i prezime, datum rođenja, JMBG, broj telefona, email, broj pasoša/vize...). **(Putnik -> Službenik)**  
 Provjerava se ispravnost pasoša/vize i ostalih ličnih podataka. **(Službenik -> Supervizor)**  
 Ukoliko su podaci neispravni, šalje se zahtjev putniku da ispravi greške. **(Službenik -> Putnik)**  
 Ukoliko se utvrdi da se radi o sumnjivom licu, aktivira se tihi alarm koji poziva osiguranje. 
**(Sistem -> Službenik, Osiguranje)**  
 Ako su podaci ispravni, nudi se i dodatna opcija automatskog iznajmljivanja automobila na odredištu ili mogućnost da putnika na aerodromu dočeka osoblje iz rezervisanog hotela. **(Službenik -> Putnik)**  
 Ako putnik odabere neku od opcija, hotelu/rent-a-car agenciji se šalju podaci o putniku. **(Sistem -> Sistem hotela/rent-a-car agencije)**  
 Nude se dva načina plaćanja: gotovinsko ili kreditnom karticom. Obračunavaju se popusti zavisno od vremena rezervacije, i ukoliko putnik posjeduje Membership karticu (tj. ako putnik često koristi usluge ove kompanije). **(Službenik -> Putnik)**  
 Bira se način plaćanja. Ukoliko se plaćanje vrši kreditnom karticom, putnik daje broj kreditne kartice (ili karticu ako kartu kupuje na aerodromu). **(Putnik -> Službenik)**  
 Ako putnik plaća preko interneta, na email se šalje ugovor koji je potrebno priložiti prilikom preuzimanja karte. **(Službenik -> Putnik)**  
 Osim kupovine, postoji i mogućnost izmjene leta. U odgovarajuće polje upisuje se serijski broj karte i putnik bira da li želi promijeniti termin leta ili otkazati let. **(Putnik -> Službenik)**  
 Procesuira se zahtjev za promjenu karte. **(Supervizor -> Putnik)**  
 Ukoliko je odobrena promjena termina, određuje se iznos doplate za istu. **(Supervizor -> Putnik)**   
 Ukoliko nije odobrena promjena (zbog popunjenosti leta), bira se novi termin.  **(Putnik -> Supervizor)**  
 Ako putnik otkazuje rezervisani let, vraća mu se samo dio novca. **(Supervizor -> Putnik)**  

 Prije polijetanja, vrši se kontrola prtljaga. **(Osiguranje -> Putnik)**  
 Ako je prtljag teži od dozvoljenog, potrebna je doplata. **(Putnik -> Službenik)**  
 Ukoliko se u prtljagu nalazi sumnjivi predmet (npr. oružje), putnik se izdvaja zbog ispitivanja. **(Osiguranje -> Putnik)**  
 Ukoliko se u prtljagu nalazi predmet koji nije dozvoljeno unijeti u avion, isti se oduzima. **(Osiguranje -> Putnik)**  

### Funkcionalnosti:

Desktop aplikacija za aerodrom:
-	Modul za unos željene destinacije 
-	Modul za odabir tipa karte: povratna ili u jednom smjeru
-	Modul za odabir datuma i termina letenja
-	Modul za odabir klase
-	Modul za prikaz i odabira sjedišta u avionu
-	Modul za unos ličnih podataka
-	Modul za odabir dodatnih opcija
-	Modul za automatsko slanje informacija o letu putnika hotelu/rent-a-car agenciji
-	Modul za automatsko plaćanje
-	Modul za slanje tihog alarma u slučaju prisutnosti sumnjivog lica
-	Modul za promjenu leta 
-	Modul za otkazivanje leta
-	Modul za obračun iznosa doplate u slučaju promjene termina/otkazivanja leta 
-	Modul za detektovanje sumnjivih i nedozvoljenih predmeta u prtljagu
-	Modul za obračun iznosa doplate u slučaju da je prtljag teži od dozvoljenog

### Akteri:

 **Putnik** – osoba koja predaje zahtjev za avionsku kartu.  
 **Službenik** - osoba koja je u komunikaciji s putnicima i daje sve informacije vezane za let.  
 **Supervizor** –osoba koja provjerava ispravnost ličnih podatke putnika i odobrava zahtjev za izmjenu karte.  
 **Osiguranje** – osoba koja privodi sumnjivo lice i putnike koji posjeduju nedozvoljene predmete u prtljagu.  

