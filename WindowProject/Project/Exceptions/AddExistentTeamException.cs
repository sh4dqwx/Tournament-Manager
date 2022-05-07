using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Exceptions
{
    public class AddExistentTeamException : Exception
    {
        private string teamName;

        public AddExistentTeamException() { }
        public AddExistentTeamException(string msg, string teamName) : base(msg)
        {
            this.teamName = teamName;
        }
    }
}
