using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public interface IData
    {
        void AddWykaz(Wykaz wykaz);
        Wykaz GetWykaz(int id);
        IEnumerable<Wykaz> GetAllWykaz();
        void UpdateWykaz(int id, string imie, string nazwisko);
        void DeleteWykaz(Wykaz wykaz);

        void AddKatalog(Katalog katalog);
        Katalog GetKatalog(int id);
        IEnumerable<Katalog> GetAllKatalog();
        IEnumerable<int> GetAllKatalogId();
        void UpdateKatalog(Katalog katalog);
        void DeleteKatalog(int id);

        void AddOpisStanu(OpisStanu opis);
        OpisStanu GetOpisStanu(int id);
        IEnumerable<OpisStanu> GetAllOpisStanu();
        IEnumerable<int> GetAllOpisStanuId()
        void DeleteOpisStanu(OpisStanu opis);

        void AddZdarzenie(Zdarzenie zdarzenie);
        Zdarzenie GetZdarzenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dateTime);
        IEnumerable<Zdarzenie> GetAllZdarzenie();
        void DeleteZdarzenie(Zdarzenie zdarzenie);
    }
}
