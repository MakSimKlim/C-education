using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

// yield

namespace _231120_CS_итераторы
{
    class Program
    {
        class Student
        { 
        public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDay { get; set; }

            public override string ToString()
            {
                return $"{LastName}\n {FirstName}\n {BirthDay}";
            }

        }

        class Group
        {
            public string ID { get; set; }
            List<Student> _group = new List<Student>


            new Student{
                  FirstName = "John",
                  LastName = "Leman",
                  BirthDay = new DateTime(1996,11,30)
                };
                

        };

    public IEnumerator<Student> GetEnumerator()
    {
        for (int i = 0; i < _group.Count; i++)
        {
            yield return _group[i];
        }
    };

            }


        static void Main(string[] args)
        {
           Group g = new Group();
           foreach

        }
    }
}
