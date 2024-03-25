using BestellingenBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Prijs = prijs;
        }

        public int? Id { get; set; }
        public string Competitie { get; set; }
        private string ploeg;
        public string Ploeg {
            get { return ploeg; }
            set { if (string.IsNullOrWhiteSpace(value) 
                    || (value.Trim().Length<4)) 
                    throw new BestellingException("SetPloeg"); ploeg = value; } }
        public string Set {  get; set; }
        public Maat Maat { get; set; }
        private string seizoen;
        public string Seizoen {
            get { return seizoen; }
            set { if (string.IsNullOrEmpty(value) || !IsValidSeizoen(value))
                    throw new BestellingException("SetSeizoen"); seizoen = value; } }
        private double prijs;
        public double Prijs
        {
            get { return prijs; }
            set { if (value < 0) throw new BestellingException("SetPrijs"); prijs = value; }
        }
        private bool IsValidSeizoen(string seizoen)
        {
            if (!Regex.IsMatch(seizoen, @"^\d{4}-\d{4}$")) return false;
            int jaar1 = Int32.Parse(Regex.Match(seizoen, @"^\d{4}").Value);
            int jaar2 = Int32.Parse(Regex.Match(seizoen, @"\d{4}$").Value);
            if (jaar2 - jaar1 == 1) return true; else return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Truitje)
            {
                Truitje compTruitje = (Truitje)obj;
                if (Id.HasValue && compTruitje.Id.HasValue)
                {
                    if (Id== compTruitje.Id) return true;
                    else return false;
                }
                else
                {
                    return Competitie == compTruitje.Competitie &&
                   Ploeg == compTruitje.Ploeg &&
                   Set == compTruitje.Set &&
                   Maat == compTruitje.Maat &&
                   Seizoen == compTruitje.Seizoen &&
                   Prijs == compTruitje.Prijs;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Competitie, Ploeg, Set, Maat, Seizoen, Prijs);
        }
    }
}
