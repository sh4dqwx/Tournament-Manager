using System;
using System.Linq;
using System.Collections.Generic;
using Project.Registrations;
using Project.Exceptions;

namespace Project.Games
{
    public class Volleyball: Sports, ISport
    {
        //rozgrywanie elimiancji, dodatkowo algorytm przeprowadzający kolejne losowania jeżeli liczba drużyn z najwyższą punktacją jest większa niż 4
        public string playElimination()
        {
            if (teams.Count <= 4) throw new NotEnoughException("Za mało drużyn, minimalna liczba to 5");
            results = "";
            teams.ForEach(team => team.resetScore());
            int set;
            int d1;
            int d2;
            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    set = 1;
                    d1 = 0;
                    d2 = 0;
                    results += teams[i].getName() + " vs " + teams[j].getName()+" sędziuje "+judges[random.Next()%judges.Count].getSurname()+"\n";
                    for (int k = 0; k < 3; k++)
                    {
                        if(random.NextDouble() >= 0.5)
                        {
                            d1++;
                            results += set + " set wygrała " + teams[i].getName() + "\n";
                            set++;
                        }
                        else
                        {
                            d2++;
                            results += set + " set wygrała " + teams[j].getName() + "\n";
                            set++;
                        }
                        if(d1==2 || d2==2)
                        {
                            break;
                        }
                    }
                    if (d1 > d2)
                    {
                        results += "Wygrywa " + teams[i].getName() + "\n";
                        results += "\n";
                        teams[i].addScore();
                    }
                    else
                    {
                        results += "Wygrywa " + teams[j].getName() + "\n";
                        results += "\n";
                        teams[j].addScore();
                    }
                    Console.WriteLine("\n");
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
                results += "Półfinaliści:\n";
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
            results +=showResults();
            return results;
        }
        //rozgrywanie półfinałów
        public string playSemiFinal()
        {
            if (teams.Count != 4) throw new Exception("Not enough teams");
            results = "";
            List<Team> final = new List<Team>();
            while(final.Count < 2)
            {
                int firstIndex = random.Next() % teams.Count;
                Team firstTeam = teams[firstIndex];
                teams.RemoveAt(firstIndex);
                int secondIndex = random.Next() % teams.Count;
                Team secondTeam = teams[secondIndex];
                teams.RemoveAt(secondIndex);
                results += firstTeam.getName() + " vs " + secondTeam.getName()+" sędziuje " + judges[random.Next() % judges.Count].getSurname()+"\n";
                int d1 = 0;
                int d2 = 0;
                for (int i = 1; i < 4; i++)
                {
                    if (random.NextDouble() >= 0.5)
                    {
                        results += "Set " + i + " wygrywa " + firstTeam.getName() + "\n";
                        d1++;
                        if (d1 == 2)
                        {
                            results +="Spotkanie wygrywa "+firstTeam.getName() + "\n\n";
                            firstTeam.addScore();
                            final.Add(firstTeam);
                            break;
                        }
                    }
                    else
                    {
                        results += "Set " + i + " wygrywa " + secondTeam.getName() + "\n";
                        d2++;
                        if (d2 == 2)
                        {
                            results += "Spotkanie wygrywa " + secondTeam.getName() + "\n\n";
                            secondTeam.addScore();
                            final.Add(secondTeam);
                            break;
                        }
                    }
                }
            }
            results += "Finaliści:\n";
            final.ForEach(team => {
                results+=team.getName()+"\n";
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
            int d1 = 0;
            int d2 = 0;
            results += "Mecz finałowy:\n";
            results += teams[0].getName() + " vs " + teams[1].getName() + " sędziuje " + judges[random.Next() % judges.Count].getSurname() + "\n";
            for (int i = 1; i < 4; i++)
            {
                if (random.NextDouble() >= 0.5)
                {
                    results += "Set " + i + " wygrywa " + teams[0].getName() + "\n";
                    d1++;
                    if(d1==2)
                    {
                        results += "Finał wygrywa " + teams[0].getName();
                        teams.RemoveAt(1);
                        teams[0].addScore();
                        break;
                    }
                }
                else
                {
                    results += "Set " + i + " wygrywa " + teams[1].getName() + "\n";
                    d2++;
                    if (d2 == 2)
                    {
                        results += "Finał wygrywa " + teams[1].getName();
                        teams.RemoveAt(0);
                        teams[0].addScore();
                        break;
                    }
                }
            }
            return results;  
        }
    }
}
