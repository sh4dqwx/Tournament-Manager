using System;

namespace Projekt
{
    public abstract class Sports
    {
        protected List<Team> teams = new List<Team>();
        protected List<Judge> judges = new List<Judge>();

        public void addTeam(Team team)
        {
            teams.Add(team);
        }

        public void addJudge(Judge judge)
        {
            judges.Add(judge);
        }

        public List<Team> getTeams()
        {
            return teams;
        }

        public List<Judge> getJudges()
        {
            return judges;
        }

        public void showResults()
        {
            teams.ForEach(team => Console.WriteLine(team.getName() + " " + team.getScore()));
            Console.WriteLine();
        }
    }
}
