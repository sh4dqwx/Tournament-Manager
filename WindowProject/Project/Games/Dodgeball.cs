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
        //rozgrywanie spotkania
        private void playMatch(Team t1, Team t2)
        {
            results+= t1.getName() + " vs " + t2.getName() + " sędziuje " + judges[random.Next() % judges.Count].getSurname() + "\n";
            if (random.NextDouble() >= 0.5)
            {
                results += "Wygrywa " + t1.getName()+"\n";
                t1.addScore();
            }
            else
            {
                results += "Wygrywa " + t2.getName()+"\n";
                t2.addScore();
            }
            results += "\n";
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
                    playMatch(teams[i], teams[j]);
                }
            }
            teams = teams.OrderBy(team => team.getScore()).ToList();
            teams.Reverse();
            results += "Punktacja:\n";
            results+=showResults();

            if (teams[3].getScore() != teams[4].getScore())
            {
                teams.RemoveRange(4, teams.Count - 4);
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
            results += "Półfinaliści:\n";
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
                results += firstTeam.getName() + " vs " + secondTeam.getName() + " sędziuje " + judges[random.Next() % judges.Count].getSurname()+"\n";
                if (random.NextDouble() >= 0.5)
                {
                    final.Add(firstTeam);
                    results+= "Spotkanie wygrywa "+firstTeam.getName() + "\n";
                }
                else
                {
                    results += "Spotkanie wygrywa "+secondTeam.getName() + "\n";
                    final.Add(secondTeam);
                }
            }
            results += "Finaliści:\n";
            final.ForEach(team => {
                results += team.getName() + "\n";
                teams.Add(team);
            });
            return results;
        }
        //rozgrywanie finałów
        public string playFinal()
        {
            if (teams.Count != 2) throw new Exception("Not enough teams");
            results = "";
            results += "Mecz finałowy:\n";
            results += teams[0].getName() + " vs " + teams[1].getName() + " sędziuje " + judges[random.Next() % judges.Count].getSurname() + "\n";
            if (random.NextDouble() >= 0.5)
            {
                results += "Finał wygrywa " + teams[1].getName();
                teams.RemoveAt(0);
            }
            else
            {
                results += "Finał wygrywa " + teams[1].getName();
                teams.RemoveAt(1);
            }
            return results;
        }
    }
}
