using System;

namespace Project.Exceptions
{
    public class JudgeException : Exception
    {
        protected string name, surname;

        public JudgeException(string name, string surname): base()
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
    }
}
