using System.Collections.Generic;

namespace Project
{
    public class Program
    {
        private List<string> tournaments;

        public Program()
        {
            tournaments = new List<string>();
        }

        public string[] getTournaments()
        {
            return tournaments.ToArray();
        }
        public void addTournament(string tournament)
        {
            tournaments.Add(tournament);
        }
        public void removeTournament(string tournament)
        {
            tournaments.Remove(tournament);
        }
        public void save(string fileName)
        {
            
        }
        public void load(string fileName)
        {

        }
    }
}
