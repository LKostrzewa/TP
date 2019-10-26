using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void DodajKsiazkeDoBiblioteki(int id, string tytul, string gatunek, int ilosc_stron)
        {
            repository.AddKatalog(new Katalog(id, tytul, gatunek, ilosc_stron));
            //prototyp
        }

        public void DodajKlientaDoBiblioteki(int id, string imie, string nazwisko)
        {
            repository.AddWykaz(new Wykaz(id, imie, nazwisko));
            //rowniez prototyp
        }

        public void WypozyczKsiazke(int idK, int idW, int idO)
        {
            OpisStanu opis = new OpisStanu(idO, repository.GetKatalog(idK), DateTime.Now);
            List<Zdarzenie> list = WszystkieWydarzeniaDlaKsiazki(idK);
            Zdarzenie z = list[list.Count - 1];
            if(z is Wypozyczenie)
            {
                throw new InvalidOperationException("Ta ksiazka jest aktualnie niedostepna");
            }
            else repository.AddZdarzenie(new Wypozyczenie(repository.GetWykaz(idW), opis));
        }

        public void OddajKsiazke(int idO, int idW)
        {
           
            List<Zdarzenie> list = WszystkieWydarzeniaDlaKsiazki(repository.GetOpisStanu(idO).id);
            Zdarzenie z = list[list.Count - 1];
            if (z is Wypozyczenie)
            {
                repository.AddZdarzenie(new Oddanie(repository.GetWykaz(idW), repository.GetOpisStanu(idO)));
            }
            else throw new InvalidOperationException("Ta ksiazka nie jest aktualnie wypozyczona");
        }

        //tu jest list bo chcialem testowac cos na kocu moze byc IEnumerable
        public List<Zdarzenie> WszystkieWydarzeniaDlaKsiazki(int idK)
        {
            List<Zdarzenie> test = new List<Zdarzenie>();
            foreach(Zdarzenie z in repository.GetAllZdarzenie())
            {
                if (z.opis.katalog.id == idK) test.Add(z);
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

    }
}
