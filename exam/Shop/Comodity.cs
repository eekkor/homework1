using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class Comodity
    {
        public string Category { get; }
        public string Name { get; }
        public int Price { get;}

        public Comodity(string category, string name, int price)
        {
            Category = category;
            Name = name;
            Price = price;
        }

        public static Comodity Parse(string record)
        {
            var parts = record.Split('\t');
            if (parts.Length != 3)
                throw new FormatException();
            

            string category = parts[0];
            string name = parts[1];
            int price;
            if (!int.TryParse(parts[2], out price))
                throw new FormatException();
            

            return new Comodity(category, name, price);
        }

        public override string ToString() => $"{Category}\t{Name}\t{Price}";
        

        public static void Main(string[] args)
        {
        }

    }
}