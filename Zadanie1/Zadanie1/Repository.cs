﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Repository
    {
        private DataContext dane = new DataContext();
        private IDataFiller filler;

        public Repository(IDataFiller filler)
        {
            this.filler = filler;
            filler.fill(dane);
        }
    }
}
