using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Zadanie1
{
    public class DataService
    {
        private IData repository;

        public DataService(IData repository)
        {
            this.repository = repository;
        }

        public void DodajKsiazkeDoBiblioteki(string tytul, string gatunek, int ilosc_stron)
        {
            int idK = 0;
            int idO = 0;
            while (repository.GetAllKatalogId().Contains(idK))
            {
                idK++;
            }
            while (repository.GetAllOpisStanuId().Contains(idO))
            {
                idO++;
            }
            foreach(Katalog k in repository.GetAllKatalog())
            {
                if (k.tytul.Equals(tytul) && k.gatunek.Equals(gatunek) && k.ilosc_str.Equals(ilosc_stron))
                {
                    repository.AddOpisStanu(new OpisStanu(idO, k, DateTime.Now));
                    return;
                }
            }
            repository.AddKatalog(new Katalog(idK, tytul, gatunek, ilosc_stron));
            repository.AddOpisStanu(new OpisStanu(idO, repository.GetKatalog(idK), DateTime.Now));
        }

        public Katalog PobierzKsiazke(int id)
        {
            return repository.GetKatalog(id);
        }

        public OpisStanu PobierzEgzemplarz(int id)
        {
            return repository.GetOpisStanu(id);
        }

        public void UsunEgzemplarzZBiblioteki(int idO)
        {
            OpisStanu o = repository.GetOpisStanu(idO);
            foreach(Zdarzenie z in repository.GetAllZdarzenie())
            {
                if (z.opis.id == idO)
                {
                    throw new InvalidOperationException("Dany OpisStanu jest w użyciu przez Zdarzenie, wiec nie moze zostac usuniety");
                }
            }
            repository.DeleteOpisStanu(o);
        }

        public void UsunKsiazkeZBiblioteki(int id)
        {            
            Katalog k = repository.GetKatalog(id);
            foreach (OpisStanu opis in repository.GetAllOpisStanu())
            {
                if (opis.katalog.id == k.id)
                {
                    throw new InvalidOperationException("Dany katalog jest w użyciu przez OpisStanu, wiec nie moze zostac usuniety");
                }
            }
            repository.DeleteKatalog(k.id);
        }

        public IEnumerable<OpisStanu> PobierzWszystkieEgzemplarze()
        {
            return repository.GetAllOpisStanu();
        }

        public IEnumerable<Katalog> PobierzWszystkieKsiazki()
        {
            return repository.GetAllKatalog();
        }

        public void DodajKlientaDoBiblioteki(string imie, string nazwisko)
        {
            int id = 0;
            while (repository.GetAllWykazId().Contains(id))
            {
                id++;
            }
            repository.AddWykaz(new Wykaz(id, imie, nazwisko));
        }

        public void UsunKlientaZBiblioteki(int id)
        {
            // usuwanie klienta gdy nie ma wypozyczonej zadnej ksiazki
            foreach(Zdarzenie z in repository.GetAllZdarzenie())
            {
                if (z.wykaz.id.Equals(id))
                {
                    throw new InvalidOperationException("Klient o imienu " + z.wykaz.imie + " " + z.wykaz.nazwisko + " ma wypozyczenia!");
                }
            }
            repository.DeleteWykaz(repository.GetWykaz(id));
        }

        public IEnumerable<Wykaz> PobierzWszystkichKlientow()
        {
            return repository.GetAllWykaz();
        }

        public Wykaz PobierzKlienta(int id)
        {
            return repository.GetWykaz(id);
        }

        public void WypozyczKsiazke(int idW, int idO)
        {
            int id = 0;
            while (repository.GetAllZdarzenieId().Contains(id))
            {
                id++;
            }
            IEnumerable<Zdarzenie> list = WszystkieZdarzeniaDlaKsiazki(idO);
            if (list.Any() && list.Last() is Wypozyczenie)
            {
                throw new InvalidOperationException("Ta ksiazka jest aktualnie niedostepna");
            }
            repository.AddZdarzenie(new Wypozyczenie(id, repository.GetWykaz(idW), repository.GetOpisStanu(idO)));
        }

        public void OddajKsiazke(int idW, int idO)
        {
            int id = 0;
            while (repository.GetAllZdarzenieId().Contains(id))
            {
                id++;
            }
            IEnumerable<Zdarzenie> list = WszystkieZdarzeniaDlaKsiazki(idO);
            Zdarzenie z = list.Last();
            if (z is Wypozyczenie)
            {
                repository.AddZdarzenie(new Oddanie(id, repository.GetWykaz(idW), repository.GetOpisStanu(idO)));
            }
            else throw new InvalidOperationException("Ta ksiazka nie jest aktualnie wypozyczona");
        }

        public void UsunZdarzenieZBiblioteki(int id)
        {
            repository.DeleteZdarzenie(repository.GetZdarzenie(id));
        }

        public IEnumerable<Zdarzenie> WszystkieZdarzeniaDlaKsiazki(int idO)
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
        
        public string WyswietlWykazy(IEnumerable<Wykaz> listaWykaz)
        {
            string tmp = "";
            foreach (Wykaz w in listaWykaz)
            {
                tmp += w.ToString() + "\n";
            }
            return tmp;
        }

        public string WyswietlKatalogi(IEnumerable<Katalog> listaKatalog)
        {
            string tmp = "";
            foreach (Katalog k in listaKatalog)
            {
                tmp += k.ToString() + "\n" ;
            }
            return tmp;
        }

        public string WyswietlOpisy(IEnumerable<OpisStanu> listaOpisStanu)
        {
            string tmp = "";
            foreach (OpisStanu o in listaOpisStanu)
            {
                tmp += o.ToString() + "\n";
            }
            return tmp;
        }
        public string WyswietlZdarzenia(IEnumerable<Zdarzenie> listaZdarzen)
        {
            string tmp = "";
            foreach (Zdarzenie z in listaZdarzen)
            {
                tmp += z.ToString() + "\n";
            }
            return tmp;
        }

        public string WyswietlDaneDlaKlientow(IEnumerable<Wykaz> listaWykaz)
        {
            string tmp = "";
            foreach(Wykaz w in listaWykaz)
            {
                tmp += w.ToString() + "\n";
                foreach(Zdarzenie z in WszystkieZdarzeniaDlaKlienta(w.id))
                {
                    tmp += "\t" + z.ToString() + "\n";
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
