using System;
using System.Collections.Generic;
using System.Linq;
using Project.Registrations;

namespace Project.Games
{
    public class Dodgeball : Sports
    {
        private Random random = new Random();
        public Dodgeball()
        {

        }
        public void playElimination()
        {
            Console.WriteLine("Rozpoczynamy turniej dwóch ogni");
            Console.WriteLine("---------------------------------------------------------------");
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
                Console.WriteLine("Lista drużyn zakwalifikowanych: ");
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
            Console.WriteLine("Lista zakwalifikowanych:");
            showResults();
        }
        public void semi_finals()
        {
            List<Team> final = new List<Team>();
            while (final.Count < 2)
            {
                int firstIndex = random.Next() % teams.Count;
                Team firstTeam = teams[firstIndex];
                teams.RemoveAt(firstIndex);
                int secondIndex = random.Next() % teams.Count;
                Team secondTeam = teams[secondIndex];
                teams.RemoveAt(secondIndex);

                if (random.NextDouble() >= 0.5) final.Add(firstTeam);
                else final.Add(secondTeam);
            }

            Console.WriteLine("Finaliści:");
            final.ForEach(team => {
                Console.WriteLine(team.getName());
                teams.Add(team);
            });

        }
        public void finals()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Rozpoczynamy finał w dwóch ogniach");
            Console.WriteLine("W finale wystąpią " + teams[0].getName() + " i " + teams[1].getName());
            if (random.NextDouble() >= 0.5)
            {
                Console.WriteLine("Turniej wygrywa " + teams[1].getName());
            }
            else
            {
                Console.WriteLine("Turniej wygrywa " + teams[0].getName());
            }
        }
    }
}
