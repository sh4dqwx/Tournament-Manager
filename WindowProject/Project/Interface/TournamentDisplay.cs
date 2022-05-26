using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Logic.Tournaments;

namespace Project.Interface
{
    public class TournamentDisplay
    {
        public TournamentDisplay(Tournament T)
        {
            Name = T.getName();
            Category = T.getCategory();
        }

        public string Name { get; }
        public string Category { get; }
    }
}
