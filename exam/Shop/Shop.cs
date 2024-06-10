using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public interface IWarehouse
    {
        void Add(Comodity comodity, int count);
        void Sale(Comodity comodity, int count);
        int Count(Comodity comodity);
        int CountAll();
    }
    public interface IPriceList
    {
        Comodity Get(string category, string name);
        List<Comodity> GetMany(string category, string name);
    }
    public class Shop
    {
        private readonly IPriceList priceList;
        private readonly IWarehouse warehouse;

        public Shop(IWarehouse warehouse, IPriceList priceList)
        {
            this.warehouse = warehouse;
            this.priceList = priceList;
        }

        public Comodity Get(string category, string name)
        {
            return priceList.Get(category, name);
        }

        public List<Comodity> GetMany(string category, string name)
        {
            return priceList.GetMany(category, name);
        }

        public void Add(Comodity comodity, int count)
        {
            warehouse.Add(comodity, count);
        }

        public void Sale(Comodity comodity, int count)
        {
            warehouse.Sale(comodity, count);
        }

        public int Count(Comodity comodity)
        {
            return warehouse.Count(comodity);
        }

        public int CountAll()
        {
            return warehouse.CountAll();
        }
    }
}