using System;

/*
 collection_type this[index_type] {get;set;}
 
- одномерные индексаторы
- многомерные индексаторы
 
 */

namespace _231110_CS_индексаторы
{
    //многомерные индексаторы
    class MultArray
    {
        private int[,] ar;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public MultArray(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            ar = new int[rows, cols];
        }
        public int

    }


    //одномерные индексаторы
    class Shop
    {
        Book[] bookArr;
        public Shop(int size)
        {
            bookArr = new Book[size];
        }
        public Book this[int index] // перегрузка индексатора
        {
            get {
                if (index >= 0 && index < bookArr.Length)
                {
                    return bookArr[index];
                }
                throw new IndexOutOfRangeException();
            }
            set {
                bookArr[index] = value;
            }
        }
        public int Length
        {
            get{ return bookArr.Length; } 
        }

        public float Sum
        {
            get
            {
                float sum = 0;
                foreach (Book b in bookArr)
                {
                    sum += b.Price;
                }
                return Sum;
            }
        
        }

        public int FindByPrice(float price)
        {
            for (int i = 0; i < bookArr.Length; i++)
            {
                if (bookArr[i].Price == price)
                    return i;
            }
            return -1;
        
        }
        public Book this[string name]
        {
            get {
                foreach (Book b in bookArr)
                {
                    if (b.Name == name)
                        return b;
                }
                return new Book();
            }
            set {
                for (int i = 0; i < bookArr.Length; i++)
                    if (bookArr[i].Name == name)
                    {
                        bookArr[i] = value;
                    }
                bookArr[bookArr.Length] = value;
            
            }
        }

        public Book this[float price]
        {
            get {

                if (FindByPrice(price) >= 0)
                    return this[FindByPrice(price)];
                throw new Exception("Nesushestvushayz stoimost");
            }

            set { 
            if(FindByPrice(price))
                    return 0;
            }
        
        }

    }
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }

        public override string ToString()
        {
            return $"{Author},{Name},{Price} руб";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shop bookShop = new Shop(3);
            bookShop[0] = new Book { Author = "Donald Knut", Name = "Programming", Price = 1200 };
            bookShop[0] = new Book { Author = "Alex Pushkin", Name = "Izbrannoe", Price = 650 };
            bookShop[0] = new Book { Author = "Erih Gramm", Name = "Patterns", Price = 800 };

            try
            {
                for (int i = 0; i <= bookShop.Length; i++)//если убрать = ошибки не будет
                {
                    Console.WriteLine(bookShop[i]);
                }
                Console.WriteLine(bookShop["Programming"]);
                Console.WriteLine(bookShop[800.0f]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            MultArray m = new MultArray(2, 3);
            for (int i = 0; i < m.Rows; i++)
                for (int j = 0; j < m.Cols; j++)
                {
                    m[i, j] = i + j;
                    Console.Write($"{m[i, j]}");
                
                }
            Console.WriteLine();

        }
    }
}
