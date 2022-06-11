using System;

namespace Project.Exceptions
{
    public class NotEnoughTeamsException : Exception
    {
        public NotEnoughTeamsException(string msg): base(msg) { }
    }
}
