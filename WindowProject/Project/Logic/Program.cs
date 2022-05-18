using System.IO;
using System.Collections.Generic;

namespace Project.Logic
{
    public class Program
    {
        private List<Tournament> tournaments;
        private void clear()
        {

        }
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

        public void addTournament(string TName, int TCategory)
        {
            Tournament tmp;
            switch (TCategory)
            {
                case 0:
                    tmp = new Volleyball(TName);
                    tournaments.Add(tmp);
                    break;
                case 1:
                    tmp = new TugOfWar(TName);
                    tournaments.Add(tmp);
                    break;
                case 2:
                    tmp = new Dodgeball(TName);
                    tournaments.Add(tmp);
                    break;
            }
        }
        public void removeTournament(string TName, int TCategory)
        {
            Tournament tmp;
            switch (TCategory)
            {
                case 0:
                    tmp = new Volleyball(TName);
                    tournaments.Remove(tmp);
                    break;
                case 1:
                    tmp = new TugOfWar(TName);
                    tournaments.Remove(tmp);
                    break;
                case 2:
                    tmp = new Dodgeball(TName);
                    tournaments.Remove(tmp);
                    break;
            }
        }
        public void save(string fileName)
        {
            StreamWriter saveStream = new StreamWriter(fileName);
            foreach(Tournament T in tournaments)
            {
                saveStream.Write(T.ToString());
            }
            saveStream.Close();
        }
        public void load(string fileName)
        {
            clear();
            StreamReader loadStream = new StreamReader(fileName);

            loadStream.Close();
        }
    }
}
