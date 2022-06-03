using System;
using Project.Logic.Registrations;

namespace Project.Logic.Tournaments
{
    public class Dodgeball : Tournament
    {
        public Dodgeball(string name) : base(name) { }

        public override string getCategory()
        {
            return "Dwa ognie";
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
            if (!(obj is Dodgeball)) return false;
            Dodgeball dTeam = (Dodgeball)obj;
            return name.Equals(dTeam.name);
        }
    }
}
