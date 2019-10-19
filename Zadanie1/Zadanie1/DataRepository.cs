﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataRepository
    {
        private DataContext dane = new DataContext();
        private IDataFiller filler;

        public DataRepository(IDataFiller filler)
        {
            this.filler = filler;
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
            return dane.katalogi[id];
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
        }

        public void DeleteKatalog(Katalog katalog)
        {

        }

        public void AddOpisStanu(OpisStanu opis)
        {
            dane.opisyStanu.Add(opis);
        }


    }
}
