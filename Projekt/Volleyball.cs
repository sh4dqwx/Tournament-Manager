using System;
using System.Linq;

namespace Projekt
{
    public class Volleyball: Sports
    {
        public Volleyball()
        {
            
        }
        public void playElimination()
        {
            Random random = new Random();
            teams.ForEach(team => team.resetScore());

            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    if (random.NextDouble() >= 0.5) teams[i].addScore();
                    else teams[j].addScore();
                }
            }
            teams = teams.OrderBy(team => team.getScore()).ToList();
            teams.Reverse();
            showResults();

            //Jeżeli nie ma konfliktu, usuń przegrane drużyny i wyjdź
            if (teams[3].getScore() != teams[4].getScore())
            {
                teams.RemoveRange(4, teams.Count - 4);
                showResults();
                return;
            }
            
            //Jeżeli jest konflikt, wybierz drużyny do wylosowania, usuń przegrane i konfliktowe drużyny
            List<Team> errorTeams = teams.FindAll(team => team.getScore() == teams[3].getScore());
            int qualified = teams.Where(team => team.getScore() > teams[3].getScore()).Count();
            teams.RemoveRange(qualified, teams.Count - qualified);

            //Debugowanie (do usunięcia później)
            Console.WriteLine("Lista zakwalifikowanych:");
            showResults();
            Console.WriteLine("\nLista z tą samą liczbą punktów:");
            errorTeams.ForEach(team => Console.WriteLine(team.getName() + " " + team.getScore()));

            //Dodaj wylosowane drużyny
            for (int i = 0; i < 4 - qualified; i++)
            {
                int chosen = random.Next() % errorTeams.Count;
                //ewentualny komentarz kogo wybrało
                teams.Add(errorTeams[chosen]);
                errorTeams.RemoveAt(chosen);
            }

            showResults();
        }
    }
}
