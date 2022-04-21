using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Judge
    {
        private string name, surname, category;
        public Judge()
        {
            
        }
        public Judge(string name, string surname, string category)
        {
            this.name = name;
            this.surname = surname;
            this.category = category;
        }
        public Judge(Judge copy)
        {
            name = copy.name;
            surname = copy.surname;
            category = copy.category;
        }
        public string getName()
        {
            return name;
        }
        public string getSurname()
        {
            return surname;
        }
        public string getCategory()
        {
            return category;
        }
    }
}
