using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _231108_CS_Перегрузка_операторов
{
    abstract class Shape
    {
        public abstract void Draw();
    }
    abstract class Quadrangle:Shape
    {
        protected Point corner { get; set; }
    }

    abstract class Rectangle: Quadrangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public override void Draw()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
                Console.Write("*");
            Console.WriteLine();
        }
    }
    public override string ToString()
    {
        return $"Rect:{Corner}\n\tWidth = {Width}\n\tHeight = {Height}";
    }

    public static implicit operator Rectangle(Square s)
    { 
    return new Rectangle()
    }

    public static explicit operator Square(Rectangle rect)
    {
        return new Square { Corner = rect.Corner, Side = rect.Height };
    }

    public static implicit operator Square(int number)
    { 
    return new Square { Corner = new Point { X=0,Y=0},Side = number }
    }

    public static explicit...

}
