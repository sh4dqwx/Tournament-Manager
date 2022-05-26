using Project.Logic.Registrations;
using System;
using System.Collections.Generic;
using Project.Interface;
using Project.Exceptions;

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

        public void addTeam(Team t)
        {
            if (teams.Contains(t)) throw new TeamExistsException(t.getName());
            teams.Add(t);
        }
        public void addJudge(Judge j)
        {
            if (judges.Contains(j)) throw new JudgeExistsException(j.getName(), j.getSurname());
            judges.Add(j);
        }
        public void removeTeam(Team t)
        {
            if(!teams.Contains(t)) throw new TeamNotExistsException(t.getName());
            teams.Remove(t);
        }
        public void removeJudge(Judge j)
        {
            if (!judges.Contains(j)) throw new JudgeNotExistsException(j.getName(), j.getSurname());
            judges.Remove(j);
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
        public GameDisplay[] getGames()
        {
            GameDisplay[] toSend = new GameDisplay[games.Count];
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].getWinner() is null) toSend[i] = new GameDisplay(games[i].getFirstTeam().getName(), games[i].getSecondTeam().getName(), "");
                else toSend[i] = new GameDisplay(games[i].getFirstTeam().getName(), games[i].getSecondTeam().getName(), "/gameFinished.png");
            }
            return toSend;
        }
        public ResultsDisplay[] getResults()
        {
            ResultsDisplay[] toSend = new ResultsDisplay[teams.Count];
            for(int i=0;i<teams.Count;i++)
            {
                toSend[i] = new ResultsDisplay(teams[i].getName());
            }
            return toSend;
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

        public void changeState()
        {
            state++;
        }

        public virtual string getCategory()
        {
            return "";
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

        public void loadTeams(string[] dane)
        {
            List<Player> players = new List<Player>();
            for (int i = 2; i < dane.Length; i++) { players.Add(new Player(dane[i].Split('-')[0], dane[i].Split('-')[1])); }
            teams.Add(new Team(players.ToArray(), dane[1]));
        }
        public void loadJudges(string[] dane)
        {
            judges.Add(new Judge(dane[1].Split('-')[0], dane[1].Split('-')[1]));
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
