using System;

namespace _231030_CS_строки
{
    class Program
    {
        static void Main(string[] args)
        {
            // System.String s; - упрощенно можно записать:
            string s = " Простая строка "; // строка хранится в куче
            // строка пишется без ключевоого слова NEW
            char[] chr = { 'М', 'а', 'с', 'с', 'с', 'и', 'в',' ','с','и','м','в','о','л','о', 'в' };
            string s1 = new string(chr);
            string s2 = new string(chr, 8 ,8);
            string s3 = new string('%', 10);

            Console.WriteLine(s);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);

            //Эскейп последовательности
            string escapes = "\\ \" \'";
            string path = "D:\\Kazin\\CSharp";
            string pathRaw = @"D:\\Kazin\\CSharp";

            Console.WriteLine(s[0]);
            Console.WriteLine(s.Length);
            char[] chrAr = new char[4];
            s.CopyTo(3, chrAr, 0, 4);
            Console.WriteLine(new string(chrAr));
            // сравнение строк:
            s.Equals(s1);
            // сравнение строк 2 вариант
            if (s == s1)
                Console.WriteLine(s1);
            s.CompareTo(s1); // возвращает 0, если строки равны
                             // положительное число, если данная строка выше переданной
                             // отрицательное - если ниже
            string.Compare(s, s1);
            string.CompareOrdinal(s, s1);
            s.StartsWith("Про");
            s.EndsWith("ка");
            s.IndexOf('п');
            s.LastIndexOf('к');
            s.IndexOfAny(chrAr);
            s.LastIndexOfAny(chrAr);
            Console.WriteLine(s.Substring(3, 4));
            Console.WriteLine(string.Concat(s, s1)); // конкантинация "соединение " 2х строк
            Console.WriteLine(s + s1); // конкантинация "соединение " 2х строк
            Console.WriteLine(s.ToLower());
            Console.WriteLine(s.ToUpper());
            Console.WriteLine(s.Replace("стая","стой"));
            s.Contains("стая");
            Console.WriteLine(s.Insert(7, " не "));
            Console.WriteLine(s.Remove(5,3));
            s = "Очень много пробелов в этой строке";
            string[] spl = s.Split(" ");
            foreach (string e in spl)
            {
                Console.WriteLine(e);
            }

            s.Trim();// убирает все пробелы и в начале и в конце
            s.TrimStart();
            s.TrimEnd();

            // форматирование текста
            s = string.Format("Текст: {0:d} {1:f}", 10, 2.32);// красивый вывод текста (формат текста) С- числовые данные со знаком емстной валюты
            Console.WriteLine(s);

            // интерполирование
            int number = 10;
            Console.WriteLine($"Текст: {number}") ;

            int num1 = 14, num2 = 5;
            Console.WriteLine($"Число 1 {num1 > num2 ?  "больше" : "меньше" } числа 2");
        }
    }
}
