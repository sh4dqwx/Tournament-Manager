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

        public string[] getTournamentList()
        {
            string[] toSend = new string[tournaments.Count];
            for(int i = 0; i < tournaments.Count; i++)
            {
                toSend[i] = tournaments[i].getName();
            }
            return toSend;
        }
        public Tournament getTournament(string tName)
        {
            return tournaments.Find(t => t.getName().Equals(tName));
        }
        public void addTournament(Tournament t)
        {
            tournaments.Add(t);
        }
        public void removeTournament(Tournament t)
        {
            tournaments.Remove(t);
        }
        public void save(string fileName)
        {
            
        }
        public void load(string fileName)
        {

        }
    }
}
