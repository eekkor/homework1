using System;
using ShopLibrary;

namespace ShopUnitTestProject
{
    [TestFixture]
    public class WarehouseUnitTests
    {
       [Test]
        public void ConstructorTest()
        {
            var warehouse = new Warehouse( Data.GetQuantityRecords(), 
                new PriceList(Data.GetPriceRecords()));

            var dict = Data.GetDictionaryFromWarehouse(warehouse);
            Assert.That(dict.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var dict = Data.GetDictionaryFromWarehouse(warehouse);

            var comodity = priceList.Get("Ноутбук", "Apple MacBook Air");
            warehouse.Add(comodity, 2);

            Assert.That(dict.Count, Is.EqualTo(2));
            Assert.That(dict[comodity], Is.EqualTo(7));

            comodity = new Comodity("Ноутбук", "Huawei MateBook 15", 56990);
            warehouse.Add(comodity, 20);
            Assert.That(dict.Count, Is.EqualTo(3));
            Assert.That(dict[comodity], Is.EqualTo(20));
        }

        [Test]
        public void SaleTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var dict = Data.GetDictionaryFromWarehouse(warehouse);

            var comodity = priceList.Get("Ноутбук", "Apple MacBook Air");
            warehouse.Sale(comodity, 2);
            Assert.That(dict.Count, Is.EqualTo(2));
            Assert.That(dict[comodity], Is.EqualTo(3));

            warehouse.Sale(comodity, 3);
            Assert.That(dict.Count, Is.EqualTo(1));
            Assert.IsFalse(dict.ContainsKey(comodity));
        }

        [Test]
        public void SaleExceptionTest1()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var comodity = new Comodity("Ноутбук", "Huawei MateBook 15", 56990);
 
            Assert.Throws<Exception>(() => warehouse.Sale(comodity, 1));           
        }

        [Test]
        public void SaleExceptionMessageTest1()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var comodity = new Comodity("Ноутбук", "Huawei MateBook 15", 56990);

            try
            {
                warehouse.Sale(comodity, 1);
            }
            catch (Exception e)
            {
                Assert.That(e.Message, Is.EqualTo("Необходимого товара нет на складе"));
            }
            
        }

        [Test]
        public void SaleExceptionTest2()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var comodity = priceList.Get("Ноутбук", "Apple MacBook Air");

            Assert.Throws<Exception>(() => warehouse.Sale(comodity, 10));
        }

        [Test]
        public void SaleExceptionMessageTest2()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var comodity = priceList.Get("Ноутбук", "Apple MacBook Air");

            try
            {
                warehouse.Sale(comodity, 1);
            }
            catch (Exception e)
            {
                Assert.That(e.Message, Is.EqualTo("Необходимого количества нет на складе"));
            }

        }

        [Test]
        public void CountTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var comodity = priceList.Get("Ноутбук", "Apple MacBook Air");

            Assert.That(warehouse.Count(comodity), Is.EqualTo(5));
        }

        [Test]
        public void CountAllTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);

            Assert.That(warehouse.CountAll(), Is.EqualTo(20));
        }

    }
}
