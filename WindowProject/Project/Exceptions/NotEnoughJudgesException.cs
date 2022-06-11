using System;

namespace Project.Exceptions
{
    public class NotEnoughJudgesException : Exception
    {
        public NotEnoughJudgesException(string msg): base(msg) { }
    }
}
