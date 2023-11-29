using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;

/*
Сериализация представляет процесс преобразования какого-либо объекта в поток байтов. 
После преобразования мы можем этот поток байтов или записать на диск или сохранить его временно в памяти. 
А при необходимости можно выполнить обратный процесс - десериализацию, 
то есть получить из потока байтов ранее сохраненный объект.
 */

namespace _231129_CS_Сереализация
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        //public DateTime BirthDate { get; set; }

        int _id;
        [NonSerialized]
        const string Planet = "Earth";

        public Person() { }
        public Person(int number)
        {
            _id = number;
        }
        public override string ToString()
        {
            return $"{_id}: {Name}, {Age} years old from {Planet}";
        }
        //[OnSerializing]
        //private void OnDeserialized(StreamingContext context)
        //{ 
        
        //}

        //public override string ToString()
        //{
        //    return $"{_id}: {Name}, born {BirthDate.ToShortDateString}";
        //}


    }
    class Program
    {
        static void Main(string[] args)
        {
            //Person Jack = 

            List<Person> persons = new List<Person>()
            {
                new Person(2345) { Name = "Jack", Age = 34},
                new Person(3562) { Name = "Bob", Age = 27},
                new Person(1356) { Name = "John", Age = 23},
            };
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Person>));
            try
            {
                using (Stream fstream = File.Create("test.xml"))
                {
                    xmlFormat.Serialize(fstream, persons);
                }
                WriteLine("XmlSerialize ok");
                List<Person> list = null;
                using (Stream fstream = File.OpenRead("test.xml"))
                {
                    list = (List<Person>)xmlFormat.Deserialize(fstream);
                }
                foreach (Person p in list)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}
