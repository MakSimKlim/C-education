using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop

{
    class Shop
    {
        
        interface IEmployee
        { }
        interface IManager
        { }
        interface IWorker
        { }
        class Person
        { 
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public override string ToString()
            {
                return $"{ FirstName}+{ LastName }+{ BirthDay}";
            }
        }

    }

    abstract class Employee : Person
    { 
    
    }
}
