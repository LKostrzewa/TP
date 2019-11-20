using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;
using Zadanie2;

namespace Aplikacja
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Reading reading = new Reading();
            ObjectIDGenerator iDGenerator = new ObjectIDGenerator();

            Console.WriteLine("Jaka czynnosc chcesz wykonac\n1) zapis do pliku\n2) odczyt z pliku");
            string type = Console.ReadLine();
            Console.WriteLine(type);
            Console.WriteLine("Podaj nazwe pliku : ");
            string path = Console.ReadLine();

            switch (type)
            {
                case "1":
                    Writing.WriteKatalogsToFile(dr.GetAllKatalog(), path + "1.txt", iDGenerator);
                    Writing.WriteOpisStanusToFile(dr.GetAllOpisStanu(), path + "2.txt", iDGenerator);
                    Writing.WriteWykazsToFile(dr.GetAllWykaz(), path + "3.txt", iDGenerator);
                    Writing.WriteZdarzeniesToFile(dr.GetAllZdarzenie(), path + "4.txt", iDGenerator);
                    break;
                case "2":
                    List<Katalog> katalogs = (List<Katalog>)reading.ReadKatalogsFromFile(path + "1.txt");
                    List<OpisStanu> opisStanus = (List<OpisStanu>)reading.ReadOpisStanusFromFile(path + "2.txt");
                    List<Wykaz> wykazs = (List<Wykaz>)reading.ReadWykazsFromFile(path + "3.txt");
                    List<Zdarzenie> zdarzenies = (List<Zdarzenie>)reading.ReadZdarzeniesFromFile(path + "4.txt");
                    DataContext dc = new DataContext
                    {
                        opisyStanu = opisStanus,
                        wykazy = wykazs,
                        zdarzenia = new ObservableCollection<Zdarzenie>(zdarzenies),
                        katalogi = katalogs.ToDictionary(k => k.id, k => k)
                    };
                    dr.SetDataContext(dc);
                    break;
            }
        }
    }
}
