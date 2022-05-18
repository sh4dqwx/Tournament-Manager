using System.Collections.Generic;

namespace Project.Logic
{
    public class Program
    {
        private List<Tournament> tournaments;

        public Program()
        {
            tournaments = new List<Tournament>();
        }

        public Tournament[] getTournaments()
        {
            return tournaments.ToArray();
        }
        public void addTournament(Tournament tournament)
        {
            tournaments.Add(tournament);
        }
        public void removeTournament(Tournament tournament)
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
