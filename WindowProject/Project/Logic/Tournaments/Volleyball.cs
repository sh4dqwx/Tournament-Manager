using System;
using Project.Logic.Registrations;

namespace Project.Logic.Tournaments
{
    public class Volleyball : Tournament, ISport
    {
        public Volleyball(string name) : base(name) { }

        public override int getCategory()
        {
            return 0;
        }
        public void generateElimination()
        {
            for (int i = 0; i < teams.Count; i++)
                for (int j = i + 1; j < teams.Count; j++)
                    games.Add(new Game(teams[i], teams[j]));
        }

        public void generateSemiFinal()
        {
            games.Add(new Game(teams[0], teams[2]));
            games.Add(new Game(teams[1], teams[3]));
        }

        public void generateFinal()
        {
            games.Add(new Game(teams[0], teams[1]));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Volleyball)) return false;
            Volleyball vTeam = (Volleyball)obj;
            return name.Equals(vTeam.name);
        }
    }
}
