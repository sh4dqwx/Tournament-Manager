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
            Tournament[] tmpTournaments = tournaments.ToArray();
            string[] tournamentsString = new string[tmpTournaments.Length];
            for(int i = 0; i < tmpTournaments.Length; i++)
            {
                tournamentsString[i] = tmpTournaments[i].getName();
                if (tmpTournaments[i] is Volleyball) tournamentsString[i] += " - Siatkówka";
                else if (tmpTournaments[i] is TugOfWar) tournamentsString[i] += " - Przeciąganie liny";
                else if (tmpTournaments[i] is Dodgeball) tournamentsString[i] += " - Dwa ognie";
            }
            return tournamentsString;
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
