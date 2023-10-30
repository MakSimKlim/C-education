using System;

namespace _231030_CS_продолжение_теория
{
    class Program
    {
        static void BasicConvert()
        {
            // явное преобразование
            int x = 5;
            float y = 6.5f;
            float b = y + x;// это допустимо
            // int a = y+x; // это недопустимо
            int a = (int)(y + x);
        }
        static void AdvancedConvert()
        {
            // если преобразования невозможны, можно использовать
            // конвертацию через статические методы класса Convert
            Console.Write("Ведите целое число: ");
            string numberString = Console.ReadLine();
            int number = Convert.ToInt32(numberString);
            Console.Write("Строка конвертирована, значение: " + number);
            // Также есть статический метод Parse  у классов типов данных
            // Но он работает только со строками.
            number = Int32.Parse(numberString);
            Console.WriteLine();
            //  у всех встроенных классов есть метод ToString,
            // который возвращает значение, преобразованное в строку
            number.ToString();
        }

        static public int a = 10;

        static bool CheckEvenAndIncreaseA(int b)
        {
            a++;
            return b % 2 == 0;
        }

        static void LogicOperators()
        {
            // разница в написании && и &
            int b = 5;
            if (b == 6 & CheckEvenAndIncreaseA(b)) // & проверяет оба условия, даже если слева ложь
            {
                Console.WriteLine("b was even ");
            }
            else
            {
                Console.WriteLine("b wasn't even or 6");
            }
            Console.WriteLine(a);

            int c = 7;
            if (c == 6 && CheckEvenAndIncreaseA(c))// && проверит только слева, если справа проверять уже не будет
            {
                Console.WriteLine("c was even ");
            }
            else
            {
                Console.WriteLine("c wasn't even or 6");
            }
            Console.WriteLine(a);

        }

        static void ByteOperators()
        {
            // побитовые операции
            int a = 5 & 6; // если слева и справа числа - становится побитовым оператором
            int b = 5 | 6; // если слева и справа числа - становится побитовым оператором

            int and = 5 & 6;     // если слева и справа числа - становится побитовым оператором
            int or = 7 | 11;     // если слева и справа числа - становится побитовым оператором
            int xor = 10 ^ 15;   // побитовое исключающее ИЛИ
            int shiftR = 10 >> 1; // побитовый сдвиг
            int shiftL = 10 << 1;// побитовый сдвиг
            int not = ~6;
            Console.WriteLine(and.ToString() + ' ' + or.ToString() + ' ' + xor.ToString());
            // приоритет у двойных ниже чем у одинарных

        }

        static void Switch()
        {
            //switch case
            int a = 5;
            switch (a)
            {
                case 1:
                    break;
                case 2: // пустой блок, толькк при пустом блоке может НЕ стоять dreak
                        //Console.WriteLine("2 or 3")// так нельзя если нет Break!
                case 3:
                    Console.WriteLine("2 or 3");
                    break;
                default:
                    break;

            }

        }

        static void Cicles()
        {
            // циклы такиее же как в С++, но есть еще циклы по коллекции
            // for
            // while do... while
            // foreach
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            for (int x = 0, y = 0; x < 10 && y < 10; x++, y++)
            {
                Console.WriteLine(x.ToString() + ' ' + y.ToString());
            }

            Random rand = new Random(); // генерирует случайные числа
            while (true) // только значение bool (цифр не должно быть в отличие от С++)
            {
                int a = rand.Next();
                Console.WriteLine(a);
                if (a % 3 == 0)
                    break;
            }

            int k = 0;
            do
            {
                int a = 10;
                Console.WriteLine(a * k);
                k++;
            } while (a % 2 != 0);

            // цикл foreach() - цикл коллекций 
            // этот цикл только для чтения? его можно перезаписать только строкой

            int j = 3;
        Label1: // метка
            string s = "Hello world";
            foreach (char с in s)
            {
                //с = '1';
                Console.WriteLine(c);
                if (с == 'o' && j-- > 0)
                    goto Label1;// лучше этим не пользоваться, т.к. не понятно что происходит с данными в памяти
                // goto делает код непредсказуемым, большие угрозы утечки памяти
                // также неудобно следить за ним в коде
                // в очень узком применении его можно использовать
            }

        }

        static void Main(string[] args)
        {
           

        }


    }
}
