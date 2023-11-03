using System;

namespace _231103_CS_параметры
{
    class Program
    {
        // ========================  ref и out =========================================
        static void Func(out int i, ref int[] a) // ref - означает передачу по ссылке (используется для передачи больших параметров)
        {
            Console.WriteLine("Массив до изменения: ");
            foreach(int e in a)
                    Console.Write(e.ToString() + " ");
            Console.WriteLine();
            i = 100; // без этой инициализации Func выдаст ошибку
            a = new int[] { 3, 2, 1 };
            Console.WriteLine("Массив после изменения: ");
            foreach (int e in a)
                    Console.Write(e.ToString() + " ");
            Console.WriteLine();
            Console.WriteLine(i);
        }

        void OutRef()
        {
            int b = 15;
            int[] ar = new int[10];
            Console.WriteLine(b);
            Func(out b, ref ar);// ref - означает передачу по ссылке (используется для передачи больших параметров)
            // через out  можно передавать неинициализированные переменные (в отличие от ref)
            Console.WriteLine("После функции:");
            Console.WriteLine(b);
            foreach (int e in ar)
                Console.Write(e.ToString() + " ");
        }

        // =================  params =======================================
        // используется если не хватает перегрузки функции и и спользуется много параметров
        static int Sum(params int[] ar) // без params нужно указывать точное кол-во параметров
        {
            int sum = 0;
            foreach (int e in ar)
            {
                sum += e;
            }
            return sum;
        }
        void Params()
        {
            // Console.WriteLine("Сумма = ", Sum(new int[] { 1,2,3,4,5}).ToString()); //без ключевого слова params
            Console.WriteLine("Сумма = ", Sum(1, 2, 3, 4, 5).ToString());
        }

        // ========================== partial (частичные типы) ============================
        // для разделения кода на отдельные файлы

        void PartialMethods()
        {
            // создать два отдельных класса в отдельных файлах со своими методами
            // Class1, Class2
            MyClass.MethodTest();
            MyClass.MethodDemo();
        }

        // ============================ аксессоры Get Set =================================
        // get set обычно public  или protected
        // менять модификаторы доступа у обоих аксессоров запрещено (либо у одного или у другого)
        // get без set делает получение дроступа к свойствам только для чтения, т.е. их нельзя перезаписать
        // любое свойство может быть статическим
        class Example
        {
            int _num;// приватное поле

            public int Num // публичное поле для доступа к приватному полю _num
            {
                get { return _num; } //здесь любой код, но обязателен RETURN!
                set { _num = value; }//сюда неявно передается value - обязательное!, код любой value обязательно

                //пример проверки значения:
                /*set {
                    if (value < 0)
                        value = 0;
                    if (value > 120)
                        value = 120;
                    _num = value;
                }
                */
            }
            /* вариант записи через сеттеры и геттеры:
            public void SetNum(int num)
            {
                _num = num;
            }
            public int GetNum()
            {
                return _num;
            }
            */
        }

        void SetGet()
        {
            Example e = new Example();
            Console.Write("Введите целое число: ");
            e.Num = int.Parse(Console.ReadLine());
            Console.Write("Вы ввели: ");
            Console.WriteLine(e.Num);
        }

        // ===================== шаблон propfull =======================================
        // написать propfull, нажать 2 раза Tab, перемещаться Tab'ом
        // 
        // используется для автоматической записии такой конструкции:
        // 
        //    private int myVar;
        //    public int MyProperty
        //  {
        //    get { return myVar; }
        //    set { myVar = value; }
        //  }



        // ====================== модификация объектов ==============================
        // можно инициализировать и public поля
        // числовые значения в get , строчные в set

        class Employee
        {
            private string _firstName;

            public string FirstName
            {
                get { return _firstName != null ? _firstName : "Не задано"; }
                set { _firstName = value; }
            }

            private string _secondName;

            public string SecondNameName
            {
                get { return _secondName != null ? _secondName : "Не задано"; }
                set { _secondName = value; }
            }

            public string ToString()
            {
                return $"Имя: {_firstName}\n Фамилия: {_secondName}";
            }

        }

        void Modify()
        {
            Employee emp1 = new Employee
            {
                FirstName = "Дмитрий",
                SecondNameName = "Сидоров"
            };

            Employee emp2 = new Employee
            {
                FirstName = "Валерий",

            };
            Console.WriteLine(emp1.ToString());
            Console.WriteLine(emp2.ToString());

        }

        // =================== автоматические свойства ========================

        /*
          public static int StInt
         {
            get;set;
           // можно поставить модификаторы доступа
           // protected get; set
         }
                 

         public string Name
        {
            get;
        }


        // задача стартовое значение (по умолчанию)
         public string Name
        {
            get;
        } = "None";


        set без get указывать нельзя!


        prop + tab + tab      автоматическое свойство set get
        propg  + tab + tab    автоматическое свойство тоько для чтения  
        propfull + tab + tab    автоматическое свойство полностью
         
         */

        // ========================  null operator ====================
        // проверка на null 

        /*Можно так, но так каждый раз не удобно
         * 
          Example e = null;
            if (e != null)
                e.MyDouble = 0.5;

         А можно так:
          Example e = null;
        doiuble? localDouble = e?.MyDouble;



         */
        class Group
        { 
        public string Name { get; set; }
        }
        class Student
        {
            public string FirstName { get; set; } = "No name";
            public string SecondName { get; set; } = "No last name";
            public Group StudentGroup { get; set; }
            public DateTime DateBirth { get; set; }
            public override string ToString()
            {
                return $"Имя: {FirstName}\nФамилия: {SecondName}\n Группа:{StudentGroup}\n Дата рождения: {DateBirth} ";
            }




        }


        static void Main(string[] args)
        {
            Student s1 = null;
            DateTime? date = s1?.DateBirth;
            Console.WriteLine($"Дата рождения: {date}");

            Student s2 = new Student();
            string groupName = s2?.StudentGroup?.Name;
            Console.WriteLine($"Группа: {groupName}");

            Student s3 = new Student { StudentGroup = new Group { Name = "PRO1"} };
            groupName = s3?.StudentGroup?.Name;
            Console.WriteLine($"Группа: {groupName}");


        }
    }
}
