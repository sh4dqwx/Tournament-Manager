using System;
using System.Linq;

namespace Projekt
{
    public class Volleyball: Sports
    {
        private Random random = new Random();
        public Volleyball()
        {
            
        }
        public void playElimination()
        {
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

            if (teams[3].getScore() != teams[4].getScore())
            {
                teams.RemoveRange(4, teams.Count - 4);
                Console.WriteLine("Półfinaliści:");
                showResults();
                return;
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

            Console.WriteLine("Półfinaliści:");
            showResults();
        }

        public void playSemiFinal()
        {
            List<Team> final = new List<Team>();
            while(final.Count < 2)
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
            final.ForEach(team => { Console.WriteLine(team.getName()); teams.Add(team); });

        }

        public void playFinal()
        {
            if (random.NextDouble() >= 0.5) teams.RemoveAt(0);
            else teams.RemoveAt(1);

            Console.WriteLine("\nZwycięzca:");
            teams.ForEach(team => Console.WriteLine(team.getName()));
        }


    }
}
