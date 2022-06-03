using System;
using Project.Logic.Registrations;

namespace Project.Logic.Tournaments
{
    public class Volleyball : Tournament
    {
        public Volleyball(string name) : base(name) { }

        public override string getCategory()
        {
            return "Siatkówka";
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
