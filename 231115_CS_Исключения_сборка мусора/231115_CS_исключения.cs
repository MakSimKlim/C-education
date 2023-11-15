using System;
using static System.Console;

namespace _231115_CS_исключения
{
    class Program
    {
       static int  Division(int a, int b)
        {
            int res;
            try
            {
                res = a / b;
            }
            catch (DivideByZeroException e) 
            {
                throw new DivideByZeroException("Возникло внутри Division");
            }
            return res;
        }
        static void Main1(string[] args)
        {
            try 
            {
                // Точка А
                try
                {
                    // Точка Б 
                }
                catch
                {
                    // Точка В
                }
                finally
                {
                };
                // Точка Г
            }
            catch 
            {
                // Точка Д
            }
            finally 
            {
            };

            //string s = null;
            //int a = 0;
            int a, b, d;
            try
            {
                /*
                 * WriteLine("Код до исключения");
                int b = 10 / a;
                throw new Exception("Исключение");
                WriteLine("Код после исключения");
                */
                WriteLine($"Введите первое число: ");
                a = int.Parse(ReadLine());
                WriteLine($"Введите второе число: ");
                b = int.Parse(ReadLine());
                /* if (b == 0)
                     throw new DivideByZeroException();
                 WriteLine($"Результат: {a / b}");*/
               
               WriteLine($"Результат: {Division(a, b)}");
            }
            catch (FormatException e)
            {
             WriteLine($"Не удалось конвертировать строку в число:{e.Message}");
            }

            catch (DivideByZeroException e) when (e.InnerException != null) // when - фильтр исключений
            {
                //WriteLine($"Ошибка деление на ноль: {e.Message}");
                //WriteLine(e.Message);
                WriteLine(e.StackTrace);
                WriteLine(e.InnerException.Message);

            }
            catch (Exception e)//Срабатывает только при ошибке (любой)
            {
                WriteLine($"Ошибка");
                //WriteLine($"Ошибка Сообщение:{e.Message}");
            }
            finally // срабатывает всегда
            {
                WriteLine("Завершающий код после исключения");
            };
            // WriteLine(s.Contains("h"));
            // Exception - класс для всех видов ошибок
        }
        static void Main(string[] args)
        {
            // check uncheck
            byte b = 100;
            b = (byte)(b + 200);
            WriteLine(b);
            int n = 65536;
            short s = (short)n;
            WriteLine($"{n} -> {s}");

            b = 255;
            try
            {
                //unchecked // ничего не происходит, byte превращается в 0
                checked // возникает ошибка типа OverflowException
                {
                    b++;
                }
                WriteLine(b);
            }
            catch (OverflowException e) 
            {
                WriteLine(e.Message);
            }
            // unchecked(byte) b;
            // проект -свойства - сборка - ошибка
        }
    }
}
