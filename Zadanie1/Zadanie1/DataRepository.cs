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
            if (dane.katalogi.ContainsKey(id))
            {
                return dane.katalogi[id];
            }
            else throw new KeyNotFoundException("W repozytorium nie ma zadanego obiektu");
        }

        public IEnumerable<Katalog> GetAllKatalog()
        {
            return dane.katalogi.Values;
        }

        public void UpdateKatalog(int id, Katalog katalog)
        {
            if (dane.katalogi.ContainsKey(id))
            {
                dane.katalogi[id] = katalog;
            }
            else throw new KeyNotFoundException("W repozytorium nie ma zadanego obiektu");
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
            //return dane.opisyStanu.Find(o => o.id == id);
            return null;
        }

        public IEnumerable<OpisStanu> GetAllOpisStanu()
        {
            return dane.opisyStanu;
        }

        public void DeleteOpisStanu(OpisStanu opis)
        {
            
        }
    }
}
