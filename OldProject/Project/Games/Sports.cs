using System;
using System.Collections.Generic;
using Project.Registrations;
using Project.Exceptions;

namespace Project.Games
{
    public abstract class Sports
    {
        protected List<Team> teams = new List<Team>();
        protected List<Judge> judges = new List<Judge>();
        protected Random random = new Random();
        protected string results = "";

        public void addTeam(Team team)
        {
            teams.Add(team);
        }

        public void addJudge(Judge judge)
        {
            judges.Add(judge);
        }

        public void removeTeam(Team team)
        {
            teams.Remove(team);
        }

        public void removeJudge(Judge judge)
        {
            judges.Remove(judge);
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

        public string showResults()
        {
            string z = "";
            //teams.ForEach(team => Console.WriteLine(team.getName() + " " + team.getScore()));
            teams.ForEach(team => z += team.getName() + " " + team.getScore()+"\n");
            //Console.WriteLine();
            return z;
        }
    }
}
