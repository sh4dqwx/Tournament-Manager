using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Exceptions
{
    public class ExistsException : Exception
    {
        private string name, category;
        public ExistsException(string name, string category): base()
        {
            this.name = name;
            this.category = category;
        }

        public string getName()
        {
            return name;
        }
        public string getCategory()
        {
            return category;
        }
    }
}
