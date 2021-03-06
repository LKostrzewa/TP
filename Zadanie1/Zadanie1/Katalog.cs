﻿using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Zadanie1
{
    public class Katalog
    {
        public int id { get; private set; }
        public string tytul { get; set; }
        public string gatunek { get; set; }
        public int ilosc_str { get; set; }

        public Katalog(int id, string tytul, string gatunek, int ilosc_str)
        {
            this.id = id;
            this.tytul = tytul;
            this.gatunek = gatunek;
            this.ilosc_str = ilosc_str;
        }

        public override bool Equals(object obj)
        {
            Katalog katalog = obj as Katalog;
            return katalog != null &&
                   id == katalog.id &&
                   tytul == katalog.tytul &&
                   gatunek == katalog.gatunek &&
                   ilosc_str == katalog.ilosc_str;
        }

        public override string ToString()
        {
            return "Tytul - " + tytul
                    + " Gatunek - " + gatunek
                    + " ilosc stron - " + ilosc_str
                    + " ID - " + id;
        }
    }
}
