using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Interface
{
    public class ResultsDisplay
    {
        public ResultsDisplay(string team)
        {
            Team = team;
        }
        public string Team { get; set; }
    }
}
