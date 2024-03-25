using BestellingenBL.Exceptions;
using BestellingenBL.Model;

namespace UnitTestDomein
{
    public class UnitTestTruitje
    {
        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public void Test_Prijs_Valid(double prijs)
        {
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, "2023-2024", 100);
            t.Prijs = prijs;
            Assert.Equal(prijs, t.Prijs);
        }
        [Theory]
        [InlineData(-0.001)]
        [InlineData(-100)]
        public void Test_Prijs_InValid(double prijs) 
        {
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, "2023-2024", 100);
            Assert.Throws<BestellingException>(() => t.Prijs = prijs);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public void Test_ctor_Valid(double prijs)
        {
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, "2023-2024", prijs);
            Assert.Equal(prijs,t.Prijs);
        }
        [Theory]
        [InlineData(-0.001)]
        [InlineData(-100)]
        public void Test_ctor_InValid(double prijs)
        {
            var ex=Assert.Throws<BestellingException>(()=>new Truitje("comp", "ploeg", "set", Maat.M, "2023-2024", prijs));
            Assert.Equal("SetPrijs", ex.Message);
        }
        [Fact]
        public void Test_Seizoen_Valid()
        {
            string seizoen = "2021-2022";
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, seizoen, 100);
            Assert.Equal(seizoen,t.Seizoen);
            seizoen = "2022-2023";
            t.Seizoen = seizoen;
            Assert.Equal(seizoen ,t.Seizoen);
        }
        [Theory]
        [InlineData("2021-2021")]
        [InlineData("19-1906")]
        [InlineData(null)]
        [InlineData("2021--2022")]
        [InlineData("a1905-1906")]
        [InlineData("1905-1906x")]
        [InlineData("2021+2022")]
        public void Test_Seizoen_InValid(string seizoen)
        {
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, "2021-2022", 100);
            Assert.Throws<BestellingException>(() => t.Seizoen=seizoen);
        }
        [Theory]
        [InlineData("ploe")]
        [InlineData("ploooooeg")]
        public void Test_Ploeg_Valid(string ploeg)
        {
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, "2021-2022", 100);
            t.Ploeg = ploeg;
            Assert.Equal(ploeg, t.Ploeg);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("plo")]
        [InlineData(" plo ")]
        public void Test_Ploeg_InValid(string ploeg)
        {
            Truitje t = new Truitje("comp", "ploeg", "set", Maat.M, "2021-2022", 100);
            Assert.Throws<BestellingException>(()=>t.Ploeg=ploeg);
        }
    }
}