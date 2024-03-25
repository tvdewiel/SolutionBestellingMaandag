using BestellingenBL.Exceptions;
using BestellingenBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDomein
{
    public class UnitTestBestelling
    {
        private Truitje t1, t2;
        private Klant k1, k2;

        public UnitTestBestelling()
        {
            t1 = new Truitje("comp", "ploeg", "set", Maat.M, "2021-2022", 100);
            t2 = new Truitje("comp", "ploegX", "set", Maat.M, "2021-2022", 100);
            k1 = new Klant("jos", "Gent");
            k2 = new Klant("inga", "Oslo");
        }

        [Fact]
        public void Test_VoegTruitjeToe_Valid() 
        { 
            Bestelling b=new Bestelling(DateTime.Now);
            
            b.VoegTruitjeToe(t1, 5);
            Assert.Contains(t1, b.Truitjes.Keys);
            Assert.Equal(5, b.Truitjes[t1]);
            Assert.Equal(1, b.Truitjes.Count);

            b.VoegTruitjeToe(t1 , 3);
            Assert.Contains(t1, b.Truitjes.Keys);
            Assert.Equal(8, b.Truitjes[t1]);
            Assert.Equal(1, b.Truitjes.Count);

            b.VoegTruitjeToe(t2 , 4);
            Assert.Contains(t1, b.Truitjes.Keys);
            Assert.Equal(8, b.Truitjes[t1]);
            Assert.Contains(t2, b.Truitjes.Keys);
            Assert.Equal(4, b.Truitjes[t2]);
            Assert.Equal(2, b.Truitjes.Count);
        }
        [Fact]
        public void Test_VoegTruitjeToe_InValid()
        {
            Bestelling b = new Bestelling(DateTime.Now);

            Assert.Throws<BestellingException>(() => b.VoegTruitjeToe(null, 5));
            Assert.Throws<BestellingException>(() => b.VoegTruitjeToe(t1, 0));
            Assert.Throws<BestellingException>(() => b.VoegTruitjeToe(t1, -1));
        }
        [Fact]
        public void Test_SetKlant_Valid()
        {
            Bestelling b=new Bestelling(DateTime.Now);
            b.VoegTruitjeToe(t1, 2);

            b.Klant = k1;
            Assert.Equal(k1, b.Klant);
            Assert.True(k1.HeeftBestelling(b));
            b.Klant = k2;
            Assert.Equal(k2,b.Klant);
            Assert.True(k2.HeeftBestelling(b));
            Assert.False(k1.HeeftBestelling(b));
        }
    }
}
