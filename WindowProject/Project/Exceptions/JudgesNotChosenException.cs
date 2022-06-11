using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Exceptions
{
    public class JudgesNotChosenException : Exception
    {
        public JudgesNotChosenException(string msg): base(msg) { }
    }
}
