using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataRepository
    {
        private DataContext dane = new DataContext();
        //private IDataFiller filler;

        public DataRepository(IDataFiller filler)
        {
            //this.filler = filler;
            filler.fill(dane);
        }

        public void AddWykaz(Wykaz wykaz)
        {
            dane.wykazy.Add(wykaz);
        }

        //dalsze crud do wykazu tutaj

        public void AddKatalog(Katalog katalog)
        {
            dane.katalogi.Add(katalog.id, katalog);
        }

        public Katalog GetKatalog(int id)
        {
            //if (dane.katalogi.ContainsKey(id))
            //{
                return dane.katalogi[id];
            //}
           // else throw new KeyNotFoundException("W repozytorium nie ma zadanego obiektu");
        }

        public IEnumerable<Katalog> GetAllKatalog()
        {
            return dane.katalogi.Values;
        }

        //moze bedzie potrzebne moze nie 
        public IEnumerable<int> GetAllKatalogId()
        {
            return dane.katalogi.Keys;
        }

        public void UpdateKatalog(int id, Katalog katalog)
        {
            //if (dane.katalogi.ContainsKey(id))
            //{
                dane.katalogi.Remove(id);
                dane.katalogi.Add(katalog.id, katalog);
            //}
            //else throw new KeyNotFoundException("W repozytorium nie ma zadanego obiektu");
            //sprawdzanie poprawnosci danych zostanie przeniesione w przyszlosci do DataService
        }

        public void DeleteKatalog(Katalog katalog)
        {
            if(dane.opisyStanu.Exists(o => o.katalog.Equals(katalog)))
            {
                throw new InvalidOperationException("Dany katalog jest w użyciu przez OpisStanu, wiec nie moze zostac usuniety");
            }
            dane.katalogi.Remove(katalog.id);
        }

        public void AddOpisStanu(OpisStanu opis)
        {
            dane.opisyStanu.Add(opis);
        }

        public OpisStanu GetOpisStanu(int id)
        {
            return dane.opisyStanu.Find(o => o.id == id);
        }

        public IEnumerable<OpisStanu> GetAllOpisStanu()
        {
            return dane.opisyStanu;
        }

        //analogicznie do Katalog
        public IEnumerable<int> GetAllOpisStanuId()
        {
            List<int> list = new List<int>();
            foreach(OpisStanu o in dane.opisyStanu)
            {
                list.Add(o.id);
            }
            return list;
        }

        public void UpdateOpisStanu(int id, OpisStanu opis)
        {
            int index = dane.opisyStanu.FindIndex(o => o.id == id);
            if (index >= 0)
            {
                dane.opisyStanu[index] = opis;
            }
            else throw new InvalidOperationException("Nie ma takiego obiektu w repozytorium");
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
    }
}
