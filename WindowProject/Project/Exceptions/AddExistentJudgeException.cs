using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Exceptions
{
    public class AddExistentJudgeException : Exception
    {
        private string judgeName, judgeSurname;

        public AddExistentJudgeException() { }
        public AddExistentJudgeException(string msg, string judgeName, string judgeSurname) : base(msg)
        {
            this.judgeName = judgeName;
            this.judgeSurname = judgeSurname;
        }
    }
}
