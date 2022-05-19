using System;
using System.Collections.Generic;

namespace Project.Logic
{
    public class Team
    {
        private List<Player> players = new List<Player>();
        private string name;
        private int win = 0, lose = 0;
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
        public string[] getPlayers()
        {
            string[] toSend = new string[players.Count];
            for(int i = 0; i < toSend.Length; i++)
            {
                toSend[i] = players[i].getName() +" "+ players[i].getSurname();
            }
            return toSend;
        }
        public int getWin()
        {
            return win;
        }
        public int getLost()
        {
            return lose;
        }
        public void addScore(bool result)
        {
            if(result==true)win++;
            else lose++;
        }
        public override string ToString()
        {
            string toSave = $"t,{name},{win},{lose}\n";
            return toSave;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Team)) return false;
            Team team = (Team)obj;
            return players.Equals(team.players) && name.Equals(team.name);
        }
    }
}
