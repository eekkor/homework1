using System;
using System.Collections.Generic;

namespace ShopLibrary
{
    public class Warehouse : IWarehouse
    {
        private Dictionary<Comodity, int> dict;

        public Warehouse(string[] records, PriceList list)
        {
            dict = new Dictionary<Comodity, int>();

            foreach (var record in records)
            {
                var parts = record.Split('\t');
                if (parts.Length != 3)
                {
                    throw new FormatException();
                }

                string category = parts[0];
                string name = parts[1];
                int count;
                if (!int.TryParse(parts[2], out count))
                {
                    throw new FormatException();
                }

                var comodity = list.Get(category, name);
                if (comodity != null)
                {
                    dict.Add(comodity, count);
                }
            }
        }

        public void Add(Comodity comodity, int count)
        {
            if (dict.ContainsKey(comodity))
                dict[comodity] += count;
            
            else
                dict.Add(comodity, count);
        }

        public void Sale(Comodity comodity, int count)
        {
            if (!dict.ContainsKey(comodity))
                throw new Exception("Необходимого товара нет на складе");
            

            if (dict[comodity] < count)
                throw new Exception("Необходимого товара нет на складе");
            

            dict[comodity] -= count;
            if (dict[comodity] == 0)
            {
                dict.Remove(comodity);
            }
        }

        public int Count(Comodity comodity)
            => dict.ContainsKey(comodity) ? dict[comodity] : 0;
        

        public int CountAll()
        {
            int total = 0;
            foreach (var count in dict.Values)
                total += count;
            
            return total;
        }
    }
}
