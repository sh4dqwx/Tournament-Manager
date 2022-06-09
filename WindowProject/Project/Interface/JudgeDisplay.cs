using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Logic.Registrations;

namespace Project.Interface
{
    public class JudgeDisplay
    {
        public JudgeDisplay(Judge j)
        {
            Name = j.getName();
            Surname = j.getSurname();
        }

        public string Name { get; }
        public string Surname { get; }
    }
}
