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
        //rozgrywanie elimiancji, dodatkowo algorytm przeprowadzający kolejne losowania jeżeli liczba drużyn z najwyższą punktacją jest większa niż 4
        public string playElimination()
        {
            if (teams.Count <= 4) throw new Exception("Not enough teams");
            results = "";
            teams.ForEach(team => team.resetScore());

            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    results += teams[i].getName() + " vs " + teams[j].getName() + " sędziuje " + judges[random.Next() % judges.Count].getSurname() + "\n";
                    if (random.NextDouble() >= 0.5)
                    {
                        results += "Wygrywa " + teams[i].getName() + "\n";
                        teams[i].addScore();
                    }
                    else
                    {
                        results += "Wygrywa " + teams[j].getName() + "\n";
                        teams[j].addScore();
                    }
                    results += "\n";
                }
            }
            teams = teams.OrderBy(team => team.getScore()).ToList();
            teams.Reverse();
            results += "Punktacja:\n";
            results+=showResults();

           
            if (teams[3].getScore() != teams[4].getScore())
            {
                teams.RemoveRange(4, teams.Count - 4);
                results += "\n";
                results += "Półfinaliści: \n";
                results+=showResults();
                return results;
            }

           
            List<Team> errorTeams = teams.FindAll(team => team.getScore() == teams[3].getScore());
            int qualified = teams.Where(team => team.getScore() > teams[3].getScore()).Count();
            teams.RemoveRange(qualified, teams.Count - qualified);

        
            for (int i = 0; i < 4 - qualified; i++)
            {
                int chosen = random.Next() % errorTeams.Count;
                teams.Add(errorTeams[chosen]);
                errorTeams.RemoveAt(chosen);
            }
            results += "\n";
            results += "Półfinaliści: \n";
            results+=showResults();
            return results;
        }
        //rozgrywanie półfinałów
        public string playSemiFinal()
        {
            if (teams.Count != 4) throw new Exception("Not enough teams");
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
                results += firstTeam.getName() + " vs " + secondTeam.getName() + " sędziuje " + judges[random.Next() % judges.Count].getSurname() + "\n";
                if (random.NextDouble() >= 0.5)
                {
                    results += "Spotkanie wygrywa " + firstTeam.getName() + "\n\n";
                    final.Add(firstTeam);
                }
                else
                {
                    results += "Spotkanie wygrywa " + secondTeam.getName() + "\n\n";
                    final.Add(secondTeam);
                }
            }
            results += "Finaliści:\n";
            final.ForEach(team => {
                results += team.getName() + "\n";
                teams.Add(team);
            });
            teams = teams.OrderBy(team => team.getScore()).ToList();
            teams.Reverse();
            return results;
        }
        //rozgrywanie finałów
        public string playFinal()
        {
            if (teams.Count != 2) throw new Exception("Not enough teams");
            results = "";
            results += "Mecz finałowy\n";
            results += teams[0].getName() + " vs " + teams[1].getName() + " sędziuje " + judges[random.Next() % judges.Count].getSurname() + "\n";
            if (random.NextDouble() >= 0.5)
            {
                results += "Finał wygrywa " + teams[1].getName();
                teams.RemoveAt(0);
            }
            else
            {
                results += "Finał wygrywa " + teams[0].getName();
                teams.RemoveAt(1);
            }
            return results;
        }
    }
}
