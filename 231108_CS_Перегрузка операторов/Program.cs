/*
Перегрузка операторов выполняется статическими методами класса.
Возвращаемое значение или один из параметров должны быть класса, для которого выполняется перегрузка
Параметры метода-оператора не могут включать ref и out
Перегрузку можно использовать и в классах (ссылочные) и в структурах (значимые).
Есть ограничение на перегрузку оператороов
Перегрузка не может изменить приоритет оператора
При перегрузке нельзя изменить число операндов оператора
Не все операторы можно перегружать

Разрешенные к перегрузке операторы:
унарный -, !, ~, ++, --, 
true, false, (критерии истинности/ложности объекта),
+, -, *, /, %,
&, | (битовые операции), ^, <<, >>,
==, !=, >, <, <=, =>,
&&, ||,
[], ()

Запрещенные к перегрузке операторы:
+=,  -=,  *=,  /=,  %=,  &=,  |=,  ^=,  <<=,  >>=
так как они определены через операцию присваивания и соответствующий оператор
поэтому они автоматически перегружаются, если соответствующий бинарный оператор
Операцию присваивания перегружаить нельзя
=, ., ?:, new, as, is, typeof

Доступны только в небезопасном коде:
->, sizeof, *, &

Синтаксис всех перегрузок операторов выглядит так:
public static <return type> operator <operation> (<parametres>)

Оперраторы срвавнения перегружаются попарно. Если перегружается один из пары,
дожен перегружаться и другой
== и !=
< и >
<= и >=
Пре перегрузке == и != нвдао учитывать что есть два чпособа проверки равенства
Равенство ссылок (тождество)) и равенство значений
public static bool ReferenceEquals(Object obj1, Object obj2)
проверяют содержат ли объекты  один адрес в памяти (то есть ссылаются ли на один и тот же объект)
невозможно переопределить
если передать здва значимых типа вернет false (т.к. объекты по разным адресам).
public bool virtual Equals(Object obj)
можно перегрузить по умолчанию проверяет равенство ссыдлок как ReferenceEquals
но сравнение значимых типов перегружено в типе System.ValueType где происходит
побитовое сравнение каждого поля класса


Перегрузка операторов true false позволяет использовать объекты типа напрямую
в операторах  if do while for как условные выражения
Оператор true возвращает true если состояние объекта истинно false...


Операторы && || перегрузить напрямую нельзя
Они моделируют через допустимые к перегрузке & |
Чтобы выполнить их перегрузку, надо:
- перегрузить в классе операторы true false
- перегрузить логические операторы & |
- они должны возвращать тип класса, в котором осуществляется перегрузка
параметрами должны быть ссылки на класс который содержит перегрузку


Операторы преобразования
Когда мы описываем новый тип данных, мы можем описать операторы которые будут приводить 
другие типы к нему и его к другиим типам
Приведение бывает явное и неявное 
СS запрещает неявное приведение с потерей данных, Поэтому такое приведение осущ явно.
Операции преобразования могут быть помечены двумя ключевыми словами:
 - implicit задает неявное преобразование и его можно использовать если преобразование
всегда безопасно независимо от значения переменной
- explicit - задает явное преобразование, его используют, когда возможна потнря данных

public static [implicit|explicit] operator <target type>(<source type>)
Можно выполнять приведение между собственными классами и структурами, но:
Нельзя выполнять приведение между объектами классов, которые наследуют друг друга
(вертикально нельзя, горизонтально можно)
Приведение может быть определено только в типе исходном, либо в типе куда происходит приведение

 */

using System;



namespace _231108_CS_Перегрузка_операторов
{
    // перегрузка унарных операторов (например инкремент декремент)
    class Point
    { 
    public int X { get; set; }
    public int Y { get; set; }

        public static Point operator ++(Point p)
        {
            p.X++; p.Y++;
            return p;
        }
        public static Point operator --(Point p)
        {
            p.X--; p.Y--;
            return p;
        }

        public static Point operator -(Point p)
        {
            return new Point { X = -p.X, Y = -p.Y };// инициализация параметров

        }
        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }

    // перегрузка бинарных операторов 
    class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector() { }
        public Vector(Point start, Point end)
        {
            X = end.X - start.X;
            Y = end.X - start.Y;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector { X = v1.X + v2.X, Y = v1.Y + v2.Y };
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector { X = v1.X - v2.X, Y = v1.Y - v2.Y };
        }
        public static Vector operator *(Vector v, int n)
        {
            return new Vector { X = v.X * n, Y = v.Y * n };
        }
        public static Vector operator *(int n, Vector v) // если операнды разных типов
        {
            return v * n;
        }
        public override string ToString()
        {
            return $"<{X},{Y}>";
        }

