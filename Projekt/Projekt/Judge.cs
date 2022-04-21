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
        //konstruktor pusty, nie będzie zwracał żadnej wartości
        public Judge()
        {
            
        }
        //konstruktor tworzenia sędziego
        public Judge(string name, string surname, string category)
        {
            this.name = name;
            this.surname = surname;
            this.category = category;
        }
        //konstruktor kopiujący
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
