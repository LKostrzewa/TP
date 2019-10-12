using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataContext
    {
        public List<Wykaz> wykazy = new List<Wykaz>();
        public Dictionary<string, Katalog> katalogi = new Dictionary<string, Katalog>();
        public ObservableCollection<Zdarzenie> zdarzenia = new ObservableCollection<Zdarzenie>();
        public List<OpisStanu> opisyStanu = new List<OpisStanu>();

    }
}
