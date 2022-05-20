using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Logic.Registrations
{
    public abstract class Person
    {
        protected string name, surname;
        public Person(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public string getName()
        {
            return name;
        }
        public string getSurname()
        {
            return surname;
        }
        public override string ToString()
        {
            return $"{name}-{surname}";
        }
    }
}
