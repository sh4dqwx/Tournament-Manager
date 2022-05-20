using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Interface
{
    public class TournamentDisplay
    {
        public TournamentDisplay(string name, int category)
        {
            Name = name;
            switch (category)
            {
                case 0:
                    Category = "Siatkówka";
                    break;
                case 1:
                    Category = "Przeciąganie liny";
                    break;
                case 2:
                    Category = "Dwa ognie";
                    break;
            }
        }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
