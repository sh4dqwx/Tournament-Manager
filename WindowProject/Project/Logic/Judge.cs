using System;

namespace Project.Logic
{
    public class Judge:Person
    {
        public Judge(string name, string surname):base(name,surname)
        { }
        public Judge(Judge copy) : base(copy)
        { }
    }
}
