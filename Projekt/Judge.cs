using System;

namespace Projekt
{
    public class Judge
    {
        private string name, surname, category;
        public Judge()
        {
            name = "";
            surname = "";
            category = "";
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
