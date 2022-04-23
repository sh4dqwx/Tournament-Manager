﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Tug_of_war: Sports
    {
        private Random random = new Random();
        public Tug_of_war()
        {

        }
        public void playElimination()
        {
            Console.WriteLine("Rozpoczynamy turniej przeciagania liny");
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
            Console.WriteLine("\n");
            Console.WriteLine("Rozpoczynamy półfinały");
            if (random.NextDouble() >= 0.5)
            {
                Console.WriteLine("W spotkaniu " + teams[0].getName() + " vs " + teams[3].getName() + " wygrywa " + teams[3].getName());
                teams.RemoveAt(0);
                if (random.NextDouble() >= 0.5)
                {
                    Console.WriteLine("W spotkaniu " + teams[0].getName() + " vs " + teams[1].getName() + " wygrywa " + teams[1].getName());
                    teams.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine("W spotkaniu " + teams[0].getName() + " vs " + teams[1].getName() + " wygrywa " + teams[0].getName());
                    teams.RemoveAt(1);
                }
            }
            else
            {
                Console.WriteLine("W spotkaniu " + teams[0].getName() + " vs " + teams[3].getName() + " wygrywa " + teams[0].getName());
                teams.RemoveAt(3);
                if (random.NextDouble() >= 0.5)
                {
                    Console.WriteLine("W spotkaniu " + teams[1].getName() + " vs " + teams[2].getName() + " wygrywa " + teams[2].getName());
                    teams.RemoveAt(1);
                }
                else
                {
                    Console.WriteLine("W spotkaniu " + teams[1].getName() + " vs " + teams[2].getName() + " wygrywa " + teams[1].getName());
                    teams.RemoveAt(2);
                }
            }

        }
        public void finals()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Rozpoczynamy finał w przeciąganiu liny");
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
