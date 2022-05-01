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
        public override bool Equals(object obj)
        {
            if (!(obj is Judge)) return false;
            Judge judge = (Judge)obj;
            return name.Equals(judge.name) && surname.Equals(judge.surname);
        }
    }
}
