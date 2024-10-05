using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    #region 錯誤寫法
    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (Product product in products)
            {
                if (product.Size == size)
                    yield return product;
            }
        }
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (Product product in products)
            {
                if (product.Color == color)
                    yield return product;
            }
        }
    }
    #endregion

    #region 正確寫法:使用specification pattern
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
    public class ColorSpecification : ISpecification<Product>
    {
        private Color _color;
        public ColorSpecification(Color color)
        {
            this._color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return _color == t.Color;
        }
    }
    public class SizeSpecification : ISpecification<Product>
    {
        private Size _size;
        public SizeSpecification(Size size)
        {
            this._size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return this._size == t.Size;
        }
    }
    public class Open_Closed_Filter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (Product item in items)
            {
                if (spec.IsSatisfied(item)) yield return item;
            }
        }
    }
    #endregion
}