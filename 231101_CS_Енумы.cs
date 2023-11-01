using System;
using System.Text;



namespace _231101_CS_параметры_командной_строки
{


    class Program
    {
        // ==================== Аргументы ================================
        static void Arguments(string[] args)// задать аргументы: проект - свойства - отладка - Arg1 Arg2 Arg3 - ctrl+s
        {
            foreach (string arg in args)
            {
                Console.WriteLine(args);// вытащить аргументы
                                        //Int32.Parse(args);//вытащить число
            }
        }

        //==================== Енумы (константы)============================
        enum WeekDay { Mond, Tue, Wed, Thur, Frid, Sat, Sun };

        enum TransportType { Semi = 1, Coupling, Fridge, Openside, Tank };

        enum Discount { Default, Returning = 5, Patron = 10, VIP = 20 };

        static WeekDay NextDay(WeekDay d)
        {
            return d < WeekDay.Sun ? ++d : WeekDay.Mond;
        }

        enum Distance : ulong// использование значений за пределами int
        {
            Sun = 0,
            Mercury = 57900000,
            Venus = 108200000,
            Earth = 149600000,
            Mars = 227900000,
            Jupiter = 7783000000,
            Saturn = 1427000000,
        }

        static void Enums()
        {
            //System.Enum
            WeekDay day = WeekDay.Mond;
            Discount dis1 = Discount.VIP, dis2 = Discount.Returning;

            dis1.CompareTo(dis2);
            //0 - если значения равны
            // меньше 0, если значение dis меньше dis2
            // больше 0, если значение dis больше dis2
            if (System.Enum.IsDefined(typeof(Discount), 5))
            {
                Console.WriteLine(System.Enum.GetName(typeof(Discount), 5)); // typeof - тип Enum
            }

            Console.WriteLine(dis1.ToString());

        }

        // =======================Структуры==========================
        struct Dimensions
        {
            public double Length;
            public double Width;
            // конструктор структуры
            public Dimensions(double length, double width)
            {
                Length = length;
                Width = width;
            }
            public void Print()
            {
                Console.WriteLine($"Длина: {Length}, Ширина: {Width}.");
            }
            // конструктор по умолчанию для структур нельзя обойти, только можно объявить класс:


        }
        static void Structures()
        {
            //System.ValueType
            double l = 7.432, w = 23.99;
            Dimensions dimensions = new Dimensions(l, w);
            dimensions.Print();
            // структуры наследуют только интерфейсы
            // у структуры конструктор по умолчанию генерируется всегда
            // и переопределить его невозможно
            // поэтому его значения инициализируются некими значениями
        }

        // ============== классы ==============================================

        // [модификатор] class имя_класса: родительский_класс | интерфейсы
        // {
        //    тело_класса
        // }
        // класс может быть унаследован только от одного класса, но может наследовать множество интерфейсов
        // модификаторs - public, private, virtual, abstract и т.д.

        class Student
        {
            // _... так пишутся приватные поля
            int _studentId;
            string _firstName = "John";
            string _secondName = "Conor";
            string _group;
            public void Print()
            {
                Console.WriteLine($"Студент {_firstName} {_secondName}.");
            }
        }

        // ================ модификаторы классов =======================
        // Классы
        // public - могут пользоваться другие сборки
        // internal - доступен только внутри своей сборки

        //Поля и методы
        // private - доступен только внутри этого класса
        // protected - доступен внутри этонго класса и его потомков
        // internal - доступен только внутри текущей сборки
        // protected internal - доступен только в методах текущей сборки или производным
        // public - доступны всем
        // Если не указан модификатор доступа, то классам назначается internal, а полям и методам private

        // поле - это переменная
        // при объявлении полей указываются ключевые слова:
        // static  - для объявления статического поля, оно принадлежит не конкретному экземпляру, а всему классу
        // const - используется для объявления константного поля или постоянного поля
        // значение данного поля не может быть изменено
        // обязательно инициализируется при объявлении поля класса. Являются неявно статическими, поэтому к ним
        // обращаются через имя класса, а не через экземпляр
        // readonly - поле будет использоваться только для чтения, и значение ему назначается либо сразу в конструкторе,
        // либо  при объявлении самого поля (аналог const в с++)
        // 
        class MyClass
        {
            public readonly int var = 10;
            public readonly int[] myArr = { 1,2,3};
            //public static Discount 
        }

        static void Main(string[] args)
        {
            MyClass c = new MyClass();
            //MyClass.count++; // в С# ставится . вместо : как в С++
            //c.var = new int[100];// нельзя 
            c.myArr[0] = 11;//можно

        }
    }
}
