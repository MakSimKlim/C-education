using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _231117_CS_коллекции
{
    public class SortedArrayList : ArrayList 
    {
        public void AddSorted(object item)
        {
            int position = BinarySearch(item);
            if (position < 0)
            {
                position = ~position;
            }
            Insert(position, item);
        }
        public void ModifySorted(object item, int index)
        {
            RemoveAt(index);
            int position = BinarySearch(item);
            if (position < 0)
            {
                position = ~position;
            }
            Insert(position, item);
        }
    }
    class Demo
    {
        public static void SortedList()
        {
            SortedArrayList sal = new SortedArrayList();
            WriteLine("Начальное значение: ");
            sal.AddSorted(200);
            sal.AddSorted(-7);
            sal.AddSorted(0);
            sal.AddSorted(-20); 
            sal.AddSorted(56); 
            sal.AddSorted(200);
            foreach (int i in sal)
            {
                Write(i.ToString() + ' ');
            }
            WriteLine();
            WriteLine("Измененные значения");
            sal.ModifySorted(3,5);
            sal.ModifySorted(-1,2);
            sal.ModifySorted(2,4);
            sal.ModifySorted(7,3);
            foreach (int i in sal)
            {
                Write(i.ToString() + ' ');
            }
            WriteLine();
        }

    }
}
