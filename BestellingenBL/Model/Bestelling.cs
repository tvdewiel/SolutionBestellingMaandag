using BestellingenBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestellingenBL.Model
{
    public class Bestelling
    {
        public Bestelling(DateTime datum)
        {
            Datum = datum;
            IsBetaald = false;
        }

        public int? Id { get; set; }
        public DateTime Datum { get; set; }
        public bool IsBetaald { get; private set; }
        public double? AfgerekendePrijs { get;private set; }
        private Klant klant;
        public Klant Klant { 
            get { return klant; } 
            set { 
                if ((value != null) && (value!=klant)){
                    if (klant != null && klant.HeeftBestelling(this))
                    {
                        klant.VerwijderBestelling(this);
                    }
                    klant = value;
                    if (!klant.HeeftBestelling(this))
                        klant.VoegBestellingToe(this);
                }
            } }
        public Dictionary<Truitje, int> Truitjes { get; set; } = new();
        public void RekenAf()
        {
            IsBetaald = true;
            AfgerekendePrijs = Prijs();
        }
        private double Prijs()
        {
            double prijs = 0.0;
            foreach(var item in Truitjes)
            {
                prijs += (item.Key.Prijs * item.Value);
            }
            prijs -= prijs * Klant.Korting()/100.0;
            return prijs;
        }
        public void VoegTruitjeToe(Truitje truitje,int aantal) 
        {
            if ((truitje == null) || (aantal <= 0)) throw new BestellingException("VoegTruitjeToe");
            if (Truitjes.ContainsKey(truitje))
            {
                Truitjes[truitje] += aantal;
            }
            else
            {
                Truitjes.Add(truitje, aantal);
            }
        }
        public void VerwijderTruitje(Truitje truitje,int aantal)
        {
            if ((truitje == null) 
                || (aantal <= 0)
                || (!Truitjes.ContainsKey(truitje))
                || (Truitjes[truitje]<aantal)) throw new BestellingException("VerwijderTruitje");
            if (Truitjes[truitje] == aantal)
            {
                Truitjes.Remove(truitje);
            }
            else
            {
                Truitjes[truitje] -= aantal;
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj is Bestelling)
            {
                Bestelling compBestelling = (Bestelling)obj;
                if (Id.HasValue && compBestelling.Id.HasValue)
                    if (Id == compBestelling.Id) return true; else return false;
                else
                {
                    return Datum==compBestelling.Datum 
                        && IsBetaald==compBestelling.IsBetaald
                        && AfgerekendePrijs==compBestelling.AfgerekendePrijs;
                }
            }
            else return false;
        }
    }
}
