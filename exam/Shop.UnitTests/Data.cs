using System;
using System.Collections.Generic;
using System.Reflection;
using ShopLibrary;

namespace ShopUnitTestProject
{
    class Data
    {
        public static string[] GetPriceRecords()
        {
            return new[] { "Телевизор\tSamsung UE55TU7097U\t39990",
                "Телефон\tApple iPhone 12\t84990",
                "Ноутбук\tApple MacBook Air\t74990"
                };
        }

        public static string[] GetQuantityRecords()
        {
            return new[] { "Телефон\tApple iPhone 12\t15",
                "Ноутбук\tApple MacBook Air\t5",
                "Ноутбук\tHuawei MateBook 15\t2"
                };
        }

        public static List<Comodity> GetListFromPriceList(PriceList priceList)
        {
            return typeof(PriceList)
                .GetField("list", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(priceList)
                as List<Comodity>;
        }

        public static Dictionary<Comodity, int> GetDictionaryFromWarehouse(Warehouse warehouse)
        {
            return typeof(Warehouse)
                .GetField("dict", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(warehouse)
                as Dictionary<Comodity, int>;
        }

        public static Shop GetShop()
        {
            var priceList = new PriceList(GetPriceRecords());
            return new ShopLibrary.Shop(new Warehouse(GetQuantityRecords(), priceList), priceList);
        }

        public static PriceList GetPriceListFromShop(Shop shop)
        {
            return typeof(Shop)
                .GetField("priceList", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(shop)
                as PriceList;
        }

        public static Warehouse GetWarehouseFromShop(Shop shop)
        {
            return typeof(Shop)
                .GetField("warehouse", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(shop)
                as Warehouse;
        }
    }
}
