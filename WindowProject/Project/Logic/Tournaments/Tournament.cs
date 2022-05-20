using Project.Logic.Registrations;
using System;
using System.Collections.Generic;

namespace Project.Logic.Tournaments
{
    public abstract class Tournament
    {
        protected List<Team> teams = new List<Team>();
        protected List<Judge> judges = new List<Judge>();
        protected List<Game> games = new List<Game>();
        protected string name = "";
        protected int state = 1;

        public Tournament(string name)
        {
            this.name = name;
        }

        public void addTeam(Team team)
        {
            teams.Add(team);
        }
        public void addTeam(string[] dane)
        {
            List<Player> players = new List<Player>();
            for (int i = 2; i < dane.Length; i++) { players.Add(new Player(dane[i].Split('-')[0], dane[i].Split('-')[1])); }
            teams.Add(new Team(players, dane[1]));
        }

        public void addJudge(Judge judge)
        {
            judges.Add(judge);
        }
        public void addJudge(string[] dane)
        {
            judges.Add(new Judge(dane[1].Split('-')[0], dane[1].Split('-')[1]));
        }

        public string[] getJudges()
        {
            string[] result = new string[judges.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = judges[i].getName() + " " + judges[i].getSurname();
            }
            return result;
        }
        public string[] getTeams()
        {
            string[] result = new string[teams.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = teams[i].getName();
            }
            return result;
        }
        public string[] getCaptain()
        {
            string[] results = new string[teams.Count];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = teams[i].getCaptain();
            }
            return results;
        }
        public void removeTeam(Team team)
        {
            teams.Remove(team);
        }

        public void removeJudge(Judge judge)
        {
            judges.Remove(judge);
        }

        public void changeState()
        {
            state++;
        }

        public virtual int getCategory()
        {
            return -1;
        }
        public string getName()
        {
            return name;
        }
        public int getState()
        {
            return state;
        }

        public string showResults()
        {
            string result = "";
            foreach (Team team in teams)
            {
                result += team.ToString();
            }
            return result;
        }
        public override string ToString()
        {
            string toSave = $"T,{name},{getCategory()}\n";
            foreach (Team t in teams)
            {
                toSave += $"{t.ToString()}\n";
            }
            foreach (Judge j in judges)
            {
                toSave += $"j,{j.ToString()}\n";
            }
            return toSave;
        }
    }
}
