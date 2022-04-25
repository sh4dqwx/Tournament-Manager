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
            List<Team> toSend = new List<Team>();
            teams.ForEach(team => toSend.Add(new Team(team)));
            return toSend;
        }

        public List<Judge> getJudges()
        {
            List<Judge> toSend = new List<Judge>();
            judges.ForEach(judge => toSend.Add(new Judge(judge)));
            return toSend;
        }

        public void clearTeams()
        {
            teams.Clear();
        }

        public void clearJudges()
        {
            judges.Clear();
        }

        public void showResults()
        {
            teams.ForEach(team => Console.WriteLine(team.getName() + " " + team.getScore()));
            Console.WriteLine();
        }
    }
}
