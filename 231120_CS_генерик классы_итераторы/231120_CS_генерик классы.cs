using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

/*
 Ограниечения:
where T: struct
where T: class
where T: new() // должен иметь конструктор по-умолчанию
where T: <BaseClass> // T должен наследоваться от <BaseClass>
where T: <Interface> // T должен реализовывать интерфейс

Интерфейсы :
System.Collections.Generic - библиотека
Ilist<T>
IDictionary<T>
Icollection<T>
Icomparer<T>
IComparable<T>
 
 */
interface ISum<T>
{
    T Sum(T b);
}
class CalcInt : ISum<CalcInt>
{
    int _number = 0;
    public CalcInt(int n)
    {
        _number = 0;
    }
    public CalcInt Sum(CalcInt b)
    {
        return new CalcInt(_number + b._number);
    }
    public override string ToString()
    {
        return _number.ToString();
    }

}
class MyList<T> where T : ISum<T>
{
    List<T> list = new List<T>();
    public void Add(T t)
    {
        list.Add(t);
    }
    public T Sum()
    {
        if (list.Count == 0)
            return default(T);
        T result = list[0];
        for (int i = 1; i < list.Count; i++)
        {
            result = result.Sum(list[i]);
        }
        return result;
    }
}
// возможно иметь два типа с двумя разными ограничениями
class MyDict<T1, T2> where T1 : struct, IComparable
    where T2 : IComparable
{ 

}


namespace _231120_CS_генерик_классы
{
    // три слэша над классом выводит описание
    // которое будет выводиться Visual Studio при наведении на класс
    /// <summary>
    /// обобщенный класс описывающий точку
    /// </summary>
    /// <typeparam name="T">
    /// Численный тип. которому принадлежат координаты точки
    /// </typeparam>
    /// 
    
    // обобщенный класс (может наследоваться также от любого класса)
    public class Point2D<T> where T: struct
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Point2D(T x, T y)
            { 
            X = x;
            Y = y;
            }
        public Point2D()
        {
            X = default(T);
            Y = default(T);
        }
    }

    // наследование от обобщеного класса:
    class Coord2D : Point2D<int>
    { }

    class GenericCkasss<T> where T : class, IComparable, new() { }


    class Program
    {
        static T MaxElem<T>(T[] arr) where T : IComparable
        {
            T max = arr[0];
            foreach (T item in arr)
            {
                if (item.CompareTo(max) > 0)
                    max = item;

            }
            return max;
        }

        static void Points()
        {
           
               Point2D<int> p1 = new Point2D<int>();
               WriteLine($"X = {p1.X}, Y = {p1.Y}");
               WriteLine(typeof(Point2D<int>));

               Point2D<double> p2 = new Point2D<double>();
               WriteLine($"X = {p2.X}, Y = {p2.Y}");
               WriteLine(typeof(Point2D<double>));

               // Point2D<string> p3; - не подходит ести  Point2D<T> where T: struct (без struct работает)
             
        }

        static void Maximum()
        {
            // поиск максимума
            int[] arrInt = new int[] { 22, 64, 718, 14, 5 };
            WriteLine(MaxElem<int>(arrInt));
            double[] arrDouble = new double[] { 45.75, 77.345, 18.4, 11.3 };
            WriteLine(MaxElem<double>(arrDouble));
        }
        static void Main(string[] args)
        {
           

            

            MyList<CalcInt> l = new MyList<CalcInt>();
            l.Add(new CalcInt(10));
            l.Add(new CalcInt(20));
            l.Add(new CalcInt(30));
            WriteLine(l.Sum());

        }
    }
}
