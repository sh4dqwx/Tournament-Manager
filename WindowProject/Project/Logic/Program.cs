using System.IO;
using System.Collections.Generic;

namespace Project.Logic
{
    public class Program
    {
        private List<Tournament> tournaments;
        private Tournament newTournament(string TName, string TCategory)
        {
            Tournament tmp = null;
            switch (TCategory)
            {
                case "Siatkówka":
                    tmp = new Volleyball(TName);
                    break;
                case "Przeciąganie liny":
                    tmp = new TugOfWar(TName);
                    break;
                case "Dwa ognie":
                    tmp = new Dodgeball(TName);
                    break;
            }
            return tmp;
        }
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

        public void addTournament(Tournament T)
        {
            tournaments.Add(T);
        }
        public void addTournament(string TName, string TCategory)
        {
            Tournament tmp = newTournament(TName, TCategory);
            tournaments.Add(tmp);
        }
        public void removeTournament(string TName, string TCategory)
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
                        tmp = newTournament(dane[1], dane[2]);
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
