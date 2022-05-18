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

        public Tournament getTournament(int index)
        {
            return tournaments[index];
        }

        public void addTournament(string tName, int tCategory)
        {
            Tournament tmp;
            switch (tCategory)
            {
                case 0:
                    tmp = new Volleyball(tName);
                    tournaments.Add(tmp);
                    break;
                case 1:
                    tmp = new TugOfWar(tName);
                    tournaments.Add(tmp);
                    break;
                case 2:
                    tmp = new Dodgeball(tName);
                    tournaments.Add(tmp);
                    break;
            }
        }
        public void removeTournament(string tName, int tCategory)
        {
            Tournament tmp;
            switch (tCategory)
            {
                case 0:
                    tmp = new Volleyball(tName);
                    tournaments.Remove(tmp);
                    break;
                case 1:
                    tmp = new TugOfWar(tName);
                    tournaments.Remove(tmp);
                    break;
                case 2:
                    tmp = new Dodgeball(tName);
                    tournaments.Remove(tmp);
                    break;
            }
        }
        public void save(string fileName)
        {
            
        }
        public void load(string fileName)
        {

        }
    }
}
