using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;


namespace _231117_CS_коллекции
{
    class ExampleICollection : ICollection // нажать на лампочку -> реализовать интерфейс
    {
        public int Count => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class ExampleIDict : IDictionary // нажать на лампочку -> реализовать интерфейс
    {
        public object this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection Keys => throw new NotImplementedException();

        public ICollection Values => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public void Add(object key, object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class ExampleIDictEnum : IDictionaryEnumerator
    {
        public object Key => throw new NotImplementedException();

        public object Value => throw new NotImplementedException();

        public DictionaryEntry Entry => throw new NotImplementedException();

        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    class ExampleColl
    {
        ICollection iC;
    }
    class Program
    {
        static void SpecAndArrayListCollection()
        {
            // специализированные коллекции: 
            ListDictionary Id;
            HybridDictionary hd;
            CollectionsUtil cu;
            NameValueCollection nv;
            StringCollection sc;
            StringDictionary sd;

            // необобщенные коллекции:
            /*
             Хранят данные типа object, то есть элементы коллекций 
             этого типа могут иметь разные типы
             */
            ArrayList arrayList1 = new ArrayList();
            ArrayList arrayList2 = new ArrayList(50);
            ArrayList arrayList3 = new ArrayList(new int[] { 1, 5, 18 });

            arrayList1.Add(1); // принимает один элемент

            WriteLine(arrayList1.Capacity);// Capacity - емкость массива (сколько выделено памяти под элементы)
            for (int i = 0; i < 8; i++)
                arrayList1.Add(i);
            WriteLine(arrayList1.Capacity);
            arrayList1.TrimToSize();//Задает значение емкости, равное действительному количеству элементов в ArrayList
            WriteLine(arrayList1.Capacity);
            WriteLine(arrayList1.Count); // Count - сколько занято памяти

            arrayList2.AddRange(new int[] { 2, 5, 48, 14 });// принимает коллекции элементов

            //вывод данных из коллекции
            WriteLine(arrayList2[1]);
            arrayList2[3] = (int)arrayList2[3] * 2;
            WriteLine(arrayList2[3]);

            // добавление элементов в коллекцию
            arrayList2.Insert(2, "Two");
            WriteLine(arrayList2[2]);
            arrayList2.InsertRange(2, new int[] { 3, 7, 9 });
            foreach (object e in arrayList2)
            {
                Write(e);
                Write(' ');
            }

            // удаление элементов из коллекции
            WriteLine();
            arrayList2.RemoveAt(0);
            arrayList2.Remove("Two");
            arrayList2.RemoveRange(1, 2);
            foreach (object e in arrayList2)
            {
                Write(e);
                Write(' ');
            }

            ArrayList arrayList4 = arrayList2.GetRange(1, 2);
            arrayList2.IndexOf(7);//первое вхождение перреданного элемента
            WriteLine(arrayList2.LastIndexOf(4));//находит последнее вхождение перреданного элемента
            arrayList3.Sort();//сортировка данных одного типа (будет ошибка при разных типах данных)
        }

        static void StackCollection()
        {
            // в Stack используется принцип "последний зашел, первый вышел"
            // коллекция Stack объявляется так:
            Stack st1 = new Stack();
            Stack st2 = new Stack(7);
            Stack st3 = new Stack(new ArrayList { 3, 5 });
            st1.Push("Element1");// элементы кладутся в коллекцию с помощью этого метода
            st1.Push("Element2");
            st1.Push("Element3");
            st1.Push("Element4");
            WriteLine(st1.Pop());// элементы удаляются из коллекции с помощью этого метода
            WriteLine(st1.Peek());// элементы просматриваются в коллекции с помощью этого метода
            if (st1.Contains("Element2"))
                WriteLine("Element 2 was found");

            // т.к. не можем напрямую в стэке взаимодействовать с элементом, используем такой способ
            // например создаем массив strs, затем копируем в него все значения, начиная с указанного элемента
            string[] strs = new string[10];
            st1.CopyTo(strs, 2);

            // удаление из стэка
            st1.Clear();
        }

        static void QueueCollection()
        {
            //============ Очереди =========
            // в Queue используется принцип "первый зашел, первый вышел"
            Queue queue1 = new Queue();
            Queue queue2 = new Queue(5);
            // коэффициент роста в очереди задается явно
            Queue queue3 = new Queue(new ArrayList { "one", 1 });
            Queue queue4 = new Queue(7, 3.0f);
            queue1.Enqueue(5);// добавляет элемент в конец очереди
            queue1.Enqueue(45);
            queue1.Enqueue(32);
            queue1.Enqueue(12);
            WriteLine(queue1.Dequeue()); // убирает элемент из очереди
            WriteLine(queue1.Peek()); // посмотреть злемент в очереди
        }

        static void HashtableCollection()
        {
            //============= Хэштэйбл ключи ==========
            // хэш - код: уникален для каждого значения (некое число)
            // поиск по нему - гораздо быстрее (тк это число),
            // но он медленнее List, Stack, Queue

            Hashtable hs1 = new Hashtable();
            int i = 6;
            string s = "Hello World";
            WriteLine(i.GetHashCode());
            WriteLine(s.GetHashCode());

            // в этом словаре 15 конструкторов:
            //hs1.Keys();//возвращает ключи
            hs1.ContainsKey(s);
            hs1.ContainsValue(s);
            // создание словаря (пример)
            Hashtable student = new Hashtable();
            student.Add("name", "John");
            student.Add("surname", "Smith");
            student.Add(100, 5.5);

            Hashtable phonebook = new Hashtable();
            phonebook.Add(556656562, "Maria");
            phonebook.Add(654356436, "Academia");

            foreach (object o in student.Keys)
            {
                WriteLine(o.ToString() + ": " + student[o].ToString());
            }

            SortedList sl = new SortedList();

        }

        static void InterfaceCollection()
        {
            // =================== Интерфейсы коллекции =========================
            //class ExampleICollection : ICollection // нажать на лампочку -> реализовать интерфейс
            /*
             выпадет большой список который исправит ошибку реализации интерфейса стандартными методами
             
             */

        }

        static void Main(string[] args)
        {
            Demo.SortedList();
           
           
        }
    }
}
