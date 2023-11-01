using System;


namespace _231101_CS_строки_продолжение
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Исходная строка";
            Console.WriteLine(str1);
            str1 += "(в другом месте памяти)";
            Console.WriteLine(str1);
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello");
            sb.AppendLine();
            sb.Append("world");
            Console.WriteLine(sb);
            Console.Write("Кол-во символов: ");
            Console.WriteLine(sb.Length);
            Console.Write("Максимальное кол-во символов: ");
            Console.WriteLine(sb.Capacity);
            sb.Replace('1', 'm');
            sb.Insert(6, "Iorem ipsum");
            Console.WriteLine(sb);
            sb.Remove(3, 5);
            Console.WriteLine(sb);

        }
    }
}