        // перегрузка Equals
        public override bool Equals(Object other)
        {
            return this.ToString() == other.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        // перегрузка оператора сравнения
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Point p1, Point p2)
        { 
            return !(p1 ==p2);
        }
        public static bool operator >(Point p1, Point p2)
        {
            return Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y) > Math.Sqrt(p2.X * p2.X + p2.Y * p2.Y);
        }
        public static bool operator <(Point p1, Point p2)
        {
            return Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y) < Math.Sqrt(p2.X * p2.X + p2.Y * p2.Y);
        }

        // перегрузка true false (перегружаются всегда в паре)
        public static bool operator true(Point p)
        {
            return p.X != 0 || p.Y != 0 ? true : false;
        }
        public static bool operator false(Point p)
        {
            return p.X == 0 && p.Y == 0 ? true : false;
        }
        // перегрузка && ||
        public static Point operator |(Point p1, Point p2)
        {
            if (p1.X != 0 || p1.Y != 0 || p2.X != 0 || p2.Y != 0)
                return p2;
            return new Point { X = 0, Y = 0 };
        }
        public static Point operator &(Point p1, Point p2)
        { 
        if(p1.X != 0 && p1.Y != 0 && p2.X != 0 && p2.Y != 0)
                return p2;
            return new Point { X = 0, Y = 0 };
        }

        // операторы преобразования

    }

    // структура (значимый тип)
    struct SPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Program
    {
        static void Point()
        {
            Point p = new Point { X = 10, Y = 6 };
            Console.WriteLine($"Исходная точка: {p}");
            Console.WriteLine($"Префиксная форма: {++p}");
            Console.WriteLine($"Постфиксная форма: {p++}");
            Console.WriteLine($"Отрицание: {-p}");
            Console.WriteLine($"Постфиксная форма: {p++}");
            Console.WriteLine($"не изменяет исходную точку: {p}");
        }

        static void vectors()
        {
            Point p1 = new Point { X = 2, Y = 3 };
            Point p2 = new Point { X = 3, Y = 1 };
            Vector v1 = new Vector(p1, p2);
            Vector v2 = new Vector { X = 2, Y = 3 };
            Console.WriteLine($"Векторы: {v1}, {v2}");
            Console.WriteLine($"Сложение векторов: {v1 + v2}");
            Console.WriteLine($"Вычитание векторов: {v1 - v2}");
            Console.Write($"Введите целое число:");
            int n = int.Parse(Console.ReadLine());
            v1 *= n;
            Console.WriteLine($"Умножение на число: {n}: {v1}");
        }

        static void structclasseql()
        {
            Point clp = new Point { X = 10, Y = 9 };
            Point clp2 = clp;//указывают на один и тот же адрес памяти
            Console.WriteLine($"Reference Equals: {ReferenceEquals(clp, clp2)}");

            SPoint stp = new SPoint { X = 10, Y = 9 };
            SPoint stp2 = stp;//указывают на один и тот же адрес памяти

            Console.WriteLine($"Reference Equals: {ReferenceEquals(stp, stp2)}");
            Console.WriteLine($"Equals: {Equals(clp, clp2)}");
            Console.WriteLine($"Equals: {Equals(stp, stp2)}");
        }

        static void comparisors()
        {
            Point p1 = new Point { X = 10, Y = 10 };
            Point p2 = new Point { X = 20, Y = 15 };
            Console.WriteLine($"Первая точка: {p1}");
            Console.WriteLine($"Вторая точка: {p1}");

            Console.WriteLine($"p1 == p2 : {p1 == p2}");
            Console.WriteLine($"p1 != p2 : {p1 != p2}");
            Console.WriteLine($"p1 > p2 : {p1 > p2}");
            Console.WriteLine($"p1 < p2 : {p1 < p2}");
        }

        static void truefalse()
        {
            Console.Write("Введите координаты точки: ");
            Point p = new Point
            {
                X = int.Parse(Console.ReadLine()),
                Y = int.Parse(Console.ReadLine())
            };
            if (p)
            {
                Console.Write("Точка не находится в начале координат");
            }
            else
            {
                Console.Write("Точка находится в начале координат");
            }
        }

        static void logic_oops()
        {
            Point p1 = new Point { X = 10, Y = 15 };
            Point p2 = new Point { X = 0, Y = 0 };

            Console.WriteLine($"Point 1: {p1}");
            Console.WriteLine($"Point 2: {p2}");

            Console.WriteLine($"Point 1 && Point 2: {p2}");
            if (p1 && p2)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

            Console.WriteLine($"Point 1 || Point 2: {p2}");
            if (p1 || p2)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        static void ShowSquare(Square s)
        {
            s.Draw();
        }
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle
            {
                Corner = new Point { X = 1, Y = 4 },
                Height = 5,
                Width = 10
            };

            Square s = new Square
            {
                Corner = new Point { X = 3, Y = 5 }
            Side = 7
            };

            Console.WriteLine(r);
            Console.WriteLine(s);
            Rectangle squaredRect = s;
            Square rectedSquare = (Square)r;
            Console.WriteLine(rectedSquare);
            Console.WriteLine(squaredRect);

            Square intSquare = 8;
            Console.WriteLine(intSquare);

            int a = (int)intSquare;
            Console.WriteLine(a);

            ShowSquare(a);

        }
    }
}
