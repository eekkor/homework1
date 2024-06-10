using ShopLibrary;

namespace ShopUnitTestProject
{
    [TestFixture]
    public class PriceListTests
    {
        [Test]
        public void ConstructorsTest()
        {
            var priceList = new PriceList();
            var list = Data.GetListFromPriceList(priceList);

            Assert.That(list.Count, Is.EqualTo(0));

            priceList = new PriceList(Data.GetPriceRecords());
            list = Data.GetListFromPriceList(priceList);

            Assert.That(list.Count, Is.EqualTo(3));
            Assert.That(list[0].Category, Is.EqualTo("Телевизор"));
            Assert.That(list[0].Name, Is.EqualTo("Samsung UE55TU7097U"));
            Assert.That(list[0].Price, Is.EqualTo(39990));
            Assert.That(list[1].Category, Is.EqualTo("Телефон"));
            Assert.That(list[1].Name, Is.EqualTo("Apple iPhone 12"));
            Assert.That(list[1].Price, Is.EqualTo(84990));
            Assert.That(list[2].Category, Is.EqualTo("Ноутбук"));
            Assert.That(list[2].Name, Is.EqualTo("Apple MacBook Air"));
            Assert.That(list[2].Price, Is.EqualTo(74990));
        }

        [Test]
        public void GetTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var list = Data.GetListFromPriceList(priceList);
            var comodity = priceList.Get("Телефон", "Apple iPhone 12");

            Assert.IsNotNull(comodity);
            Assert.That(comodity.Category, Is.EqualTo("Телефон"));
            Assert.That(comodity.Name, Is.EqualTo("Apple iPhone 12"));
            Assert.That(comodity.Price, Is.EqualTo(84990));
        }

        [Test]
        public void GetNull()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var list = Data.GetListFromPriceList(priceList);

            var comodity = priceList.Get("Телефон", "Apple iPhone 13");
            Assert.IsNull(comodity);

            comodity = priceList.Get("Телевизор", "Apple iPhone 12");
            Assert.IsNull(comodity);
        }

        [Test]
        public void GetManyTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());

            var list = priceList.GetMany("теле", "apple");
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0].Category, Is.EqualTo("Телефон"));
            Assert.That(list[0].Name, Is.EqualTo("Apple iPhone 12"));
            Assert.That(list[0].Price, Is.EqualTo(84990));

            list = priceList.GetMany("теле", "");
            Assert.That(list.Count, Is.EqualTo(2));
            Assert.That(list[0].Category, Is.EqualTo("Телевизор"));
            Assert.That(list[0].Name, Is.EqualTo("Samsung UE55TU7097U"));
            Assert.That(list[0].Price, Is.EqualTo(39990));
            Assert.That(list[1].Category, Is.EqualTo("Телефон"));
            Assert.That(list[1].Name, Is.EqualTo("Apple iPhone 12"));
            Assert.That(list[1].Price, Is.EqualTo(84990));

            list = priceList.GetMany("", "apple");
            Assert.That(list.Count, Is.EqualTo(2));
            Assert.That(list[0].Category, Is.EqualTo("Телефон"));
            Assert.That(list[0].Name, Is.EqualTo("Apple iPhone 12"));
            Assert.That(list[0].Price, Is.EqualTo(84990));
            Assert.That(list[1].Category, Is.EqualTo("Ноутбук"));
            Assert.That(list[1].Name, Is.EqualTo("Apple MacBook Air"));
            Assert.That(list[1].Price, Is.EqualTo(74990));
        }

        [Test]
        public void GetManyEmpty()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var list = priceList.GetMany("ноут", "samsung");
            Assert.That(list.Count, Is.EqualTo(0));

            list = priceList.GetMany("телевизор", "apple");
            Assert.That(list.Count, Is.EqualTo(0));
        }
    }
}
