using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class WypelnianieLosowe : IDataFiller
    {
        public void fill(DataContext context)
        {
            List<int> ids = RandomIds();
            
        }

        private List<int> RandomIds()
        {
            List<int> list = new List<int>();
            Random rand = new Random();
            int num = rand.Next();
            list.Add(num);
            for (int i = 0; i < 2; i++)
            {
                while (list.Contains(num))
                {
                    num = rand.Next();
                }
                list.Add(num);
            }
            return list;
        }

        private string RandomString()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[8];
            Random random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
        }
    }
}
