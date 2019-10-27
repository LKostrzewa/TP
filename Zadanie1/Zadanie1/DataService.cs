using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataService
    {

        //tutaj bedzie interfejs na zasadzie DI ale po finalnym ustaleniu postaci DataRepository

        private DataRepository repository;

        public DataService(DataRepository repository)
        {
            this.repository = repository;
        }

        public void DodajKsiazkeDoBiblioteki(string tytul, string gatunek, int ilosc_stron)
        {
            foreach(Katalog k in repository.GetAllKatalog())
            {
                if (k.tytul.Equals(tytul) && k.gatunek.Equals(gatunek) && k.ilosc_str.Equals(ilosc_stron))
                {
                    repository.AddOpisStanu(new OpisStanu(repository.GetAllOpisStanu().Count() + 1, k, DateTime.Now));
                    return;
                }
            }
            repository.AddKatalog(new Katalog(repository.GetAllKatalog().Count() + 1, tytul, gatunek, ilosc_stron));
            repository.AddOpisStanu(new OpisStanu(repository.GetAllOpisStanu().Count() + 1, repository.GetKatalog(repository.GetAllKatalog().Count()), DateTime.Now));
        }

        public void DodajKlientaDoBiblioteki(string imie, string nazwisko)
        {
            foreach(Wykaz w in repository.GetAllWykaz())
            {
                if(w.imie.Equals(imie) && w.nazwisko.Equals(nazwisko))
                {
                    throw new InvalidOperationException("Klient o imienu " + imie + " " + nazwisko + " znajduje juz sie w bazie klientow");
                }
            }
            repository.AddWykaz(new Wykaz(repository.GetAllWykaz().Count(), imie, nazwisko));
        }

        public void WypozyczKsiazke(int idW, int idO)
        {
            //OpisStanu opis = new OpisStanu(idO, repository.GetKatalog(idK), DateTime.Now);
            IEnumerable<Zdarzenie> list = WszystkieWydarzeniaDlaKsiazki(idO);
            Zdarzenie z = list.Last();
            if(z is Wypozyczenie)
            {
                throw new InvalidOperationException("Ta ksiazka jest aktualnie niedostepna");
            }
            else repository.AddZdarzenie(new Wypozyczenie(repository.GetWykaz(idW), repository.GetOpisStanu(idO)));
        }

        public void OddajKsiazke(int idW, int idO)
        {
            IEnumerable<Zdarzenie> list = WszystkieWydarzeniaDlaKsiazki(idO);
            Zdarzenie z = list.Last();
            if (z is Wypozyczenie)
            {
                repository.AddZdarzenie(new Oddanie(repository.GetWykaz(idW), repository.GetOpisStanu(idO)));
            }
            else throw new InvalidOperationException("Ta ksiazka nie jest aktualnie wypozyczona");
        }

        public IEnumerable<Zdarzenie> WszystkieWydarzeniaDlaKsiazki(int idO)
        {
            List<Zdarzenie> test = new List<Zdarzenie>();
            foreach(Zdarzenie z in repository.GetAllZdarzenie())
            {
                if (z.opis.id == idO) test.Add(z);
            }
            test.Sort();
            return test;
        }

        public IEnumerable<Zdarzenie> WszystkieZdarzeniaDlaKlienta(int idW)
        {
            List<Zdarzenie> test = new List<Zdarzenie>();
            foreach(Zdarzenie z in repository.GetAllZdarzenie())
            {
                if (z.wykaz.id == idW) test.Add(z);
            }
            return test;
        }

        public IEnumerable<Zdarzenie> WszystkieZdarzeniaWCzasie(DateTime start, DateTime end)
        {
            List<Zdarzenie> test = new List<Zdarzenie>();
            foreach(Zdarzenie z in repository.GetAllZdarzenie())
            {
                if (z.data <= end && z.data >= start) test.Add(z); 
            }
            return test;
        }

        //To padaka jest nie patrz nawet xd
        public String WszystkieDaneDlaKlientow(IEnumerable<Wykaz> listaWykaz)
        {
            String tmp = "";
            foreach(Wykaz w in listaWykaz)
            {
                tmp += w.ToString() + "/n";
                foreach(Zdarzenie z in WszystkieZdarzeniaDlaKlienta(w.id))
                {
                    tmp += "/t" + z.ToString() + "/n";
                    foreach(Katalog k in repository.GetAllKatalog())
                    {
                        if (k.id.Equals(z.opis.katalog.id))
                        {
                            tmp += "/t/t" + k.ToString() + "/n";
                        }
                    }
                }
            }
            return tmp;
        }

        private static void ZdarzenieChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    //tutaj printowanie na ekran - lol może tak ma być, że ta klasa może printować?
                    break;
                case NotifyCollectionChangedAction.Remove:
                    // tutaj to samo?
                    break;
                default:
                    //nw co tu
                    break;
            }
        }

    }
}
