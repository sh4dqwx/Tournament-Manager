using System;
using System.IO;
using System.Collections.Generic;
using Project.Logic.Tournaments;
using Project.Interface;

namespace Project.Logic
{
    public class Program
    {
        private List<Tournament> tournaments;
        private void clear()
        {
            tournaments.Clear();
        }

        public Program()
        {
            tournaments = new List<Tournament>();
        }
        public Tournament newTournament(string TName, int TCategory)
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

        public TournamentDisplay[] getTournamentList()
        {
            TournamentDisplay[] toSend = new TournamentDisplay[tournaments.Count];
            for(int i = 0; i < tournaments.Count; i++)
            {
                toSend[i] = new TournamentDisplay(tournaments[i].getName(), tournaments[i].getCategory());
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
        public void removeTournament(Tournament T)
        {
            tournaments.Remove(T);
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
                        tmp = newTournament(dane[1], Convert.ToInt32(dane[2]));
                        break;
                    case "t":
                        tmp.loadTeams(dane);
                        break;
                    case "j":
                        tmp.loadJudges(dane);
                        break;
                }
            }
            addTournament(tmp);
            loadStream.Close();
        }
    }
}
