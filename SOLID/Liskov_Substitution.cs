using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_Substitution
{
    public interface IShape
    {
        int CalculateArea();
    }
    public class Rectangle : IShape
    {
        private int _width, _height;
        public virtual int Width { get { return _width; } set { _width = value; } }
        public virtual int Height { get { return _height; } set { _height = value; } }
        public Rectangle()
        {
        }
        public Rectangle(int width, int height)
        {
            this._width = width;
            this._height = height;
        }
        public override string ToString() { return $"Width:{this.Width}, Height:{this.Height}"; }
        public int CalculateArea()
        {
            return _width * _height;
        }
    }
    public class Square : Rectangle
    {
        public new int Width
        {
            set { base.Width = base.Height = value; }
        }
        public new int Height
        {
            set { base.Width = base.Height = value; }
        }
    }
    public class BetterSquare : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }
        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }
}