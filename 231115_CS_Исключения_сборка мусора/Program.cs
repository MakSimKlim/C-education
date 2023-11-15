using System;
using static System.Console;
using static System.GC;


/*
 Жизненный цикл объектов:

1) Выделение памяти для типа
2) Инициализация выделенной памяти (вызов конструктора
привидение объектов в начальное значение)
3) использование объекта в программе
4) разрушение состояния объекта
5) освобождение занятой памяти
 
Для облегчения последних задач в С# есть встроенный сборщик мусора
Garbage Collector

Выделение памяти под новые объекты происходит в динамической памяти
которая называется куча (heap).
Сборщик мусора - это недерменированный процесс, то есть программист 
не знает, когда среда (CLR) его вызывает. Решение принимает CLR.
Её можно запустить принудительно, вызвав System.GC.Collect()

Сборка мусора состоит из:
 - Поиск объектов, на которые нет ссылок на управляемой куче
 - Сборщик мусора пытается завершить объекты, на которые нет ссылок
 - Освобождение памяти выделенной для тех объектов, которые удалось завершить

Сборщик мусора не запустится, даже если в куче много недостижимых объектов,
если в куче еще достаточно места для размещения новых

 
 */


namespace _231115_CS_операторы_исключений
{
    class Example : IDisposable()
    {
        public string Name { get; set; }

        public Example(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
                    Name = name;
            }
        }
    }
    public void CreateGarbage()
    {
            garbage = new string[256];
            for (int i = 0; i< 256; i++)
               garbage[i] = "gdgdfgdg";
            garbage = new string[256];
    }

    //финализатор (синтаксичеки как деструктор, но ведет себя по-другому)
    // не рекомендуется его использовать просто так пустым,
    // лучше это делать когда на это есть веские причины
    // финализатор только в кллассах
    ~Example()
    {
        WriteLine();
    }
    public void Dispose()// метод интерфейса  IDisposable
    {
        WriteLine(ToString() + "очищает ресурсы");
        GC.SuppressFinalize(this);// Финализатор для этого объекта вызываться не будет, вызывается только внутри Dispose
    }

class Program
    {
       
       
        static void Garbage() // все методы сборщика мусора
        {
            WriteLine("Сборщик мусора");

            WriteLine($"Максимальное поколение{ GC.MaxGeneration}");
            Example ex = new Example("Garbage Helper");

            WriteLine($"Поколение объекта { GC.GetGeneration(ex)}");
            WriteLine($"Занято памяти { GC.GetTotalMemory(false)}"); //true - борка мусора + дефрагментация памяти,false - покажет сколько занято памяти
            ex.CreateGarbage();
            WriteLine($"Занято памяти { GC.GetTotalMemory(false)}"); //true - борка мусора + дефрагментация памяти,false - покажет сколько занято памяти
            GC.Collect(0);// сборка мусора в поколении 0
            WriteLine($"Занято памяти { GC.GetTotalMemory(false)}"); //true - борка мусора + дефрагментация памяти,false - покажет сколько занято памяти
            WriteLine($"Поколение объекта { GC.GetGeneration(ex)}");
            GC.Collect();// сборка мусора во всех поколениях (без параметра)
            WriteLine($"Занято памяти { GC.GetTotalMemory(false)}"); //true - борка мусора + дефрагментация памяти,false - покажет сколько занято памяти
            WriteLine($"Поколение объекта { GC.GetGeneration(ex)}");

        }

        static void Main(string[] args)
        {
            /*
            try
            {
                Example ex = new Example(null);
            }
            catch (Exception e)
            {
                WriteLine(e.Message); 
            }
            GC.Collect();// класс сборщика мусора System.GC.Collect()
            */
            Example example = new Example("Привет");
            example.Displose();
        }
    }
}
