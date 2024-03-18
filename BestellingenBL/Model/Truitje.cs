using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestellingenBL.Model
{
    public class Truitje
    {
        public Truitje(string competitie, string ploeg, string set, Maat maat, string seizoen,double prijs)
        {
            Competitie = competitie;
            Ploeg = ploeg;
            Set = set;
            Maat = maat;
            Seizoen = seizoen;
            Prijs = Prijs;
        }

        public int? Id { get; set; }
        public string Competitie { get; set; }
        public string Ploeg {  get; set; }
        public string Set {  get; set; }
        public Maat Maat { get; set; }
        public string Seizoen {  get; set; }
        public double Prijs { get; set; }
    }
}
