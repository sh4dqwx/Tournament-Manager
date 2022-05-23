using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Interface
{
    public class TournamentDisplay
    {
        public TournamentDisplay(string name, string category)
        {
            Name = name;
            Category = category;
        }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
