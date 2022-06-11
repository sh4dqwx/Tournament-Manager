using System;
using System.IO;
using System.Collections.Generic;
using Project.Logic.Tournaments;
using Project.Interface;
using Project.Exceptions;

namespace Project.Logic
{
    public class Program
    {
        private List<Tournament> tournaments;
        private Random random;
        private void clear()
        {
            tournaments.Clear();
        }

        public Program()
        {
            tournaments = new List<Tournament>();
            random = new Random();
        }
        public Tournament newTournament(string TName, string TCategory)
        {
            Tournament tmp = null;
            switch (TCategory)
            {
                case "Siatkówka":
                    tmp = new Volleyball(TName, random);
                    break;
                case "Przeciąganie liny":
                    tmp = new TugOfWar(TName, random);
                    break;
                case "Dwa ognie":
                    tmp = new Dodgeball(TName, random);
                    break;
            }
            return tmp;
        }

        public TournamentDisplay[] getTournamentList()
        {
            List<TournamentDisplay> toSend = new List<TournamentDisplay>();
            foreach(Tournament T in tournaments)
            {
                toSend.Add(new TournamentDisplay(T));
            }
            return toSend.ToArray();
        }
        public Tournament getTournament(int i)
        {
            return tournaments[i];
        }

        public void addTournament(Tournament T)
        {
            if (tournaments.Contains(T)) throw new TournamentExistsException(T.getName(), T.getCategory());
            tournaments.Add(T);
        }
        public void removeTournament(Tournament T)
        {
            if(!tournaments.Contains(T)) throw new TournamentNotExistsException(T.getName(), T.getCategory());
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
                        tmp = newTournament(dane[1], dane[2]);
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
