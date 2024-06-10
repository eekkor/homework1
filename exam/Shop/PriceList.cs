using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopLibrary 
{
    public class PriceList : IPriceList 
    {
        private List<Comodity> list;

        public PriceList(string[] records)
        {
            list = new List<Comodity>();
            foreach (var record in records)
            {
                var comodity = Comodity.Parse(record);
                list.Add(comodity);
            }
        }

        public PriceList()
        {
            list = new List<Comodity>();
        }

        public Comodity Get(string category, string name)
        {
            return list.FirstOrDefault(c => c.Category.Equals(category, StringComparison.OrdinalIgnoreCase) &&
                                            c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Comodity> GetMany(string category, string name)
        {
            var query = list.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(c => c.Category.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0);
            

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(c => c.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);

            return query.ToList();
        }
    }
}