using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Exceptions
{
    public class NotEnoughException : Exception
    {
        public NotEnoughException(string msg): base(msg) { }
    }
}
