using System;

namespace Project.Exceptions
{
    public class NotEnoughTeamsException : Exception
    {
        private string msg;
        public NotEnoughTeamsException(string msg): base()
        {
            this.msg = msg;
        }

        public string getMessage()
        {
            return msg;
        }
    }
}
