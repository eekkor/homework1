using ShopLibrary;

namespace ShopUnitTestProject
{
    [TestFixture]
    public class ComodityUnitTests
    {
        [Test]
        public void ConstrutorTest()
        {
            var comodity = new Comodity("Телевизор", "Samsung UE55TU7097U", 39990);
            Assert.That(comodity.Category, Is.EqualTo("Телевизор"));
            Assert.That(comodity.Name, Is.EqualTo("Samsung UE55TU7097U"));
            Assert.That(comodity.Price, Is.EqualTo(39990));
        }

        [Test]
        public void ParseTest()
        {
            var comodity = Comodity.Parse("Телевизор\tSamsung UE55TU7097U\t39990");
            Assert.That(comodity.Category, Is.EqualTo("Телевизор"));
            Assert.That(comodity.Name, Is.EqualTo("Samsung UE55TU7097U"));
            Assert.That(comodity.Price, Is.EqualTo(39990));
        }

        [Test]
        public void ToStringTest()
        {
            var comodity = new Comodity("Телевизор", "Samsung UE55TU7097U", 39990);
            Assert.That(comodity.ToString(), Is.EqualTo("Телевизор\tSamsung UE55TU7097U\t39990"));
        }
    }
}