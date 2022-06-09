using System;
using Project.Logic.Registrations;

namespace Project.Logic.Tournaments
{
    public class Dodgeball : Tournament
    {
        public Dodgeball(string name, Random random) : base(name, random) { }

        public override string getCategory()
        {
            return "Dwa ognie";
        }
        public override string getBackground()
        {
            return "/Backgrounds/dodgeball.png";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Dodgeball)) return false;
            Dodgeball dTeam = (Dodgeball)obj;
            return name.Equals(dTeam.name);
        }
    }
}
