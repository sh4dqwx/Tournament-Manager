﻿using System;

namespace Project.Logic
{
    public class Judge:Person
    {
        public Judge(string name, string surname):base(name,surname)
        { }
        public Judge(Judge copy) : base(copy)
        { }
        public override bool Equals(object obj)
        {
            if (!(obj is Judge)) return false;
            Judge judge = (Judge)obj;
            return name.Equals(judge.name) && surname.Equals(judge.surname);
        }
    }
}
