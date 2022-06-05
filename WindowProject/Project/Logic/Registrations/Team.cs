using System;
using System.Collections.Generic;

namespace Project.Logic.Registrations
{
    public class Team
    {
        private List<Player> players;
        private string name;
        private int win = 0, lose = 0,place;

        public Team(string name)
        {
            this.players = new List<Player>();
            this.name = name;
        }
        public Team(Player[] players, string name)
        {
            this.players = new List<Player>(players);
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public string[] getPlayers()
        {
            string[] toSend = new string[players.Count];
            for (int i = 0; i < toSend.Length; i++)
            {
                toSend[i] = players[i].getName() + " " + players[i].getSurname();
            }
            return toSend;
        }
        public string getCaptain()
        {
            return players[0].getName() + " " + players[0].getSurname();
        }
        public int getWin()
        {
            return win;
        }
        public int getLost()
        {
            return lose;
        }
        public void setPlace(int i)
        {
            place = i;
        }
        public int getPlace()
        {
            return place;
        }
        public void addScore(bool result)
        {
            if (result == true) win++;
            else lose++;
        }
        public override string ToString()
        {
            string toSave = $"t,{name}";
            foreach(Player p in players)
            {
                toSave += $",{p.ToString()}";
            }
            return toSave;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Team)) return false;
            Team team = (Team)obj;
            return name.Equals(team.name);
        }
    }
}
