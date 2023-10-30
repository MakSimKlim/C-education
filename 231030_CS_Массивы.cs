using System;

namespace _231030_CS_Массивы
{
    class Program
    {
        static void Arrays()
        {
            //=============== одномерные массивы====================

            // int ar[100]; - запись массива в С++
            // все типы массивов унаследованы от System.Array
            int[] ar = new int[50]; // синтаксис записи массива в С#, отличается от С++
            // new - объявляются экземпляры классов
            string[] s = new string[5]; // - они все сейчас по-умолчанию null (пустое место)

            // в отл от С++ не можем указать больше или меньше данных
            // указываем их ровное кол-во, 
            int[] ar2 = new int[5] { 1, 2, 3, 4, 5 };
            //либо не указываем вообще
            int[] ar3 = new int[] { 1, 2, 3, 4, 5, 6 };
            // либо сразу списком инициализации
            int[] ar4 = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            // нельзя так :
            //int[] ar5;
            //ar5 = { 1,2,3,4,5};
            // можно так:
            int[] ar5;
            ar5 = new int[] { 1, 2, 3, 4, 5 };
            // заменить элементы можно так:
            Console.WriteLine(ar2[2]);
            ar5[3] = 99;
            Console.WriteLine(ar5[3]);

            //=============== многомерные массивы====================
            // ! всегда прямоугольные
            float[,] m = new float[2, 3];
            int[,] m1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] m2 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int[,] m3 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };
            int[,,] m3D = new int[3, 4, 2];//трехмерный многомерный массив
            Console.WriteLine(m1[1, 1]);// вывод значений

            // зубчатые массивы (не всегда прямоугольные):
            int[][] jagged = new int[5][];
            jagged[0] = new int[] { 1, 2 };
            jagged[1] = new int[] { 3, 4, 5 };

            // атрибуты(методы) массивов
            Console.WriteLine(ar2.Length); // длина массива
            Console.WriteLine(ar2.GetLowerBound(0) + ar2.GetUpperBound(0));//возвращает нижний и наибольший индекс
            // копирование в массив CopyTo
            /*int[] arn = new int[5];
            ar2.CopyTo(arn);*/
            // копия CopyTo()
            // метод Clear:
            Array.Clear(ar2, 0, 4);// с указанного индекса приравнивает их к нулю
            Array.IndexOf(ar2, 4);// возврвщает индекс в массиве (первое вхождение)
            Array.LastIndexOf(ar2, 1);// возврвщает индекс в массиве (последнее вхождение)
            Array.Resize<int>(ref ar2, 6); // изменяет размер массива
            Array.Reverse(ar2); // разворот массива
            Array.Sort(ar2); // сортировка массива

            Console.WriteLine(ar2.Rank); // возвращает мерность массива
            Console.WriteLine(m3D.Rank); // возвращает мерность массива
            Console.WriteLine(jagged.Rank); // возвращает мерность массива (у зубчатого всегда ранг 1, потому что это массив массивов, а не многомерный массив)

        }
        static void Main(string[] args)
        {
            int[,] m = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            foreach (int e in m)
            {
                Console.WriteLine(e);
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                    Console.Write(m[i, j].ToString() + '\t');
                Console.WriteLine();
            }

            int[][] jagged = new int[3][];
            jagged[0] = new int[] { 1, 2 };
            jagged[1] = new int[] { 3, 4, 5 };
            jagged[2] = new int[] { 6,7,8,9 };

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged.Length; j++)
                    Console.Write(jagged[i][j].ToString() + '\t');
                Console.WriteLine();
            }    
        }
    }
}
