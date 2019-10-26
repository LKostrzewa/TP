using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataRepository
    {
        private DataContext dane = new DataContext();

        public DataRepository(IDataFiller filler)
        {
            filler.fill(dane);
        }

        public void AddWykaz(Wykaz wykaz)
        {
            foreach (Wykaz w in dane.wykazy)
            {
                if (w.id.Equals(wykaz.id))
                {
                    throw new InvalidOperationException("Istnieje juz wykaz o takim identyfikatorze!");
                }
            }
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
            throw new KeyNotFoundException("Nie ma wykazu o id" + id);
        }

        public IEnumerable<Wykaz> GetAllWykaz()
        {
            return dane.wykazy;
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
            throw new KeyNotFoundException("Nie znaleziono wykazu o id " + id + " do zaktualizowania!");
        }

        public void DeleteWykaz(Wykaz wykaz)
        {
            foreach (Zdarzenie z in dane.zdarzenia)
            {
                if (z.wykaz.Equals(wykaz))
                {
                    throw new InvalidOperationException("Dany Wykaz jest w użyciu przez Zdarzenie, wiec nie moze zostac usuniety");
                }
            }
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

        public void UpdateKatalog(Katalog katalog)
        {
            foreach (Katalog k in dane.katalogi.Values)
            {
                if (k.id.Equals(katalog.id))
                {
                    k.tytul = katalog.tytul;
                    k.ilosc_str = katalog.ilosc_str;
                    k.gatunek = katalog.gatunek;
                    return;
                }
            }
            throw new KeyNotFoundException("Nie znaleziono katalogu o id " + katalog.id + " do zaktualizowania!");
            //zastanawiam sie czy to jest potrzebne bo moze po prostu wszystkie tego typu operacje robic przez DataService przez managera 
            //wtedy jak GetKatalog (na przyklad) nie znajdzie tego obiektu to rzuci wyjatek wiec w update nie trzeba bedzie tego sprawdzac
            //Ze wiesz w DataService zrobimy ZmienDaneKatalogu(costam) i tam bd kt = repo.GetKatalog 
        }

        public void DeleteKatalog(int id)
        {
            foreach (OpisStanu opis in dane.opisyStanu)
            {
                if (opis.katalog.Equals(GetKatalog(id)))
                {
                    throw new InvalidOperationException("Dany katalog jest w użyciu przez OpisStanu, wiec nie moze zostac usuniety");
                }
            }
            dane.katalogi.Remove(id);
        }

        public void AddOpisStanu(OpisStanu opis)
        {
            foreach (OpisStanu o in dane.opisyStanu)
            {
                if (o.id.Equals(opis.id))
                {
                    throw new InvalidOperationException("Istnieje juz opis o takim identyfikatorze!");
                }
            }
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
            throw new KeyNotFoundException("Nie ma opisu stanu o id" + id);
        }

        public IEnumerable<OpisStanu> GetAllOpisStanu()
        {
            return dane.opisyStanu;
        }

        //Nie wiem czy zostawic czy usunac
        public void UpdateOpisStanu(OpisStanu opis)
        {
            foreach(OpisStanu o in dane.opisyStanu)
            {
                if (o.id.Equals(opis.id))
                {
                    o.katalog = opis.katalog;
                    o.dataZakupu = opis.dataZakupu;
                    return;
                }
            }
            throw new KeyNotFoundException("Nie znaleziono opisu stanu o id " + opis.id + " do zaktualizowania!");
        }

        public void DeleteOpisStanu(OpisStanu opis)
        {
            foreach(Zdarzenie z in dane.zdarzenia)
            {
                if (z.opis.Equals(opis))
                {
                    throw new InvalidOperationException("Dany OpisStanu jest w użyciu przez Zdarzenie, wiec nie moze zostac usuniety");
                }
            }
            dane.opisyStanu.Remove(opis);
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            dane.zdarzenia.Add(zdarzenie);
        }

        //Nie identyfikuje nam jednoznacznie zdarzenia - moze byc duzo zdarzen o tym samym wykazie i opisie stanu
        public Zdarzenie GetZdarzenie(Wykaz wykaz, OpisStanu opisStanu)
        {
            foreach(Zdarzenie z in dane.zdarzenia)
            {
                if(z.wykaz.Equals(wykaz) && z.opis.Equals(opisStanu))
                {
                    return z;
                }
            }
            throw new InvalidOperationException("Zdarzenie miedzy takim Wykazem i OpisemStanu nie istnieje");
        }


        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return dane.zdarzenia;
        }

        //Tutaj to wgl niepotrzebne
        //public void UpdateZdarzenie(Wykaz wykaz, OpisStanu opisStanu, Zdarzenie zdarzenie)
        //{
        //    foreach (Zdarzenie z in dane.zdarzenia)
        //    {
        //        if (z.wykaz.Equals(wykaz) && z.opis.Equals(opisStanu))
        //        {
        //            dane.zdarzenia.Remove(z);
        //            dane.zdarzenia.Add(zdarzenie);
        //            return;
        //        }
        //    }
        //    throw new InvalidOperationException("Nie ma takiego obiektu w repozytorium");
        //}

        public void DeleteZdarzenie(Zdarzenie zdarzenie)
        {
            dane.zdarzenia.Remove(zdarzenie);
        }
    }
}
