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
            Console.WriteLine("Jaka czynnosc chcesz wykonac\n1) zapis do pliku (txt)\n2) odczyt z pliku (txt)\n3) zapis do pliku (json)\n4) odczyt z pliku (json)\n\nKazdy inny znak zakonczy dzialanie programu");
            string type = Console.ReadLine();
            Console.WriteLine(type);
            while (type == "1" | type == "2" | type == "3" | type == "4")
            {
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
                    case "3":
                        Writing.WriteCollectionToJSON<Katalog>(dr.GetAllKatalog(), path + "1.json");
                        Writing.WriteCollectionToJSON<OpisStanu>(dr.GetAllOpisStanu(), path + "2.json");
                        Writing.WriteCollectionToJSON<Wykaz>(dr.GetAllWykaz(), path + "3.json");
                        Writing.WriteCollectionToJSON<Zdarzenie>(dr.GetAllZdarzenie(), path + "4.json");
                        //Writing.WriteObjectToJSON(dr.GetDataContext(), path + ".json");
                        break;
                    case "4":
                        List<Katalog> katalogsJSON = (List<Katalog>)Reading.ReadCollectionFromJSON<Katalog>(path + "1.json");
                        List<OpisStanu> opisStanusJSON = (List<OpisStanu>)Reading.ReadCollectionFromJSON<OpisStanu>(path + "2.json");
                        List<Wykaz> wykazsJSON = (List<Wykaz>)Reading.ReadCollectionFromJSON<Wykaz>(path + "3.json");
                        List<Zdarzenie> zdarzeniesJSON = (List<Zdarzenie>)Reading.ReadCollectionFromJSON<Zdarzenie>(path + "4.json");
                        DataContext dcJSON = new DataContext
                        {
                            opisyStanu = opisStanusJSON,
                            wykazy = wykazsJSON,
                            zdarzenia = new ObservableCollection<Zdarzenie>(zdarzeniesJSON),
                            katalogi = katalogsJSON.ToDictionary(k => k.id, k => k)
                        };
                        dr.SetDataContext(dcJSON);
                        //dr.SetDataContext(Reading.ReadObjectFromJSON<DataContext>(path + ".json"));
                        break;
                }
                Console.WriteLine("Jaka czynnosc chcesz wykonac\n1) zapis do pliku (txt)\n2) odczyt z pliku (txt)\n3) zapis do pliku (json)\n4) odczyt z pliku (json)\n\nKazdy inny znak zakonczy dzialanie programu");
                type = Console.ReadLine();
                Console.WriteLine(type);
            }
        }
    }
}
