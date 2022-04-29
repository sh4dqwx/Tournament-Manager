using System;

namespace Project.Registrations
{
    public class Judge
    {
        private string name, surname;
        public Judge()
        {
            name = "";
            surname = "";
        }
        public Judge(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public Judge(Judge judge)
        {
            name = judge.name;
            surname = judge.surname;
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
