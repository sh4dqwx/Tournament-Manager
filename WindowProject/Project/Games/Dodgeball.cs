using System;
using System.Collections.Generic;
using System.Linq;
using Project.Registrations;

namespace Project.Games
{
    public class Dodgeball : Sports
    {
        private string results = "";
        private Random random = new Random();
        public Dodgeball()
        {

        }

        private void playMatch(Team t1, Team t2)
        {
            if (random.NextDouble() >= 0.5)
            {
                results += t1.getName() + " wygrywa z " + t2.getName()+"\n";
                //Console.WriteLine(t1.getName() + " wygrywa z " + t2.getName());
                t1.addScore();
            }
            else
            {
                results += t2.getName() + " wygrywa z " + t1.getName()+"\n";
                //Console.WriteLine(t2.getName() + " wygrywa z " + t1.getName());
                t2.addScore();
            }
        }
        public string playElimination()
        {
            results = "";
            results += "Rozpoczynamy turniej dwóch ogni\n";
            //Console.WriteLine("Rozpoczynamy turniej dwóch ogni");
            //Console.WriteLine("---------------------------------------------------------------");
            teams.ForEach(team => team.resetScore());

            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    playMatch(teams[i], teams[j]);
                }
            }

            Console.WriteLine("---------------------------------------------------------------");
            teams = teams.OrderBy(team => team.getScore()).ToList();
            teams.Reverse();
            results += "Wyniki wszystkich drużyn:\n";
            //Console.WriteLine("Wyniki wszystkich drużyn:");
            results+=showResults();

            if (teams[3].getScore() != teams[4].getScore())
            {
                teams.RemoveRange(4, teams.Count - 4);
                results += "Lista drużyn zakwalifikowanych: \n";
                //Console.WriteLine("Lista drużyn zakwalifikowanych: ");
                results+=showResults();
                return results;
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
            results += "Lista zakwalifikowanych:\n";
            //Console.WriteLine("Lista zakwalifikowanych:");
            results+=showResults();
            return results;
        }
        public string playSemiFinal()
        {
            results = "";
            List<Team> final = new List<Team>();
            while (final.Count < 2)
            {
                int firstIndex = random.Next() % teams.Count;
                Team firstTeam = teams[firstIndex];
                teams.RemoveAt(firstIndex);
                int secondIndex = random.Next() % teams.Count;
                Team secondTeam = teams[secondIndex];
                teams.RemoveAt(secondIndex);
                results += firstTeam.getName() + " vs " + secondTeam.getName() + "\n";
                if (random.NextDouble() >= 0.5)
                {
                    final.Add(firstTeam);
                    results+= firstTeam.getName() + " wygrywa\n";
                }
                else
                {
                    results += secondTeam.getName() + " wygrywa\n";
                    final.Add(secondTeam);
                }
            }
            results += "Finaliści:\n";
            //Console.WriteLine("Finaliści:");
            final.ForEach(team => {
                results += team.getName() + "\n";
                //Console.WriteLine(team.getName());
                teams.Add(team);
            });
            return results;
        }
        public string playFinal()
        {
            results = "";
            //Console.WriteLine("\n");
            //Console.WriteLine("Rozpoczynamy finał w dwóch ogniach");
            //Console.WriteLine("W finale wystąpią " + teams[0].getName() + " i " + teams[1].getName());
            results += "Rozpoczynamy finał w dwóch ogniach\n";
            results += "W finale wystąpią " + teams[0].getName() + " i " + teams[1].getName()+"\n";
            if (random.NextDouble() >= 0.5)
            {
                results += "Turniej wygrywa " + teams[1].getName();
                teams.RemoveAt(0);
                //Console.WriteLine("Turniej wygrywa " + teams[1].getName());
            }
            else
            {
                results += "Turniej wygrywa " + teams[1].getName();
                teams.RemoveAt(1);
                //Console.WriteLine("Turniej wygrywa " + teams[0].getName());
            }
            return results;
        }
    }
}
