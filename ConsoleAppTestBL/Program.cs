using BestellingenBL.Model;

namespace ConsoleAppTestBL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Truitje t1 = new Truitje("c1","p1","set1",Maat.M,"s1",80);
            Truitje t2 = new Truitje("c2", "p2", "set1", Maat.M, "s1", 90);
            Klant k1 = new Klant("jos", "Gent");
            Klant k2 = new Klant("Inga", "Oslo");
            Bestelling b1=new Bestelling(DateTime.Now);
            Bestelling b2 = new Bestelling(DateTime.Now);
            b1.VoegTruitjeToe(t1, 2);
            b1.VoegTruitjeToe(t2, 3);
            b2.VoegTruitjeToe(t1, 1);
            b2.VoegTruitjeToe(t2, 1);
            //b1.Klant = k1;
            //b1.Klant = k2;
            k1.VoegBestellingToe(b1);
            k2.VoegBestellingToe(b2);
            k1.VoegBestellingToe(b2);
        }
    }
}
