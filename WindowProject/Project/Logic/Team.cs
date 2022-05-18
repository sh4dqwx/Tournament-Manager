using System;
using System.Collections.Generic;

namespace Project.Logic
{
    public class Team
    {
        private List<Player> players = new List<Player>();
        private string name;
        private int win, lost;
        public Team(List<Player> players, string name)
        {
            this.players = players;
            this.name = name;
        }
        public Team(Team copy)
        {
            players = copy.players;
            name = copy.name;
        }
        public string getName()
        {
            return name;
        }
        public List<Player> getPlayers()
        {
            return players;
        }
        public int getWin()
        {
            return win;
        }
        public int getLost()
        {
            return lost;
        }
        public void addScore(bool result)
        {
            if(result==true)
            {
                win++;
            }
            else 
            { 
                lost++;
            }
        }
    }
}
