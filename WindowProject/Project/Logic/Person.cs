using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Logic
{
    public abstract class Person
    {
        private string name, surname;
        public Person(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public Person(Person copy)
        {
            this.name = copy.name;
            this.surname = copy.surname;
        }

        public string getName()
        {
            return name;
        }
        public string getSurname()
        {
            return surname;
        }
    }
}
