using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Exceptions
{
    public class RemoveNonExistentTeamException : Exception
    {
        private string teamName;

        public RemoveNonExistentTeamException() { }
        public RemoveNonExistentTeamException(string msg, string teamName) : base(msg)
        {
            this.teamName = teamName;
        }
    }
}
