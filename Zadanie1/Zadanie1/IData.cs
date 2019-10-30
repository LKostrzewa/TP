using System;
using System.Collections.Generic;
namespace Zadanie1
{
    public interface IData
    {
        void AddWykaz(Wykaz wykaz);
        Wykaz GetWykaz(int id);
        IEnumerable<Wykaz> GetAllWykaz();
        IEnumerable<int> GetAllWykazId();
        void UpdateWykaz(int id, string imie, string nazwisko);
        void DeleteWykaz(Wykaz wykaz);

        void AddKatalog(Katalog katalog);
        Katalog GetKatalog(int id);
        IEnumerable<Katalog> GetAllKatalog();
        IEnumerable<int> GetAllKatalogId();
        void UpdateKatalog(int id, string tytul, string gatunek);
        void DeleteKatalog(int id);

        void AddOpisStanu(OpisStanu opis);
        OpisStanu GetOpisStanu(int id);
        IEnumerable<OpisStanu> GetAllOpisStanu();
        IEnumerable<int> GetAllOpisStanuId();
        void DeleteOpisStanu(OpisStanu opis);

        void AddZdarzenie(Zdarzenie zdarzenie);
        Zdarzenie GetZdarzenie(int id);
        IEnumerable<Zdarzenie> GetAllZdarzenie();
        IEnumerable<int> GetAllZdarzenieId();
        void DeleteZdarzenie(Zdarzenie zdarzenie);
    }
}
