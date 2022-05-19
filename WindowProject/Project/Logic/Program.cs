using System.IO;
using System.Collections.Generic;

namespace Project.Logic
{
    public class Program
    {
        private List<Tournament> tournaments;
        private Tournament newTournament(string TName, int TCategory)
        {
            Tournament tmp = null;
            switch (TCategory)
            {
                case 0:
                    tmp = new Volleyball(TName);
                    break;
                case 1:
                    tmp = new TugOfWar(TName);
                    break;
                case 2:
                    tmp = new Dodgeball(TName);
                    break;
            }
            return tmp;
        }
        private void clear()
        {
            tournaments.Clear();
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

        public void addTournament(Tournament T)
        {
            tournaments.Add(T);
        }
        public void addTournament(string TName, int TCategory)
        {
            Tournament tmp = newTournament(TName, TCategory);
            tournaments.Add(tmp);
        }
        public void removeTournament(string TName, int TCategory)
        {
            Tournament tmp = newTournament(TName, TCategory);
            tournaments.Remove(tmp);
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
            Tournament tmp = null;
            while(!loadStream.EndOfStream)
            {
                string[] dane = loadStream.ReadLine().Split(',');
                switch (dane[0])
                {
                    case "T":
                        if (tmp is Tournament) addTournament(tmp);
                        break;
                    case "t":

                        break;
                    case "j":

                        break;
                }
            }
            loadStream.Close();
        }
    }
}
