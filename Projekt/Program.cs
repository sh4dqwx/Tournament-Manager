using System;

namespace Projekt
{
    public class Projekt
    {
        public static void Main()
        {
            Volleyball volleyball = new Volleyball();
            volleyball.addTeam(new Team("Drużyna 1"));
            volleyball.addTeam(new Team("Drużyna 2"));
            volleyball.addTeam(new Team("Drużyna 3"));
            volleyball.addTeam(new Team("Drużyna 4"));
            volleyball.addTeam(new Team("Drużyna 5"));
            volleyball.addTeam(new Team("Drużyna 6"));
            volleyball.addTeam(new Team("Drużyna 7"));
            volleyball.addTeam(new Team("Drużyna 8"));
            volleyball.addTeam(new Team("Drużyna 9"));

            volleyball.playElimination();

            volleyball.playFinal();
            
            /*List<Team> teams = volleyball.getTeams();
            teams.ForEach(team => Console.WriteLine(team.getName() + " " + team.getScore().ToString()));*/
        }
    }
}
