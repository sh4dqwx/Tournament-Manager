using System;

namespace Project.Exceptions
{
    public class TeamException : Exception
    {
        protected string name;

        public TeamException(string name) : base()
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }
    }
}
