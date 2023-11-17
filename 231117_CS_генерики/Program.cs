using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace _231117_CS_генерики
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            try
            { 
            
            }
            catch (InvalidCastException e) 
            {
                WriteLine(e.Message);
            }
            */
            object obj = 45; // упаковка boxing 
            int number = (int)obj;// распаковка unboxing
            // приведение типов должно быть явным, без (int) будет ошибка
            // упаковка и распаковка снижает производительность.
            // с генериками повышается производительность, нет процесса упаковки-распаковки
            // появились обобщенные генерики
            // генерики находятся в пространстве имен Generic
            //
            // Collections        Generic
            // CollectionBase     Collection<T>
            // ArrayList          List<T>
            // HashTable          Dictionary<TKey, TValue>
            // Stack              Stack<T>
            // Queue              Queue<T>
            // нет                LinkedList<T>

            

        }
    }
}
