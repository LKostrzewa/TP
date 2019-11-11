using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie1;

namespace Zadanie1Tests
{
    public class WypelnianieLosowe : IDataFiller
    {
        public void fill(DataContext context)
        {
            int wykazy = 10;
            int katalogi = 10;
            int opisyStanu = 100;
            int zdarzenia = 1000;
            List<int> wykazyID = RandomIds(wykazy);
            List<int> katalogiID = RandomIds(katalogi);
            List<int> opisyStanuID = RandomIds(opisyStanu);
            List<int> zdarzeniaID = RandomIds(zdarzenia);
            string pom = RandomString(10);


            for(int i = 0; i< wykazy; i++)
            {
                context.wykazy.Add(new Wykaz(wykazyID[i], RandomString(5 + i % 5), RandomString(5 + i % 5)));
            }

            for (int i = 0; i < katalogi; i++)
            {
                context.katalogi.Add(katalogiID[i], new Katalog(katalogiID[i], RandomString(5 + i % 20), RandomString(5 + i % 10), katalogiID[i]%1000));
            }

            for (int i = 0; i < opisyStanu; i++)
            {
                context.opisyStanu.Add(new OpisStanu(opisyStanuID[i], context.katalogi[katalogiID[opisyStanuID[i] % katalogi]], DateTime.Now.AddDays(-opisyStanuID[i] % 31)));
            }

            for (int i = 0; i < zdarzenia; i++)
            {
                int egz = zdarzeniaID[i] % opisyStanu;
                int czyt = zdarzeniaID[i] % wykazy;

                List<Zdarzenie> test = new List<Zdarzenie>();
                foreach (Zdarzenie z in context.zdarzenia)
                {
                    if (z.opis.id == context.opisyStanu[egz].id) test.Add(z);
                }
                test.Sort();
                if(test.Any() && test.Last() is Wypozyczenie)
                {
                    context.zdarzenia.Add(new Oddanie(zdarzeniaID[i], test.Last().wykaz, context.opisyStanu[egz]));
                }
                else
                {
                    context.zdarzenia.Add(new Wypozyczenie(zdarzeniaID[i], context.wykazy[czyt], context.opisyStanu[egz]));
                }
                
            }

        }

        private List<int> RandomIds(int ile)
        {
            List<int> list = new List<int>();
            Random rand = new Random();
            int num = rand.Next();
            list.Add(num);
            for (int i = 0; i < ile - 1; i++)
            {
                while (list.Contains(num))
                {
                    num = rand.Next();
                }
                list.Add(num);
            }
            return list;
        }

        private string RandomString(int dlugosc)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[dlugosc];
            Random random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
        }
    }
}
