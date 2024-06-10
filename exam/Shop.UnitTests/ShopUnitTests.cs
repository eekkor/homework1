using System;
using ShopLibrary;

namespace ShopUnitTestProject
{
    [TestFixture]
    public class ShopUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var shop = Data.GetShop();
            
            var priceList = Data.GetPriceListFromShop(shop);
            Assert.That(Data.GetListFromPriceList(priceList).Count, Is.EqualTo(3));

            var warehouse = Data.GetWarehouseFromShop(shop);
            Assert.That(Data.GetDictionaryFromWarehouse(warehouse).Count, Is.EqualTo(2));          
        }

        [Test]
        public void GetTest()
        {
            var shop = Data.GetShop();
            var comodity = shop.Get("Телефон", "Apple iPhone 12");

            Assert.IsNotNull(comodity);
            Assert.That(comodity.Category, Is.EqualTo("Телефон"));
            Assert.That(comodity.Name, Is.EqualTo("Apple iPhone 12"));
            Assert.That(comodity.Price, Is.EqualTo(84990));
        }

        [Test]
        public void GetNullTest()
        {
            var shop = Data.GetShop();

            var comodity = shop.Get("Телефон", "Apple iPhone 13");
            Assert.IsNull(comodity);

            comodity = shop.Get("Телевизор", "Apple iPhone 12");
            Assert.IsNull(comodity);
        }

        [Test]
        public void GetManyTest()
        {
            var shop = Data.GetShop();

            var list = shop.GetMany("теле", "apple");
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0].Category, Is.EqualTo("Телефон"));
            Assert.That(list[0].Name, Is.EqualTo("Apple iPhone 12"));
            Assert.That(list[0].Price, Is.EqualTo(84990));

            list = shop.GetMany("теле", "");
            Assert.That(list.Count, Is.EqualTo(2));
            Assert.That(list[0].Category, Is.EqualTo("Телевизор"));
            Assert.That(list[0].Name, Is.EqualTo("Samsung UE55TU7097U"));
            Assert.That(list[0].Price, Is.EqualTo(39990));
            Assert.That(list[1].Category, Is.EqualTo("Телефон"));
            Assert.That(list[1].Name, Is.EqualTo("Apple iPhone 12"));
            Assert.That(list[1].Price, Is.EqualTo(84990));

            list = shop.GetMany("", "apple");
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
            var shop = Data.GetShop();
          
            var list = shop.GetMany("ноут", "samsung");
            Assert.That(list.Count, Is.EqualTo(0));

            list = shop.GetMany("телевизор", "apple");
            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddTest()
        {
            var shop = Data.GetShop();
            var dict = Data.GetDictionaryFromWarehouse(
                Data.GetWarehouseFromShop(shop));

            var comodity = shop.Get("Ноутбук", "Apple MacBook Air");
            shop.Add(comodity, 2);

            Assert.That(dict.Count, Is.EqualTo(2));
            Assert.That(dict[comodity], Is.EqualTo(7));

            comodity = new Comodity("Ноутбук", "Huawei MateBook 15", 56990);
            shop.Add(comodity, 20);
            Assert.That(dict.Count, Is.EqualTo(3));
            Assert.That(dict[comodity], Is.EqualTo(20));
        }

        [Test]
        public void SaleTest()
        {
            var shop = Data.GetShop();
            var dict = Data.GetDictionaryFromWarehouse(
                Data.GetWarehouseFromShop(shop));

            var comodity = shop.Get("Ноутбук", "Apple MacBook Air");
            shop.Sale(comodity, 2);
            Assert.That(dict.Count, Is.EqualTo(2));
            Assert.That(dict[comodity], Is.EqualTo(3));

            shop.Sale(comodity, 3);
            Assert.That(dict.Count, Is.EqualTo(1));
            Assert.IsFalse(dict.ContainsKey(comodity));
        }

        [Test]
        public void SaleExceptionTest1()
        {
            var shop = Data.GetShop();
            var comodity = new Comodity("Ноутбук", "Huawei MateBook 15", 56990);

            Assert.Throws<Exception>(() => shop.Sale(comodity, 1));
        } 

        [Test]
        public void SaleExceptionTest2()
        {
            var shop = Data.GetShop();
            var comodity = shop.Get("Ноутбук", "Apple MacBook Air");

            Assert.Throws<Exception>(() => shop.Sale(comodity, 10));
        }

        [Test]
        public void CountTest()
        {
            var shop = Data.GetShop();
            var comodity = shop.Get("Ноутбук", "Apple MacBook Air");

            Assert.That(shop.Count(comodity), Is.EqualTo(5));
        }

        [Test]
        public void CountAllTest()
        {
            var shop = Data.GetShop();

            Assert.That(shop.CountAll(), Is.EqualTo(20));
        }
    }
}
