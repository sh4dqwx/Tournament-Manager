using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Tug_of_war: Sports
    {
        public Tug_of_war()
        {

        }
        public void playElimination()
        {
            Console.WriteLine("Rozpoczynamy turniej przeciagania liny");
            Console.WriteLine("---------------------------------------------------------------");
            Random random = new Random();
            teams.ForEach(team => team.resetScore());

            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    if (random.NextDouble() >= 0.5)
                    {
                        Console.WriteLine(teams[i].getName() + " wygrywa z " + teams[j].getName());
                        teams[i].addScore();
                    }
                    else
                    {
                        Console.WriteLine(teams[j].getName() + " wygrywa z " + teams[i].getName());
                        teams[j].addScore();
                    }
                }
            }
            Console.WriteLine("---------------------------------------------------------------");
            teams = teams.OrderBy(team => team.getScore()).ToList();
            teams.Reverse();
            Console.WriteLine("Wyniki wszystkich drużyn:");
            showResults();

           
            if (teams[3].getScore() != teams[4].getScore())
            {
                teams.RemoveRange(4, teams.Count - 4);
                showResults();
                return;
            }

           
            List<Team> errorTeams = teams.FindAll(team => team.getScore() == teams[3].getScore());
            int qualified = teams.Where(team => team.getScore() > teams[3].getScore()).Count();
            teams.RemoveRange(qualified, teams.Count - qualified);

        
            Console.WriteLine("Lista zakwalifikowanych:");
            showResults();
            Console.WriteLine("\nLista z tą samą liczbą punktów:");
            errorTeams.ForEach(team => Console.WriteLine(team.getName() + " " + team.getScore()));

        
            for (int i = 0; i < 4 - qualified; i++)
            {
                int chosen = random.Next() % errorTeams.Count;
             
                teams.Add(errorTeams[chosen]);
                errorTeams.RemoveAt(chosen);
            }

            showResults();
        }
    }
}
