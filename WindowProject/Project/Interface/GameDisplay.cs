using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Interface
{
    public class GameDisplay
    {
        public GameDisplay(string team1, string team2, string picture)
        {
            Team1 = team1;
            Team2 = team2;
            Picture = picture;
        }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Picture { get; set; }
    }
}
