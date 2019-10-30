using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataRepository : IData
    {
        private DataContext dane = new DataContext();

        public DataRepository(IDataFiller filler)
        {
            filler.fill(dane);
        }

        public void AddWykaz(Wykaz wykaz)
        {
            /*foreach (Wykaz w in dane.wykazy)
            {
                if (w.id.Equals(wykaz.id))
                {
                    throw new InvalidOperationException("Istnieje juz wykaz id = " + w.id);
                }
            }*/
            dane.wykazy.Add(wykaz);
        }

        public Wykaz GetWykaz(int id)
        {
            foreach (Wykaz w in dane.wykazy)
            {
                if (w.id.Equals(id))
                {
                    return w;
                }
            }
            throw new KeyNotFoundException("Nie ma wykazu o id = " + id);
        }

        public IEnumerable<Wykaz> GetAllWykaz()
        {
            return dane.wykazy;
        }

        public IEnumerable<int> GetAllWykazId()
        {
            List<int> tmp = new List<int>();
            foreach (Wykaz w in dane.wykazy)
            {
                tmp.Add(w.id);
            }
            return tmp;
        }

        public void UpdateWykaz(int id, string imie, string nazwisko)
        {
            foreach (Wykaz w in dane.wykazy)
            {
                if (w.id.Equals(id))
                {
                    w.imie = imie;
                    w.nazwisko = nazwisko;
                    return;
                }
            }
            throw new KeyNotFoundException("Nie znaleziono wykazu o id = " + id + " do zaktualizowania!");
        }

        public void DeleteWykaz(Wykaz wykaz)
        {
            /*foreach (Wykaz w in dane.wykazy)
            {
                if (w.id.Equals(wykaz.id))
                {
                    dane.wykazy.Remove(wykaz);
                    return;
                }
            }
            throw new KeyNotFoundException("Nie znaleziono wykazu " + wykaz + " do usuniecia!");*/
            dane.wykazy.Remove(wykaz);
        }

        public void AddKatalog(Katalog katalog)
        {
            dane.katalogi.Add(katalog.id, katalog);
        }

        public Katalog GetKatalog(int id)
        {
            return dane.katalogi[id];
        }

        public IEnumerable<Katalog> GetAllKatalog()
        {
            return dane.katalogi.Values;
        }

        public IEnumerable<int> GetAllKatalogId()
        {
            return dane.katalogi.Keys;
        }

        public void UpdateKatalog(int id, string tytul, string gatunek)
        {
            foreach (Katalog k in dane.katalogi.Values)
            {
                if (k.id.Equals(id))
                {
                    k.tytul = tytul;
                    k.gatunek = gatunek;
                    return;
                }
            }
            throw new KeyNotFoundException("Nie znaleziono katalogu o id " + id + " do zaktualizowania!");
        }

        public void DeleteKatalog(int id)
        {
            foreach (Katalog k in dane.katalogi.Values)
            {
                if (k.id.Equals(id))
                {
                    dane.katalogi.Remove(id);
                    return;
                }
            }
            throw new KeyNotFoundException("Nie znaleziono katalogu o id " + id + " do usuniecia!");
        }

        public void AddOpisStanu(OpisStanu opis)
        {
            /*foreach (OpisStanu o in dane.opisyStanu)
            {
                if (o.id.Equals(opis.id))
                {
                    throw new InvalidOperationException("Istnieje juz opis stanu o id = " + o.id);
                }
            }*/
            dane.opisyStanu.Add(opis);
        }

        public OpisStanu GetOpisStanu(int id)
        {
            foreach (OpisStanu o in dane.opisyStanu)
            {
                if (o.id.Equals(id))
                {
                    return o;
                }
            }
            throw new KeyNotFoundException("Nie ma opisu stanu o id = " + id);
        }

        public IEnumerable<OpisStanu> GetAllOpisStanu()
        {
            return dane.opisyStanu;
        }

        public IEnumerable<int> GetAllOpisStanuId()
        {
            List<int> tmp = new List<int>();
            foreach(OpisStanu o in dane.opisyStanu)
            {
                tmp.Add(o.id);
            }
            return tmp;
        }

        public void DeleteOpisStanu(OpisStanu opis)
        {
            /*foreach(OpisStanu o in dane.opisyStanu)
            {
                if (opis.id == o.id)
                {
                    dane.opisyStanu.Remove(opis);
                    return;
                }
            }
            throw new KeyNotFoundException("Nie znaleziono opisu stanu " + opis + " do usuniecia!");*/
            dane.opisyStanu.Remove(opis);
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            dane.zdarzenia.Add(zdarzenie);
        }

        public Zdarzenie GetZdarzenie(int id)
        {
            foreach(Zdarzenie z in dane.zdarzenia)
            {
                if(z.id == id)
                {
                    return z;
                }
            }
            throw new KeyNotFoundException("Zdarzenie miedzy takim Wykazem i OpisemStanu nie istnieje");
        }

        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return dane.zdarzenia;
        }

        public IEnumerable<int> GetAllZdarzenieId()
        {
            List<int> tmp = new List<int>();
            foreach (Zdarzenie z in dane.zdarzenia)
            {
                tmp.Add(z.id);
            }
            return tmp;
        }

        public void DeleteZdarzenie(Zdarzenie zdarzenie)
        {
            dane.zdarzenia.Remove(zdarzenie);
        }
    }
}
