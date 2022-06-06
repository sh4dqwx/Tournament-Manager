using System;

namespace Project.Exceptions
{
    public class NotEnoughJudgesException : Exception
    {
        private string msg;
        public NotEnoughJudgesException(string msg): base()
        {
            this.msg = msg;
        }

        public string getMessage()
        {
            return msg;
        }
    }
}
