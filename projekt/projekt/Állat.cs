using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    class Állat
    {
        public string nev;
        public int érték;
        public int védetté_tették;
        public string típus;
        public Állat(string s)
        {
            string[] sor = s.Split(';');
            nev = sor[0];
            érték = int.Parse(sor[1]);
            védetté_tették = int.Parse(sor[2]);
            típus = sor[3];
        }
    }
}
