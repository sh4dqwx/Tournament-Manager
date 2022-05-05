using System;
using System.Linq;
using System.Collections.Generic;
using Project.Registrations;

namespace Project.Games
{
    public class Tug_of_war: Sports
    {
        private Random random = new Random();
        private string results = "";
        public Tug_of_war()
        {

        }
        public string playElimination()
        {
            results = "";
            results += "Rozpoczynamy turniej przeciagania liny\n";
            //Console.WriteLine("Rozpoczynamy turniej przeciagania liny");
            //Console.WriteLine("---------------------------------------------------------------");
            teams.ForEach(team => team.resetScore());

            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    if (random.NextDouble() >= 0.5)
                    {
                        results += teams[i].getName() + " wygrywa z " + teams[j].getName() + "\n";
                        //Console.WriteLine(teams[i].getName() + " wygrywa z " + teams[j].getName());
                        teams[i].addScore();
                    }
                    else
                    {
                        results += teams[j].getName() + " wygrywa z " + teams[i].getName() + "\n";
                        //Console.WriteLine(teams[j].getName() + " wygrywa z " + teams[i].getName());
                        teams[j].addScore();
                    }
                }
            }
            //Console.WriteLine("---------------------------------------------------------------");
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
            results += "Lista drużyn zakwalifikowanych: \n";
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
                    results += firstTeam.getName()+" wygrywa\n";
                    final.Add(firstTeam);
                    firstTeam.addScore();
                }
                else
                {
                    results += secondTeam.getName() + " wygrywa\n";
                    final.Add(secondTeam);
                    secondTeam.addScore();
                }
            }
            results += "Finaliści:\n";
            //Console.WriteLine("Finaliści:");
            final.ForEach(team => {
                //Console.WriteLine(team.getName());
                results += team.getName() + "\n";
                teams.Add(team);
            });
            return results;
        }
        public string playFinal()
        {
            results = "";
            //Console.WriteLine("\n");
            results += "Rozpoczynamy finał w przeciąganiu liny\n";
            //Console.WriteLine("Rozpoczynamy finał w przeciąganiu liny");
            results += "W finale wystąpią " + teams[0].getName() + " i " + teams[1].getName()+"\n";
            //Console.WriteLine("W finale wystąpią " + teams[0].getName() + " i " + teams[1].getName());
            if (random.NextDouble() >= 0.5)
            {
                results += "Turniej wygrywa " + teams[1].getName();
                Console.WriteLine("Turniej wygrywa " + teams[1].getName());
                teams.RemoveAt(0);
            }
            else
            {
                results += "Turniej wygrywa " + teams[0].getName();
                Console.WriteLine("Turniej wygrywa " + teams[0].getName());
                teams.RemoveAt(1);
            }
            return results;
        }
    }
}
