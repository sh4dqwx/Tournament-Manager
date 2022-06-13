using Project.Logic.Registrations;
using System;
using System.Linq;
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
        protected Random random;
        protected string name = "";
        protected int state = 1;

        public Tournament(string name, Random random)
        {
            this.name = name;
            this.random = random;
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

        public Judge getJudge(int i)
        {
            return judges[i];
        }
        public string[] getJudgeString()
        {
            string[] result = new string[judges.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = judges[i].getName() + " " + judges[i].getSurname();
            }
            return result;
        }
        public JudgeDisplay[] getJudgeList()
        {
            JudgeDisplay[] result = new JudgeDisplay[judges.Count()];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = new JudgeDisplay(getJudge(i));
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
        public int getNumberofTeams()
        {
            return teams.Count;
        }
        public Team getTeam(int index)
        {
            return teams[index];
        }
        public int TeamsNumber()
        {
            return teams.Count;
        }
        public GameDisplay[] getGameList()
        {
            GameDisplay[] toSend = new GameDisplay[games.Count];
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].getWinner() is null) toSend[i] = new GameDisplay(games[i].getFirstTeam().getName(), games[i].getSecondTeam().getName(), "");
                else toSend[i] = new GameDisplay(games[i].getFirstTeam().getName(), games[i].getSecondTeam().getName(), "/gameFinished.png");
            }
            return toSend;
        }
        public Game getGame(int i)
        {
            return games[i];
        }
        public virtual string getBackground()
        {
            return "";
        }

        public virtual void playRandom()
        {
            foreach (Game game in games)
            {
                if (game.getWinner() is null)
                {
                    game.playRandom();
                    game.setJudges(judges[random.Next(judges.Count)]);
                }
            }
        }
        public bool isAllPlayed()
        {
            foreach (Game game in games)
            {
                if (game.getWinner() is null) return false;
            }
            return true;
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

        public void prepareElimination()
        {
            if (teams.Count < 5) throw new NotEnoughTeamsException("Do rozpoczęcia turnieju potrzeba co najmniej 5 drużyn");
            if (this is Volleyball && judges.Count < 3) throw new NotEnoughJudgesException("Do rozpoczęcia turnieju potrzeba co najmniej 3 sędziów");
            if (judges.Count < 1) throw new NotEnoughJudgesException("Do rozpoczęcia turnieju potrzeba co najmniej 1 sędziego");
            state = 2;
            for (int i = 0; i < teams.Count; i++)
                for (int j = i + 1; j < teams.Count; j++)
                    games.Add(new Game(teams[i], teams[j], random));
        }
        public void prepareSemiFinal()
        {
            state = 3;
            games.Clear();
            teams = teams.OrderBy(team => team.getWin()).ToList();
            teams.Reverse();
            for(int i = 0; i<teams.Count;i++)
            {
                teams[i].setPlace(i+1);
            }
            games.Add(new Game(teams[0], teams[1], random));
            games.Add(new Game(teams[2], teams[3], random));
        }
        public void prepareFinal()
        {
            state = 4;
            games[0].getWinner().setPlace(1);
            games[0].getLoser().setPlace(3);
            games[1].getWinner().setPlace(2);
            games[1].getLoser().setPlace(4);
            Game finalGame = new Game(games[0].getWinner(), games[1].getWinner(), random);
            games.Clear();
            games.Add(finalGame);
        }
        public void finalResult()
        {
            state = 5;
            games[0].getWinner().setPlace(1);
            games[0].getLoser().setPlace(2);
            teams = teams.OrderBy(team => team.getPlace()).ToList();
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
