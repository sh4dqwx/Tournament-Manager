using System;

namespace Project.Logic.Registrations
{
    public class Judge : Person
    {
        public Judge(string name, string surname) : base(name, surname) { }

        public override bool Equals(object obj)
        {
            if (!(obj is Judge)) return false;
            Judge judge = (Judge)obj;
            return name.Equals(judge.name) && surname.Equals(judge.surname);
        }
    }
}
