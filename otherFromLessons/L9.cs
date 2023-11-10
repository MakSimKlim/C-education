using System;
using static System.Console;

namespace L9
{
    public abstract class Human
    {
        string firstName;
        string lastName;
        DateTime birthDate;

        public Human()
        { }

        public Human(string fName, string lName)
        {
            firstName = fName;
            lastName = lName;
        }

        public Human(string fName, string lName, DateTime date) : this(fName, lName)
        {
            birthDate = date;
        }

        public override string ToString()
        {
            return $"Фамилия: {lastName}\n" +
                $"Имя: {firstName}\n" +
                $"Дата рождения: {birthDate.ToShortDateString()}\n";
        }

        public abstract void Think();
        public abstract void Introduce();
    }

    public abstract class Employee : Human
    {
        double _salary;

        public Employee(string fName, string lName) : base(fName, lName)
        { }

        public Employee(string fName, string lName, double salary) : base(fName, lName)
        {
            _salary = salary;
        }

        public Employee(string fName, string lName, DateTime date, double salary)
            : base(fName, lName, date)
        {
            _salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() + $"Зарплата: {_salary} руб.\n";
        }

        public override void Think()
        {
            Write("Я думаю...");
        }
    }

    class Manager : Employee
    {
        string _sphere;
        public Manager(string fName, string lName, DateTime date, double salary, string sphere)
            : base(fName, lName, date, salary)
        {
            _sphere = sphere;
        }

        public override void Introduce()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + $"Менеджер. Сфера деятельности: {_sphere}.\n";
        }

        public override void Think()
        {
            base.Think();
            WriteLine(" о сотрудниках.");
        }
    }

    class Researcher : Employee
    {
        string _field;
        public Researcher(string fName, string lName, DateTime date, double salary, string field)
            : base(fName, lName, date, salary)
        {
            _field = field;
        }

        public override void Introduce()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + $"Исследователь. Сфера деятельности: {_field}.\n";
        }

        public override void Think()
        {
            base.Think();
            WriteLine(" об исследовании.");
        }
    }

    class Developer : Employee
    {
        string _qualification;
        public Developer(string fName, string lName, DateTime date, double salary, string qualification)
            : base(fName, lName, date, salary)
        {
            _qualification = qualification;
        }

        public override void Introduce()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + $"Разработчик. Квалификация: {_qualification}.\n";
        }

        public override void Think()
        {
            base.Think();
            WriteLine(" о проекте.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee manager = new Manager("Иван", "Иванов", new DateTime(1991, 3, 14), 60000, "продукты питания");
            Employee[] emps = {
                  manager,
                  new Researcher("Сергей", "Лукин", new DateTime(1968, 3, 15), 60000, "История"),
                  new Developer("Ярослав", "Кузнецов", new DateTime(1990, 8, 4), 120000, "сеньор С++")
            };

            foreach(Employee emp in emps)
            {
                WriteLine(emp);
            }

            object o = new object();
            object b = o;
            WriteLine(o.Equals(b));
            WriteLine(object.Equals(o, b));
            //Finalize - вызывается перед тем, как объект будет уничтожен сборщиком мусора.
            WriteLine(o.GetHashCode());
            Type t = o.GetType();
            WriteLine(t);
            int a = 256;
            int c = a;
            WriteLine(a.GetType());
            WriteLine(o.ToString());
            WriteLine(a.ToString());
            WriteLine(object.ReferenceEquals(o, b));
            WriteLine(object.ReferenceEquals(a, c));
            WriteLine(object.ReferenceEquals(manager, emps[0]));
        }
    }
}


/*
 * Абстрактный класс Геометрическая Фигура. 
 * У фигуры есть методы Area (Площадь) и Circumference (Периметр).
 * Разработать классы-наследники: Треугольник, Прямоугольник, Круг.
 * Добавить поля и конструкторы, которые однозначно определяют эти объекты.
 * Реализовать методы Геометрической Фигуры.
 */