using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_POO
{
    class Sale
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Movie { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Sale(string name, string type, string movie, int quantity, double price)
        {
            Name = name;
            Type = type;
            Movie = movie;
            Quantity = quantity;
            Price = price;
        }

        public Sale()
        {

        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Name, Type, Movie, Quantity, Price);
        }

    }
}
