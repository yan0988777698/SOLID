using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Closed
{
    public enum Color
    {
        Red, Black, Green, Blue
    }
    public enum Size
    {
        Large, Medium, Small
    }
    public class Product
    {
        private string name;
        private Color color;
        private Size size;
        public string Name { get { return name; } set { this.name = value; } }
        public Color Color { get { return color; } set { this.color = value; } }
        public Size Size { get { return size; } set { this.size = value; } }
        public Product(string name, Color color, Size size)
        {
            this.name = name;
            this.color = color;
            this.size = size;
        }
    }
    public class ProductFilter
    {
        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (Product product in products)
            {
                if (product.Size == size)
                    yield return product;
            }
        }
    }
}