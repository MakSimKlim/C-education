using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Delegate;
using static System.MulticastDelegate;


/*
Делегаты представляют такие объекты, которые указывают на методы. 
То есть делегаты - это указатели на методы и с помощью делегатов мы можем вызвать данные методы.
delegate void Message();

Используются для реализации событий

 */

namespace _231120_CS_Делегаты
{
    // System.Delegate
    /*
     * object Clone()
     * Combine(Delegate, Delegate)
     * CreateDelegate(Type, MethodInfo)
     * object DynamicInvoke(params object[] atgs)
     * Delegate[] GetInvocationList()
     * int GetHashCode()
     * Delegate Remove(Delegate, Delegate)
     * bool operator ==
     * bool operator !=
     * MethodInfo Method {get;}
     * object Target {get;}
     * 
     */
    //System.MulticastDelegate

    //объявление делегата
    /*
     [access modifer] delegate <type> <NAME> (<parameters>)
     */
    public delegate int IntToDoubleDelegate(double d);
    public delegate void Voidlegate(int i);
    delegate void VoidDelegate(int i);

    class Delegs
    {
        delegate void VoidDelegate(int i);
    }

    public delegate double CalcDelegate(double x, double y);// класс делегат
    class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Substract(double x, double y)
        {
            return x - y;
        }
        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            if(y!=0)
            return x / y;
            throw new ExecutionEngineException("oshibka");
        }
        static void Example()
        {
            Calculator calc = new Calculator();
            Write("Введите выражение");
            string expression = ReadLine();
            char sign = ' ';
            foreach (char с in expression)
            {
                if(с == "+"|| с == "-" || с == "*" || с == "/")
                {
                    sign = с;
                    break;
                        
                }
            
            }
            try
            {
                string[] numbers = expression.Split(sign);
                CalcDelegate op = null;
                switch (sign)
                {
                    case '+':
                        op = new CalcDelegate(calc.Add);// можно написать так: calc.Add
                        break;
                    case '-':
                        op = new CalcDelegate(calc.Substract);// можно написать так: calc.Substract
                        break;
                    case '/':
                        op = new CalcDelegate(calc.Divide);// можно написать так: calc.Divide
                        break;
                    case '*':
                        op = new CalcDelegate(calc.Multiply);// можно написать так: calc.Multiply
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                WriteLine($"Result {op(double.Parse(numbers[0]), double.Parse(numbers[1]))}")
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

    }

    class Car
    {
        public void Honk()
        {
            WriteLine("Honk honk");
        }
    
    }
    class Cat
    {
        public void Meow()
        {
            WriteLine("Meow meow");
        }

    }

    class Guitar
    {
        public void Play()
        {
            WriteLine("Bring bring");
        }

    }
    delegate void Sound();
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            CalcDelegate delAll = null;
            delAll += calc.Add;
            delAll += calc.Divide;
            delAll += calc.Multiply;
            delAll += calc.Substract;

            //вызов одной функции
            double res = delAll(20, 3);
            WriteLine(res);

            // вызов списка всех методов
            foreach (CalcDelegate item in delAll.GetInvocationList())
            {
                try
                {
                    WriteLine($"Res: {item(20, 3)}");
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);

                }
            
            }

            Car car = new Car();
            Cat cat = new Cat();
            Guitar guitar = new Guitar();
            Sound sD = null;
            sD += car.Honk;
            sD += cat.Meow;
            sD += guitar.Play;
            sD();

        }
    }
}
